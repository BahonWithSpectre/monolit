using DataAccess.EFCore.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EFCore.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Developers = new DeveloperRepository(_context);
            Projects = new ProjectRepository(_context);
        }


        public IDeveloperRepository Developers { get; private set; }
        public IProjectRepository Projects { get; private set; }




        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public bool Any()
        {
            if(_context.Developers.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
