using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Models
{
    public interface IProjectRepository
    {
        Project GetBy(int id);

        IEnumerable<Project> GetAll();
        IEnumerable<Project> GetAllFiltered(string name);

        void Add(Project recipe);
        void Delete(Project recipe);
        void Update(Project recipe);
        void SaveChanges();
    }


}
