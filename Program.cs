using System;
using NLog.Web;
using System.IO;

namespace TicketSystem
{
    class Program
    {
    
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        private static int ticketId;
        private static string type;
        private static object description;
        private static object status;
        private static object ticket;

        public static object ScrubbedFile { get; private set; }

        static void Main(string[] args)
        {
            logger.Info("Program started");

           String scrubbedFile = FileScrubber.ScrubTickets("Tickets.scrubbed.csv");

           logger.Info("Scrubbed file");

           TicketFile ticketFile = new TicketFile(scrubbedFile);
           
           {
            ticketId = 100;
            type  = "Debug";
            description = "debugging application";
            status = "assigned";
           };   

           Console.WriteLine(ticket.Display());
           
            logger.Info ("Program ended");
        }
    }
}
