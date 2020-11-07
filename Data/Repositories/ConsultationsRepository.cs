using AssisterApi.Models;
using AssisterApi.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Data.Repositories
{
    public class ConsultationsRepository : IConsultationsRepository
    {
        private readonly AssisterContext _context;
        private readonly DbSet<Consultation> _consultations;


        public ConsultationsRepository(AssisterContext dbContext)
        {
            _context = dbContext;
            _consultations = _context.Appointments;
        }
        public void Add(Consultation consultation)
        {
            _consultations.Add(consultation);
        }

        public void Delete(Consultation consultation)
        {
            _consultations.Remove(consultation);
        }

        public IEnumerable<Consultation> GetAll()
        {
           return  _consultations.Include(c => c.Customer);
        }

        public Consultation GetBy(int id)
        {
            return _consultations.SingleOrDefault(u => u.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Consultation consultation)
        {
            _context.Update(consultation);
        }
    }
}
