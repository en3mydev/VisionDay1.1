﻿using Microsoft.AspNetCore.Mvc;
using VisionDay1.Data;
using VisionDay1.Models;
namespace VisionDay1.Services { 
    public class CatService
    {

        private DanielDbContext _context;

        public CatService(DanielDbContext context) 
        {
            _context = context;
        }

        public List<Cat> GetAll()
        {
            return _context.Cats.ToList();
        }


        public List<Cat> getById(int id)
        {
            _context.Cats.FirstOrDefault(x => x.Id == id);
            return _context.Cats.ToList();
        }

        public void Add(Cat cat)
        {

            _context.Cats.Add(cat);
            _context.SaveChanges();

/*            var foundCat = context.FirstOrDefault(c => c.Id == cat.Id);
            if (foundCat != null)
                context.Remove(foundCat);
            context.Add(cat);*/
        }

        public List<Cat> FindByName(string name)
        {
            foreach (var cat in _context.Cats)
            {
                if (cat.Name == name)
                {
                    return _context.Cats.ToList();
                }
            }
            return null;
        }

        public void Update(int id, Cat cat2)
        {
            Cat foundCat = _context.Cats.FirstOrDefault(x => x.Id == id);
            _context.Cats.Remove(foundCat);
            _context.Cats.Add(cat2);
            _context.SaveChanges();

/*            Cat foundCat = context.FirstOrDefault(c => c.Id == id);

            context.Remove(foundCat);
            context.Add(cat2);*/
        }

/*        public List<Cat> getRandom()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, context.Count);
            return context;
        } */
        public void DeleteCat(int id)
        {
            Cat foundCat = _context.Cats.FirstOrDefault(c => c.Id == id); 
            _context.Remove(foundCat);
            _context.SaveChanges();
        }
    }
}