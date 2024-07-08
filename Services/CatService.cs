using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        public Cat GetById(int id)
        {
            return _context.Cats.FirstOrDefault(x => x.Id == id);
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
            return _context.Cats.Where(c => c.Name == name).ToList();

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

        public List<Cat> GetOdd()
        {
            var listx = _context.Cats.FromSql($"SELECT * FROM Cats WHERE MOD(Id, 2) <> 0").ToList();

            return listx;
        }

        public List<Cat> returnPage(int page, int elements)
        {
            return _context.Cats.Skip(page * elements).Take(elements).ToList();
        }

    }
}