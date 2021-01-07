using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class DepartmentsService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentsService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync() =>
            await _context.Department.OrderBy(x => x.Name).ToListAsync();

        public void Insert(Seller seller)
        {
            //seller.Department = _context.Department.First();
            //_context.Add(seller);
            //_context.SaveChanges();
        }
    }
}