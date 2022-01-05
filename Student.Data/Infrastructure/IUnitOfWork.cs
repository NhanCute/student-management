namespace Student.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}