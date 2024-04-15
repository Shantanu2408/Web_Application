using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway_Reservation_System.Reservation.Users_Data;

namespace Railway_Reservation_System.Reservation.Admin_Data
{
    class Admin_Details
    {
        static Railway_ReservationEntities7 Rs = new Railway_ReservationEntities7();



        public static int num;

        //Admin Login Process
        public static void Admin_Logged()
        {
            Console.WriteLine("\t\t\t\t\t\t*Admin LogIn*\n");
            Console.Write("Enter Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter UserName: ");
            String User_n = Convert.ToString(Console.ReadLine());
            Console.Write("Enter Password: ");
            String Pass = Convert.ToString(Console.ReadLine());
           
           
            var Admin_Auth = Rs.Admin_Detail.FirstOrDefault(At => At.Admin_id == Id);
            var Admin_Auth1 = Rs.Admin_Detail.FirstOrDefault(At1 => At1.Admin_userName == User_n);
            var Admin_Auth2 = Rs.Admin_Detail.FirstOrDefault(At2 => At2.Admin_pass == Pass);
           
            if (Admin_Auth != null && Admin_Auth1 != null && Admin_Auth2 != null)
            {
                Console.WriteLine("\t\t\t\t\t  **LoggedIn Successfully**");
                Console.WriteLine("=====================================================================================================>");
                  
                
                Console.Beep();
                Console.WriteLine("=>Press Tab/Enter To Access Admin portal...");
                Console.ReadKey();
                Console.Clear();
                
                Console.Write("\t\t\t\t\t\t>>>...Welcome Admin...<<<\n");


                Details();
                Admin_Change();
            }
            else
            {
                Console.WriteLine("\n\t\t=>(Error)Wrong Admin Detail...To Login Again press (*) and Enter or press (@) for exit..\n");
                Console.Write("Choice:> ");
                char ad = Convert.ToChar(Console.ReadLine());
                switch (ad)
                {
                    case '*':
                        Console.WriteLine("=====================================================================================================>");
                        Admin_Logged();
                        break;

                    case '@':
                        Console.WriteLine("\t\t\t\tYou have been Logged Out from the application....");
                        break;

                    default:
                        Console.WriteLine("Invalid Input.........");
                        break;
                }

            }
        }

        //Key value which will be taken from the users.....
        public static void Details()
        {
            Console.WriteLine("*Choose an Option from below:");
            Console.WriteLine("------------------------------\n");
            Console.WriteLine("=> Enter (1) for Add_Train");
            Console.WriteLine("=> Enter (2) for Modify_Train");
            Console.WriteLine("=> Enter (3) for Deactivate_Train");
            Console.WriteLine("=> Enter (4) for Activate_Train");
            Console.WriteLine("=> Enter (5) for all Train_Details");
            Console.Write("Choice:> ");
            num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=====================================================================================================>");
        }



