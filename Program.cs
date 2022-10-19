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

        //    String scrubbedFile = FileScrubber.ScrubTickets("Tickets.scrubbed.csv");

           logger.Info("Scrubbed file");

           BugTicketFile ticketFile = new BugTicketFile("Tickets.csv");
            
           
            logger.Info ("Program ended");
        }
    }
}
