using NLog.Web;
using System; 
using System.Collections.Generic;
using System.IO;
using System.Linq;
public class TicketFile {

      private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    private object scrubbedFile;

    public TicketFile(object scrubbedFile)
    {
        this.scrubbedFile = scrubbedFile;
    }

    public string filePath {get; set;}

}
     
