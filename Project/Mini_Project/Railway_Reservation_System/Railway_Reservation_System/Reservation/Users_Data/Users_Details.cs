using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway_Reservation_System.Reservation.Users_Data;

namespace Railway_Reservation_System.Reservation.Users_Data
{

    class Users_Details
    {
        static Railway_ReservationEntities7 Rs = new Railway_ReservationEntities7();

       
        //User_Logged Function
        public static void User_Logged_Func()
        {
            Console.WriteLine("=> Enter (1) for Existing User");
            Console.WriteLine("=> Enter (2) for New User");
            Console.Write("Choice:> ");
            int User_Val = Convert.ToInt32(Console.ReadLine()+"\n\n");
            Console.WriteLine("=====================================================================================================>");
            user_details User_det = new user_details();
            switch (User_Val)
            {
                case 1:
                    Console.WriteLine("\t\t\t\t\t\t>>>Login Your Account<<<\n");
                    Console.Write("=>Enter Id: ");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("=>Enter UserName: ");
                    String User_n = Convert.ToString(Console.ReadLine());
                    Console.Write("=>Enter Password: ");
                    String Pass = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("\n");
                    var ud1 = Rs.user_details.FirstOrDefault(ut => ut.user_id == Id);
                    var ud2 = Rs.user_details.FirstOrDefault(ut1 => ut1.user_name == User_n);
                    var ud3 = Rs.user_details.FirstOrDefault(ut2 => ut2.password == Pass);

                    if (ud1 != null && ud2 != null && ud3 != null)
                    {
                        Console.WriteLine("\t\t\t\t**Welcome...You have Logged_in Successfully.**\n");
                        Console.Beep();
                       
                        Console.WriteLine("=====================================================================================================>");
                        Console.WriteLine("=>Press Tab/Enter To Access User portal...");
                        Console.ReadKey();
                        Console.Clear();
                       
                        Console.WriteLine("\t\t\t\t\t\t>>>...Welcome User...<<<");
                        
                        Console.WriteLine("*Choose an Option from below:");
                        Console.WriteLine("------------------------------\n");
                        Console.WriteLine("=>Enter (1) for Book_Ticket");
                        Console.WriteLine("=>Enter (2) for Cancel_Ticket");
                        Console.WriteLine("=>Enter (3) for Show_All_Train_Details");
                        Console.Write("Choice:> ");
                        int Bcs = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("=====================================================================================================>");
                      

                        switch (Bcs)
                        {
                            case 1:
                                Seat_Availability();
                                Console.Write("Enter the no. of Ticket.....(Min:1/Max:4): ");
                                int va1 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("=====================================================================================================>");
                                Console.WriteLine("\t\t\t\t\t\t>>>Book Your Ticket<<<");
                                for (int i = 1; i <= va1; i++)
                                {
                                    Console.WriteLine($"{i}=>");
                                    Book_Ticket();
                                    
                                   
                                }
                              //  Rs.setseatavl(Id, Cls, va1);
                                break;

                            case 2:
                                Cancel_Ticket();
                                break;

                            case 3:
                                Show_TrainDet();
                                break;

                            default:
                                Console.WriteLine("Invalid Input..");
                                break;
                        }

                    }
                    else
                    {
                       
                        Console.Write("(Error): This account doesn't Exist... To login Again press=>(*) and Enter ");
                        Console.WriteLine("Or press=>(@) for Create your Account");
                        Console.Write("Choice:> ");
                        string New_u_or_Ext = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("=====================================================================================================>");

                        switch (New_u_or_Ext)
                        {
                            case "*":
                                Console.WriteLine("\n");
                                Process_Ag();
                                break;

                            case "@":
                                New_User();
                                Console.WriteLine("\n");
                                Console.WriteLine("=====================================================================================================>");
                                
                                Process_Ag();
                                break;
                            default:
                                Console.WriteLine("Invalid Input...");
                                break;
                        }
                    }
                    break;

                case 2:
                    New_User();
                    Console.WriteLine("=====================================================================================================>");
                    Process_Ag();
                    break;

                default:
                    Console.WriteLine("Invalid Input...");
                    break;
            }


        }



