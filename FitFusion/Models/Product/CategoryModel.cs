using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Product
{
    public class CategoryModel
    {
        //public int Id { get; set; }
        public string Name { get; set; }

        //public Category(string name)
        //{
        //    //Id = id;
        //    Name = name;
        //}

        public override string ToString()
        {
            return Name;
        }

    }   
}
