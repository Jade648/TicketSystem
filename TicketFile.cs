using NLog.Web;
using System; 
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TicketSystem;

public class BugTicketFile {

    private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
     public Bug Ticket;
    private Bug bug;

    public List<Bug> Bugs {get;set;}
     public string filePath {get; set;}

     public BugTicketFile(string TicketFilePath)
    {
        filePath = TicketFilePath;
        
        try
        {
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {

                string line = sr.ReadLine();

                Bug bug = new Bug();
            
                string[] ticketDetails = line.Split(',');
                bug.TicketId = UInt64.Parse(ticketDetails[0]);
                bug.Summary = ticketDetails[1];
                bug.Status = ticketDetails[2];
                bug.Priority = ticketDetails[3];
                bug.Submitter = ticketDetails[4];
                bug.Assigned = ticketDetails[5];
                bug.Watching = ticketDetails[6].Split('|').ToList();
                bug.Severity = ticketDetails [7];

            }
                Bugs.Add(bug);

            sr.Close();

            logger.Info("tickets in file {count}", Bugs.Count);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }

    }
}

   