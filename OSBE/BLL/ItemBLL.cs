using OSBE.Context;
using OSBE.DTOs;
using OSBE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;

namespace OSBE.BLL
{
    public class ItemBLL
    {
        public ItemBLL()
        {
        }
        public ItemDTO GetItem(int id)
        {
            using (var _context = new OSContext())
            {
                Item item = _context.Items.Include("Category").FirstOrDefault(i => i.ID == id);
                return new ItemDTO()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Cost = item.Cost,
                    Category = new CategoryDTO() { Name = item.Category.Name, ID = item.Category.ID },
                    Descripition = item.Descripition,
                    ImageURL = item.ImageURL,
                    CategoryID = item.CategoryID

                }; 
            }
        }
        public List<ItemDTO> GetItems(int categoryID)
        {
            using (var _context = new OSContext())
            {


                List<Item> itemsBeforeConvert;
                List<ItemDTO> items = new List<ItemDTO>();
                if (categoryID == 0)
                {
                    itemsBeforeConvert = _context.Items.Include("Category").ToList();
                }
                else
                {
                    itemsBeforeConvert =
                        _context.Items
                        .Include("Category")
                        .Where(i => i.CategoryID == categoryID).ToList();
                }
                foreach (Item item in itemsBeforeConvert)
                {
                    items.Add(
                        new ItemDTO() { 
                            ID = item.ID,
                            Cost=item.Cost,
                            Name=item.Name,
                            ImageURL=item.ImageURL,
                            Descripition=item.Descripition,
                            CategoryID=item.CategoryID,
                            Category=new CategoryDTO() { Name= item.Category.Name,ID=item.Category.ID }
                        }
                        );
                }
                return items;
            }
        }
        public string Add(ItemDTO item)
        {
            using (var _context = new OSContext())
            {
                Item item1;
                if (item.ID == 0)
                {
                    item1 = _context.Items.FirstOrDefault(i => i.Name == item.Name);
                    if (item1 != null)
                    {
                        throw new WebFaultException<string>("Item Already Exists", HttpStatusCode.Conflict);
                    }
                }
                Category category = _context.Categories.FirstOrDefault(c => c.ID == item.CategoryID);
                if (category == null)
                {
                    throw new WebFaultException<string>("Category Not Found", HttpStatusCode.Conflict);
                }
                item1 = new Item()
                {
                    ID = item.ID,
                    Name = item.Name,
                    CategoryID = item.CategoryID,
                    Cost = item.Cost,
                    Descripition = item.Descripition,
                    ImageURL = item.ImageURL,
                    NumberOfSold = 0,
                    Category = category
                };

                _context.Items.AddOrUpdate(item1);
                _context.SaveChanges();
                return "Item Added Succefuly";
            }
        }
        public string Delete(int itemID)
        {
            using (var _context = new OSContext())
            {
                Item item = _context.Items.FirstOrDefault(i => i.ID == itemID);
                if (item == null)
                {
                    throw new WebFaultException<string>("Item Not Exists", HttpStatusCode.Conflict);
                }
                _context.Items.Remove(item);
                _context.SaveChanges();
                return "Item Deleted"; 
            }
        }
    }
}