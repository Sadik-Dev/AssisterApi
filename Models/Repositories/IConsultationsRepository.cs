using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Models.Repositories
{
    public interface IConsultationsRepository
    {
        public void Add(Consultation consultation);

        public void Delete(Consultation consultation);
        public IEnumerable<Consultation> GetAll();
        public Consultation GetBy(int id);

        public void SaveChanges();

        public void Update(Consultation consultation);
    }
}
