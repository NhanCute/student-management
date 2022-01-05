using Student.Data.Infrastructure;
using Student.Data.Repositories;
using Student.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Service
{
    public interface IStudentInformationService
    {
        StudentInformation Add(StudentInformation postCategory);

        void Update(StudentInformation StudentInformation);

        StudentInformation Delete(string id);

        IEnumerable<StudentInformation> GetAll();

        IEnumerable<StudentInformation> GetAll(string keyword);

        StudentInformation GetById(string id);

        void Save();

        string SaveStudent(StudentInformation StudentInformation);

        List<StudentInformation> getTenTheodk(string dk);
    }
    public class StudentInformationService : IStudentInformationService
    {
        private IStudentInformationRepository _StudentInformationRepository;
        private IUnitOfWork _unitOfWork;

        public StudentInformationService(IStudentInformationRepository StudentInformationRepository, IUnitOfWork unitOfWork)
        {
            this._StudentInformationRepository = StudentInformationRepository;
            this._unitOfWork = unitOfWork;
        }


        public IEnumerable<StudentInformation> GetAll()
        {
            return _StudentInformationRepository.GetAll();
        }

        public IEnumerable<StudentInformation> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _StudentInformationRepository.GetMulti(x => x.StudentName.Contains(keyword));
            else
                return _StudentInformationRepository.GetAll();
        }

        public StudentInformation Delete(string id)
        {
            return _StudentInformationRepository.Delete(id);
        }

        public StudentInformation GetById(string id)
        {
            return _StudentInformationRepository.GetSingleById(id);
        }

        public void Update(StudentInformation StudentInformation)
        {
            _StudentInformationRepository.Update(StudentInformation);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public StudentInformation Add(StudentInformation StudentInformation)
        {
            return _StudentInformationRepository.Add(StudentInformation);
        }

        public string SaveStudent(StudentInformation st)
        {
            return _StudentInformationRepository.SaveStudent(st);
        }

        public List<StudentInformation> getTenTheodk(string dk)
        {
            return _StudentInformationRepository.GetlistStudent(dk);
        }
    }
}
