using Student.Data;

namespace Student.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private StudentDbContext dbContext;

        public StudentDbContext Init()
        {
            return dbContext ?? (dbContext = new StudentDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}