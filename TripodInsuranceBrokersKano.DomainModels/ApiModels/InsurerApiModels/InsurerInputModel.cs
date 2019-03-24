using System;
using System.Collections.Generic;
using System.Text;

namespace TripodInsuranceBrokersKano.DomainModels.ApiModels.InsurerApiModels
{
    public class InsurerInputModel
    {
        //Number of records per page
        public int PageSize { get; set; }

        //Total number of records in database
        public int TotalNumberOfInsurers { get; set; }

        //default current page when one isn't given and can serve as current page
        //which is settable
        public int CurrentPage { get; set; }

    }
}
