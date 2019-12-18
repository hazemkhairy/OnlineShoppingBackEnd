using OSBE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSBE.BLL
{
    public class ExampleBLL
    {
        public string GetExample()
        {
            return "DONEEE";
        }
        public string PostExample(ExampleClientDTO client)
        {
            return client.FirstName + ' ' + client.Email;
        }
    }
}