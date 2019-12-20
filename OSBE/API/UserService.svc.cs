﻿using OSBE.BLL;
using OSBE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OSBE.API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private UserBLL userBLL;
        public UserService()
        {
            userBLL = new UserBLL();

        }

        public UserDTO Register(UserDTO user)
        {
            return userBLL.Register(user);
        }
        public int Login(UserDTO user)
        {
            return userBLL.Login(user);
        }
        public bool isAdmin(string id)
        {
            return userBLL.isAdmin(int.Parse(id));
        }
    }
}
