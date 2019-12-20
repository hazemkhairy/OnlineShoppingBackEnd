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
    public class CategoryBLL
    {
        OSContext _context;
        public CategoryBLL()
        {
            _context = new OSContext();
        }
        public List<CategoryDTO> GetAll()
        {
            List<Category> categories = _context.Categories.ToList();
            List<CategoryDTO> categoriesfinal = new List<CategoryDTO>();
            for(int i = 0; i < categories.Count; i++)
            {
                categoriesfinal.
                    Add(new CategoryDTO() { Name = categories[i].Name,ID = categories[i].ID});
            }
            return categoriesfinal;

        }
        public string Add(CategoryDTO category)
        {
            Category newcategory = new Category() { Name = category.Name};
            if(_context.Categories.FirstOrDefault(c => c.Name == newcategory.Name) !=  null)
            {
                throw new WebFaultException<string>("Category Already Exists", HttpStatusCode.Conflict);
            }
            _context.Categories.Add(newcategory);
            _context.SaveChanges();
            return "Category Added Successfully";
            
        }
    }
}