using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithJWTService.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace WebApiWithJWTService.Repositories
{
    public class DBRepository : IDBRepository
    {
        private ApplicationDBContext appDBContext;


        public DBRepository(ApplicationDBContext appDBContext)
        {
            //DI(Dependency Injection) Handling
            this.appDBContext = appDBContext;
        }

        //Use Direct Call Procedure
        public List<DBDate> GetDBDate()
        {
            //
            try
            {
                appDBContext.Database.OpenConnection();

                using (DbCommand command = appDBContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "GetDBDate";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    appDBContext.DBDates = new List<DBDate>();

                    using (var result = command.ExecuteReader())
                    {
                        while(result.Read())
                        {
                            appDBContext.DBDates.Add(new DBDate() { Date = result.GetName(0) + result[0] });
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                //Logging Something...
                //Below Code is just DummyCode.
                appDBContext.DBDates.Add(new DBDate() { Date = ex.Message });
            }

            return appDBContext.DBDates;
        }

        //Use Raw SQL Queries
        //https://docs.microsoft.com/en-us/ef/core/querying/raw-sql
        public void GetUserInfo()
        {
            var dataUserInfos = appDBContext.UserInfos
                .FromSql("SELECT * FROM dbo.UserInfos")
                .ToList();



        }
    }
}
