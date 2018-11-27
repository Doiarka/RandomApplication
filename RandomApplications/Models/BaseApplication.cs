using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;

namespace RandomApplications.Models
{
    ///<summary>
    /// сущность заявки
    /// </summary>
    [Table(Name = "BaseApplication")]
    public class BaseApplication
    {
        ///<summary>
        /// ид
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id { get; set; }

        ///<summary>
        /// название
        /// </summary>
        [Column]
        public string Title { get; set; }

        ///<summary>
        /// описание
        /// </summary>
        [Column]
        public string Description { get; set; }

        ///<summary>
        /// ид статуса
        /// </summary>
        [Column]
        public virtual int StatusId { get; set; }

        ///<summary>
        /// статус
        /// </summary>
        [EnumDataType(typeof(Status))]
        public Status Status
        {
            get
            {
                return (Status)StatusId;
            }
            set
            {
                StatusId = (int)value;
            }
        }
    }

    ///<summary>
    /// статусы заявки
    /// </summary>
    public enum Status
    {
        ///<summary>
        /// открыта
        /// </summary>
        Open,
        ///<summary>
        /// решена
        /// </summary>
        Ready,
        ///<summary>
        /// возврат
        /// </summary>
        Return,
        ///<summary>
        /// закрыта
        /// </summary>
        Close
    }
}
 