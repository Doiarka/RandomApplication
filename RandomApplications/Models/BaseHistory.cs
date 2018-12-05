using System;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;

namespace RandomApplications.Models
{
    /// <summary>
    /// сущность истории изменения статуса заявки
    /// </summary>
    [Table(Name = "BaseHistories")]
    public class BaseHistory
    {
        /// <summary>
        /// ид
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id { get; set; }

        /// <summary>
        /// ид заявки
        /// </summary>
        [Column]
        public long AppId { get; set; }

        /// <summary>
        /// дата изменения
        /// </summary>
        [Column]
        public DateTime DateModify { get; set; }

        /// <summary>
        /// старый статус
        /// </summary>
        [EnumDataType(typeof(Status))]
        [Range(1, 4, ErrorMessage = "Select a correct status")]
        public Status? StatusOld { get; set; }

        /// <summary>
        /// новый статус
        /// </summary>
        [EnumDataType(typeof(Status))]
        [Range(1, 4, ErrorMessage = "Select a correct status")]
        public Status StatusNew { get; set; }

        /// <summary>
        /// комментарий
        /// </summary>
        [Column]
        public string Comment { get; set; }
    }
}