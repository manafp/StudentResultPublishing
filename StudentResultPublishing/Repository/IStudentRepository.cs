using StudentResultPublishing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResultPublishing.Repository
{
    public interface IStudentRepository
    {
        StudentDetails GetStudentResults(string RegisterNumber,DateTime dateOfBirth);
    }
}
