using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResultPublishing.Models
{
    public class StudentDetails
    {
        public StudentDetails()
        {
            StudentResults = new List<StudentResult>();
        }
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RegisterNumber { get; set; }

        public ICollection<StudentResult> StudentResults { get; set; }
    }
}
