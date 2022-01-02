using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication_Jenny.Interfaces;
using WebApplication_Jenny.Models;

namespace WebApplication_Jenny.Repositories
{
    public class NorthwindRepository
    {
        private readonly NorthwindContext _context;
        public NorthwindRepository()
        {
            _context = new NorthwindContext();
        }

        public void Create<T>(T value) where T : ITable
        {
            _context.Entry(value).State = EntityState.Added;
        }

        public void Update<T>(T value) where T : class
        {
            _context.Entry(value).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}