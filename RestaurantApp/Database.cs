using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    static class DatabaseFactory
    {
        static IDatabase database;
        public static IDatabase getInstance() //Create one instance only. All Services will use that.
        {
            if (database == null)
                database = new simpleDatabase();

            return database;
        }
    }

    interface IDatabase
    {
        Restaurant getRestaurantData();
    }


    class simpleDatabase : IDatabase
    {
        public Restaurant getRestaurantData()
        {
            Restaurant r = new Restaurant();

            List<Table> tableList = r.getTableList();

            Table t1 = new Table(1, false, 3);
            Table t2 = new Table(2, false, 5);

            tableList.Add(t1);
            tableList.Add(t2);

            //Console.WriteLine(r.getTable()[1]);

            return r;
        }
    }
    /*
    class sqlDatabase : IDatabase
    {
        public Restaurant getData()
        {
            return new Restaurant();
        }
    }
    */
}
