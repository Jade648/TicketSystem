
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
            return $"Id:{TicketId}/n summary: {Summary}/n status:{Status}/n priority: {Priority}/n submitter:{Submitter}/n assigned: {Assigned}/n watching: {Watching}";
        }
    }

    public class Bug : Ticket 
    {
        public string Severity {get; set;}

    }
}




        

   
