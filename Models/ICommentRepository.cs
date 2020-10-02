using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Models
{
    public interface ICommentRepository
    {
        Comment GetBy(int id);

        IEnumerable<Comment> GetAll();
        void Add(Comment task);
        void Delete(Comment task);
        void Update(Comment task);
        void SaveChanges();
    }
}
