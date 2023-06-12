using LibraryApp.DataAccess;
using LibraryApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public class ConditionRepository : RepositoryBase<Condition>, IConditionRepository
    {

        public ConditionRepository(IDbContext context) : base(context)
        {

        }

        public string? GetConditionNameById(int id)
        {
            var condition = GetById(id);

            return condition?.Name;
        }

    }
}