        // Delete, Modify and Add Train...........
        public static void Admin_Change()
        {
            switch (num)
            {
                //Add
                case 1:
                    Console.Write("\t\t\t\t**Welcome...You are Authorized to Add a Train**\n");
                   
                    Console.Write("Enter Train No: ");
                    int IDCnm = int.Parse(Console.ReadLine());
                    Add_Train(IDCnm);
                    break;



                //Modify
                case 2:
                    Console.Write("\nEnter Train id, which you want to Modify: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var Train_Av = Rs.Trains_Detail.FirstOrDefault(m => m.Train_id == id);
                    if (Train_Av != null)
                    {
                        Console.WriteLine($"\t\t\t\t\tModifying details for Train {id}:\n");

                        Console.Write("Enter Updated Train Name: ");
                        Train_Av.Train_name = Console.ReadLine();

                        Console.Write("Enter Updated Departure City: ");
                        Train_Av.Depart_city = Console.ReadLine();

                        Console.Write("Enter Updated Arrival City: ");
                        Train_Av.Arrival_city = Console.ReadLine();

                        Rs.SaveChanges();
                        Console.WriteLine($"\n\n\t\t\t\t**Train_no. {id} details is updated in the Railway Database**");
                    }
                    else
                    {
                        Console.WriteLine($"Train_no. {id} does not exist.");
                    }


                    break;
                //Delete
                case 3:
                    Console.Write("Enter Train_no(Id) you want to Deactivate: ");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    Trains_Detail trt = new Trains_Detail();
                    var DeAct_Train = Rs.Trains_Detail.FirstOrDefault(t => t.Train_id == Id);
                    if (DeAct_Train != null)
                    {
                        if (DeAct_Train.Active_or_Not == true)
                        {
                            DeAct_Train.Active_or_Not = false;
                            Rs.SaveChanges();
                            Console.WriteLine($"\n=>Train_no {Id} has been de_Activated for Passengers.");
                        }
                        else
                        {
                            Console.WriteLine($"\n=>Train_no {Id} is already De_Activated...");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Train_no {Id} does not exist. So you can't de_Activate...");
                    }

                    break;

                case 4:
                    Console.Write("Enter Train_no(Id) you want to Activate: ");
                    int Id1 = Convert.ToInt32(Console.ReadLine());
                    Trains_Detail trt1 = new Trains_Detail();
                    var DeAct_Train1 = Rs.Trains_Detail.FirstOrDefault(t => t.Train_id == Id1);
                    if (DeAct_Train1 != null)
                    {
                        if (DeAct_Train1.Active_or_Not == false)
                        {
                            DeAct_Train1.Active_or_Not = true;
                            Rs.SaveChanges();
                            Console.WriteLine($"\n=>Train_no {Id1} has been Activated for Passengers.");
                        }
                        else
                        {
                            Console.WriteLine($"\n=>Train_no {Id1} is already Activated...");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\n=>Train_no {Id1} does not exist. So you can't Activate...");
                    }
                    break;

                case 5:
                    S_Train();
                    break;

                default:
                    Console.WriteLine("Invalid Input........");
                    break;
            }
        }

        //Admin Function
        public static void S_Train()
        {



            Console.WriteLine("\t\t\t\t\t\t*Train Details*\n\n");
            var Show = Rs.Trains_Detail;
            int i = 1;

            foreach (var A in Show)
            {

                Console.WriteLine($"{i}=>");
                Console.WriteLine($"Train_Id: {A.Train_id}");
                Console.WriteLine($"Train_Name: {A.Train_name}");
                Console.WriteLine($"Departure City: {A.Depart_city}");
                Console.WriteLine($"Arrival City: {A.Arrival_city}");
                Console.WriteLine($"Status: {A.Active_or_Not}");
                Console.WriteLine("--------------------------------\n");

                i = i + 1;

            }
        }


        public static void Add_Train(int trainId)
        {
            Trains_Detail newTrain = new Trains_Detail();

            var existingTrain = Rs.Trains_Detail.FirstOrDefault(train => train.Train_id == trainId);

            if (existingTrain == null)
            {
                newTrain.Train_id = trainId;
                Console.Write("Enter Train Name: ");
                newTrain.Train_name = Console.ReadLine();
                Console.Write("Enter The Departure City: ");
                newTrain.Depart_city = Console.ReadLine();
                Console.Write("Enter Arrival City: ");
                newTrain.Arrival_city = Console.ReadLine();


                Rs.Trains_Detail.Add(newTrain);
                Rs.SaveChanges();
                Console.Write("Enter No. of Seats of 1AC: ");
                int fac = int.Parse(Console.ReadLine());
                Console.Write("Enter No. of Seats of 1AC: ");
                int sac = int.Parse(Console.ReadLine());
                Console.Write("Enter No. of Seats of 1AC: ");
                int tac = int.Parse(Console.ReadLine());
                Rs.Add_Seat(trainId, fac, sac, tac);
                Console.Write("Enter the price of 1AC Ticket: ");
                int facf = int.Parse(Console.ReadLine());
                Console.Write("Enter the price of 2AC Ticket: ");
                int sacf = int.Parse(Console.ReadLine());
                Console.Write("Enter the price of 3AC Ticket: ");
                int tacf = int.Parse(Console.ReadLine());
                Rs.Add_Fair(trainId, facf, sacf, tacf);

                Console.WriteLine("\n\n\t\t\t\t**Train has been Added to the Railway Database.**");

                // After adding the train, call methods to add seat details and fair details
                //Add_SeatDet(trainId);
                //Add_FairDet(trainId);
            }
            else
            {
                Console.WriteLine($"Train no. {trainId} is already running. Press (*) to add another or (3) to exit.");
                Console.Write("Choice:> ");
                string choice = Console.ReadLine();
                Console.WriteLine("\n");
                switch (choice)
                {
                    case "*":
                        Add_Train(trainId);
                        break;
                    case "3":
                        Console.WriteLine("You have been Logged out from the Admin Section.");
                        break;
                }
            }
        }

        public static void Add_SeatDet()
        {
            int trainId = 98780;
            Seat_Availability St = new Seat_Availability();

            var ExSeat = Rs.Trains_Detail.FirstOrDefault(seat => seat.Train_id == trainId);

            //if (ExSeat == null)
            //{
                St.Train_id = trainId;
                St.Seat_id = 7;
                Console.Write("Enter 1AC Total Berths: ");
                St.C1AC = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter 2AC Total Berths: ");
                St.C2AC = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter 3AC Total Berths: ");
                St.C3AC = Convert.ToInt32(Console.ReadLine());

                Rs.Seat_Availability.Add(St);
                Rs.SaveChanges();
           // }
        }

        public static void Add_FairDet(int trainId)
        {
            Fair_S Fr = new Fair_S();
            var FEx = Rs.Fair_S.FirstOrDefault(fs => fs.Train_id == trainId);
            if (FEx == null)
            {
                Fr.Train_id = trainId;
                Console.Write("Enter 1AC Berth Price: ");
                Fr.C1AC = int.Parse(Console.ReadLine());
                Console.Write("Enter 2AC Berth Price: ");
                Fr.C2AC = int.Parse(Console.ReadLine());
                Console.Write("Enter 3AC Berth Price: ");
                Fr.C3AC = int.Parse(Console.ReadLine());

                Rs.Fair_S.Add(Fr);
                Rs.SaveChanges();
            }
        }

    }
}
