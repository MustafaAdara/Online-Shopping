using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication12.Data;

namespace WebApplication12.Services
{
    public interface IAdminServices
    {
        bool login(string UserName, int Password);
        bool ForgetPassword(string UserName);
        bool LoginCustomer(string UserName, int Password);



    }
    public class AdminServices : IAdminServices
    {
        public SoftwareProject_DBEntity DBContext { get; set; }
        public AdminServices()
        {
            DBContext = new SoftwareProject_DBEntity();
        }
        public bool ForgetPassword(string UserName)
        {
            throw new NotImplementedException();
        }

        public bool login(string UserName, int Password)
        {
            return DBContext.Admins.Where(a => a.Admin_Name == UserName && a.Admin_Password == Password)
                .Any();
            throw new NotImplementedException();
        }
        public bool LoginCustomer(string UserName, int Password)
        {
            return DBContext.Customers.Where(a => a.CustomerName == UserName && a.Password == Password)
                .Any();
            throw new NotImplementedException();
        }

    }
}