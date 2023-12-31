﻿using Games.DataAccess.Data;
using Games.DataAccess.Repository.IRepository;
using Games.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.DataAccess.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public UnitofWork(ApplicationDbContext db) { 
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
