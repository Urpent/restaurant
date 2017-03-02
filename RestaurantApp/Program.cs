using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase d = DatabaseFactory.getInstance();
            Restaurant r = d.getRestaurantData();

            IActivity v = new MainActivity();

            while (true)
            {
                try
                {
                    v = v.execute() as IActivity;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                    Console.Read();
                    return;
                }

                if (v is ExitActivity)
                {
                    Console.WriteLine("Exiting...");
                    Console.Read();
                    break;
                }
            }

        }
    }

    public static class UserInput
    {
        /// <summary>
        /// Minimum is 1 and Maximum is inclusive.
        /// </summary>
        public static int getChoice(int maxChoice) //start from 1
        {
            int number;

            while (( number = getChoice()) < 1 || number > maxChoice) { };

            return number;
        }
        private static int getChoice()
        {
            int number;
            while (!Int32.TryParse(Console.ReadLine(), out number)) { }
            return number;
        }
    }


    public interface IActivity
    {
        IActivity execute();
    }

    public class MainActivity : IActivity
    {
        public IActivity execute()
        {
            Console.WriteLine("1. Check Table Vacancy");
            Console.WriteLine("2. Order Food");
            Console.WriteLine("3. Exit");

            int choice = UserInput.getChoice(3) ;
  
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
    public class TableActivity : IActivity
    {
        ITableService tableService;

        public TableActivity()
        {
            tableService = new TableService();
        }

        public IActivity execute()
        {
            Console.WriteLine("\n***Table***\n");
            Console.WriteLine("Enter Number of customer:");

            int numberOfCustomer = UserInput.getChoice(8);

            Table t = tableService.GetAvailableTable(table => 
                                                        table.numberCapacity >= numberOfCustomer &&
                                                        table.taken == false);

            if(t == null)
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
    public class FoodActivity : IActivity
    {
        public IActivity execute()
        {
            Console.WriteLine("\n***Food***");
            Console.WriteLine("End of Food.\n");
            return new MainActivity(); ;
        }
    }
    public class ExitActivity : IActivity
    {
        public IActivity execute()
        {
            Console.WriteLine("Exiting");
            return null;
        }
    }

   
}
