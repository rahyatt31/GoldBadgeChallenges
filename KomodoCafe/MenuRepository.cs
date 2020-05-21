using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{   // CRUD                                                         // Don't need to "UPDATE"
    public class MenuRepository
    {
        private List<Menu> _menuItemList = new List<Menu>();

        public void AddToMenuList(Menu item)                        // CREATE
        {
            _menuItemList.Add(item);                                // Adding something to our List through menuList
            //bool mealWasAdded = _menuItemList.Count == +1;        // Add 1 to count after adding to content directory                                 
            //return mealWasAdded;
        }

        public List<Menu> ViewMenuList()                            // READ
        {
            return _menuItemList;
        }

        public Menu ViewMenuListByMealName(string mealName)         // READ
        {
            foreach (Menu order in _menuItemList)
            {
                if (order.MealName.ToLower() == mealName.ToLower())
                {
                    return order;
                }
            }
            return null;
        }

        public bool RemoveFromMenuList(string mealName)             // Remove
        {
            Menu order = ViewMenuListByMealName(mealName);

            if (order == null)
            {
                return false;
            }
            else
            {
                _menuItemList.Remove(order);
                    return true;
            }
        }
    }
}
