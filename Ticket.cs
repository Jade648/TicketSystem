
using System;
using System.Collections.Generic;

namespace TicketSystem
{

    public abstract class Ticket 
    {
        public UInt64 TicketId {get; set;}
        public string Summary {get; set;}

        public string Status{get; set;}

        public string Priority{get; set;} 

        public string Submitter {get; set;}

        public string Assigned {get; set;}

        public List<string> Watching {get; set;}

        public virtual string Display()
    {
            return $"Id:{TicketId}/nstatus:{Status}/n";
        }
    }

    public class Bug : Ticket 
    {
        public string Severity {get; set;}

    }
    //     public string description;
    //     public string status;
    
    //     public Ticket()
    //     {
    //         List<string> list = new List<string>();
           
    //     }

    //     public string Type { get; internal set; }

    //        public virtual string Display()
    // {
    //         return $"Id:{ticketId}/ntype:{type}/ndescription:{description}/nstatus:{string.Join(",",status)}/n";
    //     }

    //        public class Task
    // {

    //             public UInt64 ticketId {get; set;}

    //     public string type {get; set;}

    //     public string description {get; set;}

    //     public string status {get; set;}

    //     public string ProjectName {get; set;}

    //     public string DueDate {get; set;}

    //     }   

    //          public class Enhancement
    // {

    //     public UInt64 ticketId {get; set;}
    //     public string type {get; set;}

    //     public string description {get; set;}

    //     public string status {get; set;}

    //     public string reason {get; set;}

    // }
    
    //     }
    }





        

   
