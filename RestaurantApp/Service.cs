using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    interface ITableService
    {
        Table GetAvailableTable(Func<Table, bool> funcIsTableAvailable);
    }

   

    class TableService : ITableService
    {
        IDatabase database;

        public TableService()
        {
            database = DatabaseFactory.getInstance();
        }

        public Table GetAvailableTable(Func<Table,bool> funcIsTableAvailable)
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
