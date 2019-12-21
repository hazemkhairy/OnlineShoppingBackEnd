﻿using OSBE.Context;
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
    public class OrderBLL
    {
        public OrderBLL()
        {
            
        }

        private List<KeyValuePair<int, int>> getProducts ( int orderID)
        {
            using (OSContext _context = new OSContext())
            {
                List<OrderItem> products = _context.OrderItems.Include("Category").Where(i => i.OrderID == orderID).ToList();
                List<KeyValuePair<int, int>> user_products = new List<KeyValuePair<int, int>>();

                for (int i = 0; i < products.Count; i++)
                {
                    user_products.Add(new KeyValuePair<int, int>(products[i].ItemID, products[i].Quantity));
                }
                return user_products;
            }

        }
        private OrderDTO convertToDTO(Order order)
        {
            return new OrderDTO()
            {
                Address = order.Address,
                City = order.City,
                Country = order.Country,
                FullName = order.ReciverFullName,
                Zip = order.ZIPCode,
                paymentType = new PaymentTypeDTO()
                {
                    ID = order.PaymentType.ID,
                    Name = order.PaymentType.Name
                },
                OrderID = order.ID,
                user = new UserDTO()
                {
                    FirstName = order.User.FirstName,
                    LastName = order.User.LastName,
                    Email = order.User.Email,
                    ID = order.User.ID,
                    Password = order.User.Password
                },
                    products = getProducts(order.ID)
                };
            
        }
        public List<OrderDTO> GetAll(string userID)
        {
            using (OSContext _context = new OSContext())
            {

                int id = int.Parse(userID);
                User user = _context.Users.FirstOrDefault(u => u.ID == id);
                if (user == null)
                {
                    throw new WebFaultException<string>("User Dosent Exist", HttpStatusCode.NotFound);
                }
                List<OrderDTO> allOrders = new List<OrderDTO>();
                if (user.IsAdmin)
                {
                    List<Order> orders = _context.Orders.Include("PaymentType").Include("User").ToList();
                    for (int i = 0; i < orders.Count; i++)
                    {
                        allOrders.Add(GetOrder(orders[i].ID.ToString()));
                    }

                }
                else
                {
                    List<Order> orders = _context.Orders.Include("PaymentType").Include("User").Where(o => o.UserID == id).ToList();
                    for (int i = 0; i < orders.Count; i++)
                    {
                        allOrders.Add(GetOrder(orders[i].ID.ToString()));
                    }
                }

                return allOrders;
            }
        }

        public OrderDTO GetOrder(string orderID)
        {
            using (OSContext _context = new OSContext())
            {
                Order order = _context.Orders.Include("PaymentType").Include("User").FirstOrDefault(o => o.ID == int.Parse(orderID));

                if (order == null)
                {
                    throw new WebFaultException<string>("Order Dosent Exist", HttpStatusCode.NotFound);
                }
                return convertToDTO(order);
            }
        }
        public string PlaceOrder(OrderDTO order)
        {
            using (OSContext _context = new OSContext())
            {
                Order newOrder = new Order()
                {
                    ReciverFullName = order.FullName,
                    Address = order.Address,
                    ZIPCode = order.Zip,
                    Country = order.Country,
                    City = order.City,
                    PaymentTypeID = order.paymentType.ID,
                    UserID = order.user.ID
                };


                User user = _context.Users.FirstOrDefault(u => u.ID == newOrder.UserID);

                if (user == null)
                {
                    throw new WebFaultException<string>("User Dosent Exist", HttpStatusCode.NotFound);
                }

                PaymentType Payment = _context.PaymentTypes.FirstOrDefault(p => p.ID == newOrder.PaymentTypeID);
                if (Payment == null)
                {
                    throw new WebFaultException<string>("Payment  Dosent Exist", HttpStatusCode.NotFound);
                }


                for (int i = 0; i < order.products.Count; i++)
                {
                    newOrder.TotalCost += _context.Items.FirstOrDefault(it => it.ID == order.products[i].Key).Cost * order.products[i].Value;
                }

                _context.Orders.Add(newOrder);


                for (int i = 0; i < order.products.Count; i++)
                {
                    OrderItem orderitem = new OrderItem()
                    {
                        OrderID = newOrder.ID,
                        ItemID = order.products[i].Key,
                        Quantity = order.products[i].Value
                    };
                    _context.OrderItems.Add(orderitem);
                }

                _context.SaveChanges();
                return "Order Added Successfully";
            }
        }
    }
}