using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Railway_Reservation_System.Reservation.Users_Data;
using Railway_Reservation_System.Reservation.Admin_Data;

namespace Railway_Reservation_System
{
   
    class Program
    {

        // Main Function
        static void Main(string[] args)
        {


            Console.WriteLine("\t\t\t\t\t(*Welcome to Indian Railway Reservation*)");
             Console.WriteLine("\t\t\t\t\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
          
             Console.WriteLine("Choose an option from Below:-");
             Console.WriteLine("-----------------------------\n");
             Console.WriteLine("=>(1): ADMIN_Section");
             Console.WriteLine("=>(2): USER_Section");
             Console.WriteLine("=>(3): EXIT_The_Application");
             Console.Write("Choice:> ");
             int Opt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=====================================================================================================>");
            

             switch(Opt)
             {
                 case 1:
                     Admin_Details.Admin_Logged();
                     break;
                 case 2:
                     Users_Details.User_Logged_Func();
                     break;
                 case 3:
                     Console.WriteLine("\t\t\t\tYou have been Logged Out from the application....");
                     break;
                 default:
                     Console.WriteLine("You Entered Wrong Input.....");
                     break;

             }
           
            
            Console.ReadLine();
        }
       
    }
}
