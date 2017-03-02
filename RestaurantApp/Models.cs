using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    public class Restaurant
    {
        List<Table> t = new List<Table>();

        public List<Table> getTableList()
        {
            return t;
        }
        List<Table> setTable()
        {

            return t;
        }
    }

    public class Table
    {
       public int tableID { get; set; }
       public bool taken { get; set; }
       public int numberCapacity {get; set;}

        public Table(int tableID,bool taken, int numberCapacity)
        {
            this.tableID = tableID;
            this.taken = taken;
            this.numberCapacity = numberCapacity;
        }
    }
}
