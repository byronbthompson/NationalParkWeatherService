using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public float MilesOfTrail { get; set; }
        public int NumberOfCampSites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public string ShortDescription
        {
            get
            {
                //Split description at '.'
                //If splitArray[0] length is at least 30 Char then return that string.
                //If not then add splitArr[1]
                return ParkDescription.Split('.')[0].Length > 30 ? 
                    ParkDescription.Split('.')[0] + '.': 
                    ParkDescription.Split('.')[0] + ParkDescription.Split('.')[1] + '.';
            } 
        }
        public int EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }

    }
}