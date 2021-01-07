using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? min, DateTime? max)
        {
            var query = from s in _context.SalesRecord select s;

            if (min.HasValue)
            {
                query = query.Where(s => s.Date >= min.Value);
            }

            if (max.HasValue)
            {
                query = query.Where(s => s.Date <= max.Value);
            }

            return await query
                .Include(s => s.Seller)
                .Include(s => s.Seller.Department)
                .OrderByDescending(s => s.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? min, DateTime? max)
        {
            var query = from s in _context.SalesRecord select s;

            if (min.HasValue)
            {
                query = query.Where(s => s.Date >= min.Value);
            }

            if (max.HasValue)
            {
                query = query.Where(s => s.Date <= max.Value);
            }

            return await query
                .Include(s => s.Seller)
                .Include(s => s.Seller.Department)
                .OrderByDescending(s => s.Date)
                .GroupBy(s => s.Seller.Department)
                .ToListAsync();
        }
    }
}