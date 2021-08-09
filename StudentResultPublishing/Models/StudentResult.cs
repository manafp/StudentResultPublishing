using System.Collections.Generic;

namespace StudentResultPublishing.Models
{
    public class StudentResult
    {
        public int Id { get; set; }
        public double TotalMark { get; set; }
        public string Grade { get; set; }

        public Subjects Subject { get; set; }
    }
}