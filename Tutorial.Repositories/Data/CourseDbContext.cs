using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;

namespace Tutorial.Repositories.Data
{
    public class CourseDbContext: DbContext
    {

        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {
        }
        // Define DbSets for your entities here
         public DbSet<Course> Courses{ get; set; }
         public DbSet<Topic> Topics{ get; set; }
         public DbSet<Content> Contents{ get; set; }
         public DbSet<SubTopic> SubTopics{ get; set; }


    }
}
