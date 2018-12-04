using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandomApplications.Models;

namespace RandomApplications.Response
{
    public class ApplicationsListViewModel
    {
        public List<BaseApplication> Apps { get; set; }

        public IEnumerable<SelectListItem> Statuses = Enum.GetValues(typeof(Status)).Cast<Status>().Select(s =>
            new SelectListItem
            {
                Text = s.ToString(),
                Value = ((int)s).ToString(),
                Selected = false
            }).AsEnumerable();

        public Status Status { get; set; } = Status.All;

        [Display(Name = "My Date:"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "My Date:"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateTo { get; set; }
    }
}