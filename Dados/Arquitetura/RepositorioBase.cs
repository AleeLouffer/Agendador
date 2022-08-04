namespace Dados.Arquitetura
{
    using Dominio.Logica.Interface.Repositorio;
    using LinqKit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Linq.Expressions;
    using static System.DateTime;

    public abstract class RepositorioBase<E, C> : IRepositorioBase<E>, IDisposable where E : class, new() where C : DbContext
    {
        protected DbSet<E> _entidades;
        protected readonly C _contexto;
        protected ILogger<RepositorioBase<E, C>> _logger;

        protected RepositorioBase(C contexto, ILogger<RepositorioBase<E, C>> logger)
        {
            _contexto = contexto;
            _entidades = contexto.Set<E>();
            _logger = logger;
        }

        public async Task<E?> ObterPorId(params object[] chavePrimaria)
        {
            try
            {
                return await _entidades.FindAsync(chavePrimaria);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro");
                return null;
            }
        }

        public E? ObterUltimo(Expression<Func<E, bool>> where)
        {
            try
            {
                return _entidades.Where(where).AsEnumerable().LastOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro");
                return null;
            }
        }

        public async Task<bool> Inserir(E entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"Entidade {nameof(entity)} está nula");
            }

            _entidades.Add(entity);

            return await SalvarAlteracoes();
        }

        public async Task<bool> Atualizar(E entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"Entidade {nameof(entity)} está nula");
            }

            _entidades.Update(entity);

            return await SalvarAlteracoes();
        }

        public async Task<bool> Existe(Expression<Func<E, bool>> where)
        {
            return await ContarSomente(where) > 0;
        }

        public async Task<int> ContarSomente(Expression<Func<E, bool>> where)
        {
            try
            {
                return await _entidades.Where(where).CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro");
                return 0;
            }
        }

        public IQueryable<E>? ObterSomente(Expression<Func<E, bool>> where)
        {
            try
            {
                return _entidades.Where(where);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro");
                return null;
            }
        }

        public IQueryable<E>? ObterSomenteComPredicado(Expression<Func<E, bool>> where)
        {
            try
            {
                return _entidades.AsExpandable().Where(where);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro");
                return null;
            }
        }

        public IQueryable<E>? ObterTodos()
        {
            try
            {
                return _entidades;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro");
                return null;
            }
        }

        public void Dispose()
        {
            _contexto?.Dispose();
        }

        private async Task<bool> SalvarAlteracoes()
        {
            try
            {
                var salvou = await _contexto.SaveChangesAsync();
                return Convert.ToBoolean(salvou);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro");
                return false;
            }
        }
    }
}