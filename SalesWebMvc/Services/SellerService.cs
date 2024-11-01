﻿using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
using System.Xml.Serialization;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }
        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundExceptions("Id not found");
            }
            try
            {
                _context.Update(seller);
                _context.SaveChanges();

            }
            catch (DbConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
