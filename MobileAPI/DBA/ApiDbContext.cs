using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MobileAPI.Models;

namespace MobileAPI.DBA
{
    public class ApiDbContext :DbContext
    {
        public ApiDbContext() : base("DbConnection")
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}