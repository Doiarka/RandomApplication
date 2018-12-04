using System.Collections.Generic;
using RandomApplications.Models;

namespace RandomApplications.Request
{
    public class EditApplicationRequest
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public Status StatusOld { get; set; }
        public Status StatusNew { get; set; }
        public List<BaseHistory> Histories { get; set; } = new List<BaseHistory>();
    }
}