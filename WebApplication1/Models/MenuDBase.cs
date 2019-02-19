using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MenuDBase
    {
        public List<Item> ItemList { get; set; } 
        
        

        public MenuDBase()
        {

        }
        public MenuDBase(Item newItem)
        {
            ItemList.Add(newItem);
        }

        public static implicit operator MenuDBase(List<Item> v)
        {
            throw new NotImplementedException();
        }
    }
}