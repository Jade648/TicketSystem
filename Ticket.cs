
using System;
using System.Collections.Generic;

namespace TicketSystem
{

    public abstract class Ticket 
    {
        public UInt64 ticketId;
        public string type;
        public string description;
        public string status;
        private object ProjectName;
        private object[] DueDate;

        public Ticket()
        {
            List<string> list = new List<string>();
           
        }

        public string Type { get; internal set; }

        public virtual string Display(object ticketId, object type, object description, object[] status)
    {
            return $"Id:{ticketId}/ntype:{type}/ndescription:{description}/nstatus:{string.Join(",",status)}/n";
        }

         public class Enhancement
    {

        public UInt64 ticketId {get; set;}
        public string type {get; set;}

        public string description {get; set;}

        public string status {get; set;}

        public string reason {get; set;}

    }

        public override string Display()
        {
            return $"Id: {ticketId}/n type: {type}/n description: {description}/n reason: {reason}/n status: {string.Join(",", status)}/n";
        }

        public class Task
    {
        public UInt64 ticketId {get; set;}

        public string type {get; set;}

        public string description {get; set;}

        public string status {get; set;}

        public string ProjectName {get; set;}

        public string DueDate {get; set;}

    }
    }
}




        

   
