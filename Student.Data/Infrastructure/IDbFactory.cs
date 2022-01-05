using Student.Data;
using System;

namespace Student.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        StudentDbContext Init();
    }
}