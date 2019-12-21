using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSBE.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int PaymentID { get; set; }
        public int UserID { get; set; }
        public List <KeyValuePair<int,int>> products;
    }
}