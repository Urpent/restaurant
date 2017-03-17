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

            Activity.Start(new MainActivity());
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


    
   
}
