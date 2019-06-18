namespace API_Email.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IRepository<T> where T: EntityBase
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<bool> Delete(int id);
        Task<bool> Update(T entity);
    }
}
