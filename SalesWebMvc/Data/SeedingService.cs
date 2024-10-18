using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System.Security.Cryptography;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private readonly SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any()) return;

            Department d1 = new Department(1, "Computer");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fahsion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.coim", new DateTime(1998, 4 ,21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.coim", new DateTime(1979, 12 ,8), 1000.0, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.coim", new DateTime(1988, 7 ,18), 1000.0, d3);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.coim", new DateTime(1993, 11 ,9), 1000.0, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.coim", new DateTime(2000, 1 ,6), 1000.0, d3);
            Seller s6 = new Seller(6, "Alex Pink", "alex@gmail.coim", new DateTime(1997, 3 ,4), 1000.0, d2);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018, 9, 25), 11000.0, SalesStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2018, 9, 25), 1000.0, SalesStatus.Billed, s2);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2018, 9, 25), 19000.0, SalesStatus.Billed, s3);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2018, 9, 25), 8000.0, SalesStatus.Billed, s4);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2018, 9, 25), 5500.0, SalesStatus.Billed, s5);
            SalesRecord sr6 = new SalesRecord(6, new DateTime(2018, 9, 25), 7300.0, SalesStatus.Billed, s6);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5, sr6);

            _context.SaveChanges();
        }
    }
}
