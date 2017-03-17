using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    public abstract class Activity
    {
        abstract public Activity execute();

        static public void Start(Activity current)
        {
            while (true)
            {
                try
                {
                    current = current.execute() as Activity;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Activity current cannot be null:", ex);
                }

                if (current is ExitActivity)
                {
                    Console.WriteLine("Exiting...");
                    Console.Read();
                    break; //Exit loop to exit program
                }
            }
        }

    }

    public class MainActivity : Activity
    {
        override public Activity execute()
        {
            Console.WriteLine("1. Check Table Vacancy");
            Console.WriteLine("2. Order Food");
            Console.WriteLine("3. Exit");

            int choice = UserInput.getChoice(3);

            switch (choice)
            {
                case 1:
                    return new TableActivity();
                case 2:
                    return new FoodActivity();
                case 3:
                    return new ExitActivity();

                default: return null;

            }

        }
    }
    public class TableActivity : Activity
    {
        ITableService tableService;

        public TableActivity()
        {
            tableService = new TableService();
        }

        override public Activity execute()
        {
            Console.WriteLine("\n***Table***\n");
            Console.WriteLine("Enter Number of customer:");

            int numberOfCustomer = UserInput.getChoice(8);

            Table t = tableService.GetAvailableTable(table =>
                                                        table.numberCapacity >= numberOfCustomer &&
                                                        table.taken == false);

            if (t == null)
            {
                Console.WriteLine("No Available Table.\n");
            }
            else
            {
                Console.WriteLine("Table " + t.tableID + " is available.\n");
            }

            return new MainActivity();
        }
    }
    public class FoodActivity : Activity
    {
        override public Activity execute()
        {
            Console.WriteLine("\n***Food***");
            Console.WriteLine("End of Food.\n");
            return new MainActivity(); ;
        }
    }
    public class ExitActivity : Activity
    {
        override public Activity execute()
        {
            Console.WriteLine("Exiting");
            return null;
        }
    }

}
