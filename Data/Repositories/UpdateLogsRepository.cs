using AssisterApi.Models;
using AssisterApi.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Data.Repositories
{
    public class UpdateLogsRepository : IUpdateLogsRepository
    {
        private readonly AssisterContext _context;
        private readonly DbSet<UpdateLog> _updateLogs;


        public UpdateLogsRepository(AssisterContext dbContext)
        {
            _context = dbContext;
            _updateLogs = _context.UpdateLogs;
        }

        public UpdateLog Get()
        {
            return _updateLogs.SingleOrDefault(u => u.Id == 1);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(UpdateLog log)
        {
            _context.Update(log);
        }
    }
}
