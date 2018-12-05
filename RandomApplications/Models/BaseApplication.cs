using System;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;

namespace RandomApplications.Models
{
    /// <summary>
    /// сущность заявки
    /// </summary>
    [Table(Name = "BaseApplications")]
    public class BaseApplication
    {
        /// <summary>
        /// ид
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id { get; set; }

        /// <summary>
        /// название
        /// </summary>
        [Column]
        public string Title { get; set; }

        /// <summary>
        /// описание
        /// </summary>
        [Column]
        [DataType(DataType.MultilineText)]
        [UIHint("Description")]
        public string Description { get; set; }

        /// <summary>
        /// статус
        /// </summary>
        [EnumDataType(typeof(Status))]
        [Range(1, 4, ErrorMessage = "Select a correct status")]
        public Status Status { get; set; }

        /// <summary>
        /// дата изменения
        /// </summary>
        [Column]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime DateModify { get; set; }

        /// <summary>
        /// список ид историй изменения
        /// </summary>
        [Column]
        public string HistoryIds { get; set; }
    }

    /// <summary>
    /// статусы заявки
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// все
        /// </summary>
        [Display(Name = "Все")]
        All = 0,
        /// <summary>
        /// открыта
        /// </summary>
        [Display(Name = "Открыта")]
        Open = 1,
        /// <summary>
        /// решена
        /// </summary>
        [Display(Name = "Решена")]
        Ready = 2,
        /// <summary>
        /// возврат
        /// </summary>
        [Display(Name = "Возвращена")]
        Return = 3,
        /// <summary>
        /// закрыта
        /// </summary>
        [Display(Name = "Закрыта")]
        Close = 4
    }
}
 