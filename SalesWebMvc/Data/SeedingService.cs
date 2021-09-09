using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; //DB has been seeded
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@email.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Sara White", "sara@email.com", new DateTime(1980, 12, 1), 3000.0, d2);
            Seller s3 = new Seller(3, "Maria Green", "maria@email.com", new DateTime(1990, 7, 12), 1300.0, d3);
            Seller s4 = new Seller(4, "Alex Pink", "alex@email.com", new DateTime(1984, 5, 23), 2000.0, d4);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2021, 09, 05), 1100.0, SalesStatus.BILLED, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2021, 09, 05), 400.0, SalesStatus.PENDING, s3);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2021, 09, 05), 10.0, SalesStatus.CANCELED, s2);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SalesRecord.AddRange(r1, r2, r3);

            _context.SaveChanges();


        }
    }
}
