using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore.Repo
{
    public interface IDeveloperRepository : IGenericRepository<Developer>
    {
        IEnumerable<Developer> GetPopularDevelopers(int count);
    }
}
