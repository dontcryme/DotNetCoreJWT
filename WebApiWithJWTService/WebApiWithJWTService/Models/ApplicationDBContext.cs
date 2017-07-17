using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithJWTService.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }


        public List<DBDate> DBDates { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }


    }
}
