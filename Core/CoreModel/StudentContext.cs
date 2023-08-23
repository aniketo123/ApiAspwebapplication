using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CoreModel
{
    public class StudentContext:DbContext
    {
        public StudentContext(): base("server=Aniket\\SQLEXPRESS;database=dbStudent1;trusted_connection=true") { }
        public DbSet<StudentCoreModel> StudentRecord { get; set; }

        public DbSet<UserCoreModel> Users { get; set; }

    }
}
