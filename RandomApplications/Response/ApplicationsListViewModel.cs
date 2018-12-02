using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandomApplications.Models;

namespace RandomApplications.Response
{
    public class ApplicationsListViewModel
    {
        public IEnumerable<BaseApplication> Apps { get; set; }
        public Status? Status { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public SelectList statusList { get; set; }
    }
}