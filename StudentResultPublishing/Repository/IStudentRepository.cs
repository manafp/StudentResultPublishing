using StudentResultPublishing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResultPublishing.Repository
{
    public interface IStudentRepository
    {
        bool SaveAll();
        StudentDetails GetStudentResults(string RegisterNumber,DateTime dateOfBirth);
        IEnumerable<StudentDetails> GetAllStudentResults();
        bool AddResult(StudentResult result);
        IEnumerable<Subjects> GetAllSubjects();
    }
}
