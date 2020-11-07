using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Models.Repositories
{
    public interface IUpdateLogsRepository
    {
        public UpdateLog Get();

        public void SaveChanges();

        public void Update(UpdateLog log);
    }
}
