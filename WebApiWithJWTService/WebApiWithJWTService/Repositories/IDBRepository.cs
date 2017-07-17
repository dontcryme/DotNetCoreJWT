using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithJWTService.Models;

namespace WebApiWithJWTService.Repositories
{
    public interface IDBRepository
    {
        List<DBDate> GetDBDate();
        void GetUserInfo();
    }
}
