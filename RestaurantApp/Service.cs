using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    delegate bool IsTableAvailable(Table t);
    interface ITableService
    {
        Table GetAvailableTable( IsTableAvailable funcIsTableAvailable);
    }

   

    class TableService : ITableService
    {
        IDatabase database;

        public TableService()
        {
            database = DatabaseFactory.getInstance();
        }

        public Table GetAvailableTable(IsTableAvailable funcIsTableAvailable)
        {

            List<Table> tableList = database.getRestaurantData().getTableList();

            foreach(var table in tableList)
            {
                if (funcIsTableAvailable(table))
                    return table;
            }

            return null;
        }
    }
}
