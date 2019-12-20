using OSBE.Context;
using OSBE.DTOs;
using OSBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;

namespace OSBE.BLL
{
    public class UserBLL
    {
        OSContext _context;
        public UserBLL()
        {
            _context = new OSContext();
        }

        public UserDTO Register(UserDTO user)
        {
            User user1 = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if(user1!=null)
            {
                throw new WebFaultException<string>("Email Already Exists", HttpStatusCode.Conflict);
            }
            user1 = new User()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                IsAdmin = false 
            };

            _context.Users.Add(user1);
            _context.SaveChanges();
            user.ID = user1.ID;
            return user;
        }
        public int Login(UserDTO user)
        {
            User user1 = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (user1 == null)
            {
                throw new WebFaultException<string>("Invalid Email or Password", HttpStatusCode.NotFound);
            }

            
           return user1.ID;
        }
        public bool isAdmin (int id)
        {
            User user = _context.Users.FirstOrDefault(i => i.ID == id);
            if (user != null && user.IsAdmin)
            {
                return true;
            }
            return false;
        }

    }
}