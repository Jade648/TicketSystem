using System;
using NLog.Web;
using System.IO;

namespace TicketSystem
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public static object ScrubbedFile { get; private set; }

        static void Main(string[] args)
        {
            logger.Info("Program started");

           String scrubbedFile = FileScrubber.ScrubTickets("Tickets.csv");

           logger.Info("Scrubbed file");

           TicketFile ticketFile = new TicketFile(ScrubbedFile);

            logger.Info ("Program ended");
        }
    }
}
