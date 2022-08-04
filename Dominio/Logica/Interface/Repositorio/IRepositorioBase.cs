namespace Dominio.Logica.Interface.Repositorio
{
    using System.Linq.Expressions;

    public interface IRepositorioBase<E> where E : class
    {
        Task<E?> ObterPorId(params object[] chavePrimaria);
        E? ObterUltimo(Expression<Func<E, bool>> where);
        Task<bool> Inserir(E entity);
        Task<bool> Atualizar(E entity);
        Task<bool> Existe(Expression<Func<E, bool>> where);
        Task<int> ContarSomente(Expression<Func<E, bool>> where);
        IQueryable<E>? ObterSomente(Expression<Func<E, bool>> where);
        IQueryable<E>? ObterSomenteComPredicado(Expression<Func<E, bool>> where);
        IQueryable<E>? ObterTodos();
    }
}