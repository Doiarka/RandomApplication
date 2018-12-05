using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using RandomApplications.Models;

namespace RandomApplications.Response
{
    /// <summary>
    /// модель представления списка заявок
    /// </summary>
    public class ApplicationsResponse
    {
        /// <summary>
        /// заявки
        /// </summary>
        public List<BaseApplication> Apps { get; set; }

        /// <summary>
        /// список статусов
        /// </summary>
        public IEnumerable<SelectListItem> Statuses = Enum.GetValues(typeof(Status)).Cast<Status>().Select(s =>
            new SelectListItem
            {
                Text = s.GetDisplayName(),
                Value = ((int)s).ToString(),
                Selected = false
            }).AsEnumerable();

        /// <summary>
        /// выбранный статус. по умолчанию - все
        /// </summary>
        public Status Status { get; set; } = Status.All;

        /// <summary>
        /// начало периода
        /// </summary>
        [Display(Name = "My Date:"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// окончание периода
        /// </summary>
        [Display(Name = "My Date:"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateTo { get; set; }
    }
}