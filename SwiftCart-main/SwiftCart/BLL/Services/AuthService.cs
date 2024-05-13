using DAL;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static bool Authenticate(string username, string password)
        {

            return DataFactory.AuthData().Authenticate(username, password);

        }
    }
}

