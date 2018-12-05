namespace RandomApplications.Request
{
    /// <summary>
    /// модель создания заявки
    /// </summary>
    public class CreateApplicationRequest
    {
        /// <summary>
        /// название
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// описание
        /// </summary>
        public string Description { get; set; }
    }
}