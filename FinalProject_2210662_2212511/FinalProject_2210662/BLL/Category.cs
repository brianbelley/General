using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_2210662.DAL;

namespace FinalProject_2210662.BLL
{
    public class Category
    {
        private int categoryId;
        private string categoryName;

        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }



        public bool Check_Existed_id(int id)
        {
            return CategoryDB.Duplicated_ID_validation(id);
        }

        public List<Category> GetAllCategories()
        {
            return CategoryDB.GetAllRecords();
        }



    }
}
