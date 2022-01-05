using Student.Data.Infrastructure;
using Student.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Student.Data.Repositories
{
    public interface IStudentInformationRepository : IRepository<StudentInformation>
    {
        string SaveStudent(StudentInformation St);
        List<StudentInformation> GetlistStudent(string dk);
    }

    public class StudentInformationRepository : RepositoryBase<StudentInformation>, IStudentInformationRepository
    {
        public StudentInformationRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public string SaveStudent(StudentInformation St)
        {
            try
            {
                using (var context = new StudentDbContext())
                {
                    context.StudentInformation.Add(St);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
       
            return "Thanh Cong";
        }

        public List<StudentInformation> GetlistStudent(string dk)
        {
            List<StudentInformation> list = new List<StudentInformation>();
            try
            {
                using (var context = new StudentDbContext())
                {
                    list = context.StudentInformation
                                               .Where(s => s.StudentName == dk).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return list;
        }
    }
}
