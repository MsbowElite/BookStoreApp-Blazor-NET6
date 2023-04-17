namespace LibraryStore.Domain.Repositories.Internal
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
