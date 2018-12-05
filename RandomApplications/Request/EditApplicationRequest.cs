using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RandomApplications.Models;

namespace RandomApplications.Request
{
    /// <summary>
    /// модель изменения заявки
    /// </summary>
    public class EditApplicationRequest
    {
        /// <summary>
        /// ид заявки
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// название
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// комментарий
        /// </summary>
        [Required]
        public string Comment { get; set; }

        /// <summary>
        /// старый статус
        /// </summary>
        public Status StatusOld { get; set; }

        /// <summary>
        /// новый статус
        /// </summary>
        public Status StatusNew { get; set; }

        /// <summary>
        /// список ид истории изменения заявки
        /// </summary>
        public List<BaseHistory> Histories { get; set; } = new List<BaseHistory>();
    }
}