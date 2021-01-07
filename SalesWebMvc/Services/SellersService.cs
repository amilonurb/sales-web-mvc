using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class SellersService
    {
        private readonly SalesWebMvcContext _context;

        public SellersService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll() => _context.Seller.ToList();

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }
    }
}