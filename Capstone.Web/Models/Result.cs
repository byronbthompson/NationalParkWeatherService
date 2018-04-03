using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Result
    {
        public int VoteCount { get; set; }
        public string ParkName { get; set; }
        public string ParkCode { get; set; }
        public string InspirationalQuote { get; set; }
        public string QuoteSource { get; set; }
    }
}