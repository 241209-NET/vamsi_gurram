using Microsoft.EntityFrameworkCore;
using OnlineUniversity.API.Model;

namespace OnlineUniversity.API.Data;

public partial class StudentContext : DbContext
{
    public StudentContext() { }
    public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Teacher> Teachers { get; set; }


}