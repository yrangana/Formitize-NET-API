using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Formitize.API.Response
{
    public class JobGetEntry
    {
        [DataMember(Name = "id")]
        public int JobID
        {
            get; set;
        }

        [DataMember(Name = "maintenanceID")]
        public int MaintenanceID
        {
            get; set;
        }

        [DataMember(Name = "jobNumber")]
        public String JobNumber
        {
            get; set;
        }

        [DataMember(Name = "orderNumber")]
        public String OrderNumber
        {
            get; set;
        }

        [DataMember(Name = "title")]
        public String Title
        {
            get; set;
        }

        [DataMember(Name = "location")]
        public String Location
        {
            get; set;
        }

        [DataMember(Name = "assignedTo")]
        public String AssignedTo
        {
            get; set;
        }


    }
}
