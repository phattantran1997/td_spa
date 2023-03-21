namespace TD_SPA_Project.Serivce.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity?> Add(TEntity obj);
        Task<TEntity?> GetById(int id);
        Task<IEnumerable<TEntity?>> GetAll ();
        Task<TEntity?> Update(int id, TEntity obj);
        Task<bool> DeleteById(int id);
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
