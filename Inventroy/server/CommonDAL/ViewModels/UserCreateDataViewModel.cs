using CommonDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class UserCreateDataViewModel: User
    {
        public List<UserType>  UserTypes { get; set; }
        public List<Shop> Shops { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
