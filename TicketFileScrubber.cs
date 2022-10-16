using System;
using System.IO;
using NLog.Web;
using System.Linq;

namespace TicketSystem
{
public static class FileScrubber{
    private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

    public static string description { get; private set; }

    public static string ScrubTickets(string readFile)
{
    try
    {
        string ext = readFile.Split(',').Last();
        string writeFile = readFile.Replace(ext,$"scrubbed.{ext}");
        if(File.Exists(writeFile))
        {
            logger.Info("File already scrubbed");

        }
        else
    {
        logger.Info("File scrub started");
        StreamWriter sw = new StreamWriter(writeFile);
        StreamReader sr = new StreamReader (readFile);
        sr.ReadLine();
         while(! sr.EndOfStream){
            var ticket = new Ticket();
            string line = sr.ReadLine();
            int idx = line.IndexOf('"');
            string tickets = "";
            if(idx == -1)
            {
                string []ticketDetails = line.Split(',');
                ticket.ticketId = UInt64.Parse(ticketDetails[0]);
                ticket.Type = ticketDetails[1];
                ticket.description = ticketDetails[2];
                ticket.status = ticketDetails[3];

            }
            else
         {
            ticket.ticketId= UInt64.Parse(line.Substring(0,idx -1));
            line = line.Substring(idx);
            idx = line.LastIndexOf('"');
            ticket.Type = line.Substring(0,idx +1);
            line = line.Substring (idx +2);
            string [] details = line.Split(',');
            description = details [0];

         }
         sw.WriteLine($"{ticket.ticketId},{ticket.Type},{ticket.description},{ticket.status}");
         
         }
         sw.Close();
         sr.Close();
         logger.Info("File scrub ended");
    }

    return writeFile;
}
catch (Exception ex)
{
    logger.Error(ex.Message);
}

return "";
}
}
}
