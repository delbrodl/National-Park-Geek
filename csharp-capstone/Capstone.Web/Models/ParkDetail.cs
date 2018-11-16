using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkDetail
    {
        public string ParkCode { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public int Acreage { get; set; }

        public int Elevation { get; set; }

        public double MilesOfTrail { get; set; }

        public int NumOfCampsites { get; set; }

        public string Climate { get; set; }

        public int YearFounded { get; set; }

        public int AnnualVisitors { get; set; }

        public string Quote { get; set; }

        public string QuoteSource { get; set; }

        public int EntryFee { get; set; }

        public int NumOfAnimalSpecies { get; set; }

    }
}
