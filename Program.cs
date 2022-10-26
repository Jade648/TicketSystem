using System;
using NLog.Web;
using System.IO;

namespace TicketSystem
{
    class Program
    {
    
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();


        static void Main(string[] args)
        {
            logger.Info("Program started");

           BugTicketFile ticketFile = new BugTicketFile("Tickets.csv");

           string choice = "";
           do{

            Console.WriteLine ("1)Add Ticket");
            Console.WriteLine("2) Display all Tickets");
            Console.WriteLine("Enter to quit");
             
             choice = Console.ReadLine();
             logger.Info("user choice: {choice}",choice);
           
          if (choice == "1")
          {

           Bug bug = new Bug(); 
           Console.WriteLine("Enter Ticket Id number");
          bug.TicketId = UInt64.Parse(Console.ReadLine());
          Console.WriteLine("Enter Ticket Summary");
          bug.Summary = Console.ReadLine();
          Console.WriteLine("Enter Ticket Status");
          bug.Status = Console.ReadLine();
          Console.WriteLine("Enter Ticket Priority");
          bug.Priority = Console.ReadLine();
          Console.WriteLine("Enter Ticket Sumbitter");
          bug.Submitter = Console.ReadLine();
          Console.WriteLine("Enter Ticket Assigned");
          bug.Assigned = Console.ReadLine();
          Console.WriteLine("Enter Ticket Watchers");

          }  

   }while (choice == "1" || choice == "2");

 logger.Info("Program ended");

}
}
}
