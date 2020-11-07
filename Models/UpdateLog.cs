using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Models
{
    public class UpdateLog
    {
        public int Id { get; set; }
        public DateTime LastModification { get; set; }

        public UpdateLog()
        {
        }
        public UpdateLog(DateTime date)
        {
            LastModification = date;
        }

    }
}
