using Microsoft.EntityFrameworkCore;
using StudentResultPublishing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResultPublishing.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentResultApplicationDbContext _dbContext;

        public StudentRepository(StudentResultApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public StudentDetails GetStudentResults(string RegisterNumber,DateTime dateOfBirth)
        {          
                return _dbContext.StudentDetails.Include(s => s.StudentResults).ThenInclude(x => x.Subject)
                    .Where(x => x.RegisterNumber == RegisterNumber && x.DateOfBirth == dateOfBirth).FirstOrDefault();          
        }
        public IEnumerable<StudentDetails> GetAllStudentResults()
        {
            return _dbContext.StudentDetails.Include(s=>s.StudentResults).ThenInclude(x=>x.Subject);
        }

        public bool AddResult(StudentResult result)
        {
            try
            {
                _dbContext.StudentResult.Add(result);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveAll()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public IEnumerable<Subjects> GetAllSubjects()
        {
            return _dbContext.Subjects;
        }
    }
}
