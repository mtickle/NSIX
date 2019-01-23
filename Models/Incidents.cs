using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSIX.Models
{
    public class Incidents
    {
        private string OBJECTID { get; set; }
        private string globalID { get; set; }
        private string creationDate { get; set; }
        private string creator { get; set; }
        private string editDate { get; set; }
        private string editor { get; set; }
        private string case_number { get; set; }
        private string crime_category { get; set; }
        private string crime_code { get; set; }
        private string crime_description { get; set; }
        private string crime_type { get; set; }
        private string reported_block_address { get; set; }
        private string city_of_incident { get; set; }
        private string city { get; set; }
        private string district { get; set; }
        private string reported_date { get; set; }
        private string reported_year { get; set; }
        private string reported_month { get; set; }
        private string reported_day { get; set; }
        private string reported_hour { get; set; }
        private string reported_dayofwk { get; set; }
        private string latitude { get; set; }
        private string longitude { get; set; }
        private string agency { get; set; }
        private string updated_date { get; set; }
    }
}