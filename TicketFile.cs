using NLog.Web;
using System; 
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TicketSystem;

public class TicketFile {

    private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    private object scrubbedFile;
    private ulong ticketId;
    private string Type;
    private List<string> description;
    private string status;

    public TicketFile(object scrubbedFile)
    {
        this.scrubbedFile = scrubbedFile;
    }

    public string filePath {get; set;}
     public List<TicketSystem.Ticket> Tickets {get; set;}

     public TicketFile(string TicketFilePath, TicketFile ticket)
    {
        filePath = TicketFilePath;
        Tickets = new List<Ticket>();
        try
        {
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {

                string line = sr.ReadLine();

                int idx = line.IndexOf(",");

                TicketFile ticketFile = new TicketFile();
                if (idx == -1)
                {
                    string[] ticketDetails = line.Split(',');
                    ticketFile.ticketId = UInt64.Parse(ticketDetails[0]);
                    ticketFile.Type = ticketDetails[1];
                    List<string> list = ticketDetails[2].Split('|').ToList();
                    ticketFile.description = list;
                    ticketFile.status = ticketDetails[3];

                }
                else
                {
                    ticketFile.ticketId = UInt64.Parse(line.Substring(0, idx - 1));
                    line = line.Substring(idx);
                    idx = line.LastIndexOf(",");
                    ticketFile.Type = line.Substring(0, idx + 1);
                    line = line.Substring(idx + 2);
                    string[] details = line.Split(',');
                    ticketFile.description = details[0].Split('|').ToList();
                    ticketFile.status = details[1];

                }

                Tickets.Add(ticket);
            }
            sr.Close();

            logger.Info("tickets in file {count}", Tickets.Count);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }

    }
}