        //Show all Train Details
        public static void Show_TrainDet()
        {
            Console.WriteLine("\t\t\t\t\t\t*Train Details*\n\n");
            var Show = Rs.Trains_Detail;
            int i = 1;

            foreach (var A in Show)
            {
                if (A.Active_or_Not == true)
                {
                    Console.WriteLine($"{i}=>");
                    Console.WriteLine($"Train_Id: {A.Train_id}");
                    Console.WriteLine($"Train_Name: {A.Train_name}");
                    Console.WriteLine($"Departure City: {A.Depart_city}");
                    Console.WriteLine($"Arrival City: {A.Arrival_city}");
                    Console.WriteLine($"Status: {A.Active_or_Not}");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>\n");

                    i = i + 1;
                }
                

            }


        }
       
        
        //Seat Availability
        public static void Seat_Availability()
        {
            Seat_Availability Sa = new Seat_Availability();
            var SD = Rs.Seat_Availability;
            Console.Write("Enter Train_id to Get Available Seat_Details: ");
            int Ids1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");
            var Tr_Det = Rs.Seat_Availability.FirstOrDefault(tr => tr.Train_id == Ids1);
            if (Tr_Det != null)
            {
                foreach (var x in SD)
                {
                    if (x.Train_id == Ids1)
                    {
                        Console.Write($"=>(*)Trip_Id:- {x.Seat_id}\t(*)Train_Id:- {x.Train_id}\t(*)1AC Avl_Seats:- {x.C1AC}\t(*)2AC Avl_Seats:- {x.C2AC}\t(*)3AC Avl_Seats:- {x.C3AC}\n");
                     
                        Console.Write("=====================================================================================================>\n");


                    }
                    
                }
               
            }
            else
            {
                Console.WriteLine($"\n(Error): Train with Id {Ids1} is not running in Platform so You can not get the Info. about this...");
                Console.WriteLine("To continue..fill all detail with Train_Id...");
                
               

            }
        }





        // Ticket Booking
        public static void Book_Ticket()
        {
                   
                    
                    Book_Ticket Bt = new Book_Ticket();
                    Console.Write("Enter Your Name: ");
                    string Name = Convert.ToString(Console.ReadLine() + "\n");
                    Console.Write("Enter Your Age: ");
                    int Age = Convert.ToInt32(Console.ReadLine() + "\n");
                    Console.Write("Enter Gender: ");
                    string Gn = Console.ReadLine() + "\n";
                    Console.Write("Enter Train_Id(No.) for Ticket Booking: ");
                    int Id = Convert.ToInt32(Console.ReadLine() + "\n");


                    Random Rn = new Random();


                    Console.Write("Enter Class(1AC/2AC/3AC): ");
                    String Cls = Console.ReadLine();
                    Console.WriteLine($"Captcha=>{Rn.Next(50, 800)}");

                    Console.Write("Enter the Given Captcha to Confirm The Ticket: ");
                    int Rnd = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    int T_id = Rnd + 61 + Age;
                    var Booked = Rs.Trains_Detail.FirstOrDefault(Bid => Bid.Train_id == Id);
                
                    if (Booked != null)
                    {
                        if (Booked.Active_or_Not == true)
                        {
                            Bt.Ticket_no = T_id;
                            Bt.Train_id = Id;
                            Bt.Name = Name;
                            Bt.Age = Age;
                            Bt.Gender = Gn;
                            Bt.Class = Cls;
                            Rs.Book_Ticket.Add(Bt);
                            Rs.SaveChanges();
                            Console.WriteLine("\t\t\t\t\t\t**Your Ticket is Booked..**");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~>");
                            Rs.setseatavl(Id, Cls);

                            Random r2 = new Random();

                            var fair = Rs.Fair_S;
                            Fair_S fs = new Fair_S();
                            Console.WriteLine("\t\t\t\t\t\t>>>Ticket Detail<<<\n");
                            Console.WriteLine($"Name: {Name}Age: {Age} ");
                            Console.WriteLine($"Gender: {Gn}Train_Id: {Id}");
                            foreach (var f in fair)
                            {
                                if (f.Train_id == Id)
                                {
                                    if (Cls == "1AC" || Cls == "1Ac" || Cls == "1ac")
                                    {
                                        Console.WriteLine($"Ticket_Price: {f.C1AC}");
                                    }
                                    if (Cls == "2AC" || Cls == "2Ac" || Cls == "2ac")
                                    {
                                        Console.WriteLine($"Ticket_Price: {f.C2AC}");
                                    }
                                    if (Cls == "3AC" || Cls == "3Ac" || Cls == "3ac")
                                    {
                                        Console.WriteLine($"Ticket_Price: {f.C3AC}");
                                    }
                                }
                            }
                            Console.WriteLine($"PNR No. {r2.Next(23224, 90256)}");
                            Console.WriteLine("=====================================================================================================>");
                    }
                        else
                        {
                            Console.WriteLine("=>This train is Not Active Currently..Sorry for inconvenience.");
                        }

                    }

                    else
                    {
                        Console.WriteLine("\n\n\t\t\t\tTrain is not Running.. So you Can't book Ticket for This..");



                    }
               
        }


        


