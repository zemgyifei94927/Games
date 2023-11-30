﻿using Games.DataAccess.Data;
using Games.DataAccess.Repository.IRepository;
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
        public UnitofWork(ApplicationDbContext db) { 
            _db = db;
            Category = new CategoryRepository(_db);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}