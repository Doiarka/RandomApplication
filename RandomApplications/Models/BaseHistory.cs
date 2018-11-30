using System;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;

namespace RandomApplications.Models
{
    ///<summary>
    /// сущность истории изменения статуса заявки
    /// </summary>
    [Table(Name = "BaseHistory")]
    public class BaseHistory
    {
        ///<summary>
        /// ид
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id { get; set; }

        ///<summary>
        /// ид заявки
        /// </summary>
        [Column]
        public long AppId { get; set; }

        ///<summary>
        /// дата изменения
        /// </summary>
        [Column]
        public DateTime DateModify { get; set; }

        ///<summary>
        /// ид старого статуса
        /// </summary>
        [Column]
        public virtual int? StatusOldId { get; set; }

        ///<summary>
        /// старый статус
        /// </summary>
        [EnumDataType(typeof(Status))]
        public Status? StatusOld
        {
            get
            {
                if (StatusOldId == null)
                    return null;
                else
                    return (Status)StatusOldId;
            }
            set
            {
                if (value != null)
                    StatusOldId = (int)value;
                else
                    StatusOldId = null;
            }
        }

        ///<summary>
        /// ид нового статуса
        /// </summary>
        [Column]
        public virtual int StatusNewId { get; set; }

        ///<summary>
        /// новый статус
        /// </summary>
        [EnumDataType(typeof(Status))]
        public Status StatusNew
        {
            get
            {
                return (Status)StatusNewId;
            }
            set
            {
                StatusNewId = (int)value;
            }
        }

        ///<summary>
        /// комментарий
        /// </summary>
        [Column]
        public string Comment { get; set; }
    }
}