        //Ticket Cancelling
        public static void Cancel_Ticket()
        {
            Console.WriteLine("\t\t\t\t\t\t*Booked Ticket Details*");
            var Show_Tkt = Rs.Book_Ticket.ToList();
            int i = 1;
            foreach (var A in Show_Tkt)
            {
               
                    Console.WriteLine($"({i})=>");
                    Console.WriteLine($"Ticket_No: {A.Ticket_no}");
                    Console.WriteLine($"Train_Id: {A.Train_id}");
                    Console.Write($"Name: {A.Name}");
                    Console.WriteLine($"Age: {A.Age}");
                    Console.Write($"Gender: {A.Gender}");
                    Console.WriteLine($"Class: {A.Class}");
                    i++;
                    
                
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>");
            }

            Book_Ticket bt1 = new Book_Ticket();
            Cancel_Ticket ct1 = new Cancel_Ticket();
            Console.WriteLine("\t\t\t\t\t\t*Cancel Your Ticket*\n\n");
            Console.Write("Enter Train Id: ");
            int Id1 = Convert.ToInt32(Console.ReadLine() + "\n");
            Console.Write("Enter your Ticket_no: ");
            int Tn_1= Convert.ToInt32(Console.ReadLine() + "\n");
            Random Rn = new Random();
            int a = Rn.Next(6300,9999);
            String st = "Canceled";
        

            var C_Ticket = Rs.Book_Ticket.FirstOrDefault(Cd => Cd.Ticket_no == Tn_1);
            var C_Ticket1 = Rs.Book_Ticket.FirstOrDefault(Cd1 => Cd1.Train_id ==Id1);
            var C_Ticket2 = Rs.Book_Ticket.Where(cd2 => cd2.Ticket_no == Tn_1).Select(t => t.Class).FirstOrDefault();
            

            if( C_Ticket1 != null && C_Ticket != null)
            {
                ct1.Cancelation_Id = a;
                ct1.Ticket_no = Tn_1;
                ct1.Train_id = Id1;
                ct1.Status = st;
             
                Rs.Cancel_Ticket.Add(ct1);
                Rs.Book_Ticket.Remove(C_Ticket1);
                Console.WriteLine("\t\t\t\t**Your Ticket has been Canceled successfully.**\n");
                Rs.SaveChanges();
                
                Rs.setseatavl1(Id1, C_Ticket2);
            }
            else
            {
                Console.Write("(Error)=>You have entered wrong Ticket_no. or Train_Id.....");
            }
        }

        
 
        //Exit
         public static void Exit()
        {
            Console.WriteLine("\t\t\t\t\t**You have been LoggedOut from the Application**\n");
        }


        //New User
        static void New_User()
        {
            user_details ut = new user_details();
            Console.WriteLine("\t\t\t\t\t\tCreate Your Account...\n");
            Console.Write("Enter User_id: ");
            ut.user_id = int.Parse(Console.ReadLine());

            Console.Write("Enter User_Name.: ");
            ut.user_name = Console.ReadLine();
            
            Console.Write("Enter new Password: ");
            ut.password= Console.ReadLine();
            
            Rs.user_details.Add(ut);
            Rs.SaveChanges();
            Console.WriteLine("\t\t\t\t**Your Account is Created Successfully..**");
           
        }


        //For process Again
        public static void Process_Ag()
        {
            Console.WriteLine("\t\t\t\t\t\tLogin Your Account...\n");
            Console.Write("Enter Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter UserName: ");
            String User_n = Convert.ToString(Console.ReadLine());
            Console.Write("Enter Password: ");
            String Pass = Convert.ToString(Console.ReadLine());
            var ud1 = Rs.user_details.FirstOrDefault(ut => ut.user_id == Id);
            var ud2 = Rs.user_details.FirstOrDefault(ut1 => ut1.user_name == User_n);
            var ud3 = Rs.user_details.FirstOrDefault(ut2 => ut2.password == Pass);
            

            if (ud1 != null && ud2 != null && ud3 != null)
            {
                Console.WriteLine("\t\t\t\t**Your account has been LoggedIn succesfully..**");
                Console.WriteLine("=====================================================================================================>");
                Console.WriteLine("=>Press Tab/Enter To Access User portal...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t>>>...Welcome User...<<<");
                Console.WriteLine("*Choose an Option from below:");
                Console.WriteLine("------------------------------\n");
                Console.WriteLine("=>Enter (1) Book_Ticket");
                Console.WriteLine("=>Enter (2) Cancel_Ticket");
                Console.WriteLine("=>Enter (3) Show_All_Train_Details");
                Console.Write("Choice:> ");
                int Bcs = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");
                Console.WriteLine("=====================================================================================================>");
                

                switch (Bcs)
                {
                    case 1:
                        Seat_Availability();
                        Console.Write("Enter the no. of Ticket.....(Min:1/Max:4): ");
                        int va1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("=====================================================================================================>");
                        Console.WriteLine("\t\t\t\t\t\t>>>Book Your Ticket<<<\n");
                        for (int i = 1; i <= va1; i++)
                        {
                            Console.WriteLine($"{i}=>");
                            Book_Ticket();
                            Console.WriteLine("-------------------------");
                        }
                        break;

                    case 2:
                        Cancel_Ticket();
                        break;

                    case 3:
                        Show_TrainDet();
                        break;

                    default:
                        Console.WriteLine("Invalid Input..");
                        break;
                }
            }
            else
            {
                Console.Write("(Error): This account doesn't Exist... To login Again press (*) and Enter");
                Console.WriteLine("=> Or press (@) for Create your Account");
                string New_u_or_Ext = Convert.ToString(Console.ReadLine());

                switch (New_u_or_Ext)
                {
                    case "*":
                        Process_Ag();
                        break;

                    case "@":
                        New_User();
                        Process_Ag();
                        break;
                    default:
                        Console.WriteLine("Invalid Input...");
                        break;
                }
            }
        }
    }
}
