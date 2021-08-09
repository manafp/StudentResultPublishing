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
    }
}
