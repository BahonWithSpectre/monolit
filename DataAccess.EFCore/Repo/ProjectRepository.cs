using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore.Repo
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
