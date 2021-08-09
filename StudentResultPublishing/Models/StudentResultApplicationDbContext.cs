using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace StudentResultPublishing.Models
{
    public class StudentResultApplicationDbContext :IdentityDbContext<IdentityUser>
    {
        public StudentResultApplicationDbContext(DbContextOptions<StudentResultApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<StudentDetails> StudentDetails { get; set; }
        public DbSet<StudentResult> StudentResult { get; set; }
        public DbSet<Subjects> Subjects { get; set; }

    }
}