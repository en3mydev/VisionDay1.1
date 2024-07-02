using Microsoft.AspNetCore.Mvc;
using VisionDay1.Models;
namespace VisionDay1.Services { 
    public class CatService
    {
        private List<Cat> context = new List<Cat> {
        new Cat{ Id = 1, Name = "Persian", Color = "Black", Description = "Cool" },
        new Cat{ Id = 2, Name = "Siamese", Color = "Orange", Description = "Angry"},
        new Cat{ Id = 3, Name = "Maine Coon", Color = "White", Description = "Happy"},
        new Cat{ Id = 4, Name = "Bingus", Color = "Black", Description = "Sad"},
        new Cat{ Id = 5, Name = "Ragdoll", Color = "White", Description = "Angry"},
        new Cat{ Id = 6, Name = "British Shorthair", Color="Black", Description = "Happy"},
        new Cat{ Id = 7, Name = "Bengal", Color = "Orange", Description = "Happy"}
    };

        public CatService() { }

        public List<Cat> GetAll()
        {
            return context;
        }


        public List<Cat> getById(int id)
        {
            context.Find(x => x.Id == id);
            return context;
        }

        public void Add(Cat cat)
        {
            var foundCat = context.FirstOrDefault(c => c.Id == cat.Id);
            if (foundCat != null)
                context.Remove(foundCat);
            context.Add(cat);
        }

        public List<Cat> FindByName(string name)
        {
            foreach (var cat in context)
            {
                if (cat.Name == name)
                {
                    return context;
                }
            }
            return null;
        }

        public void Update(int id, Cat cat2)
        {
            Cat foundCat = context.FirstOrDefault(c => c.Id == id);

            context.Remove(foundCat);
            context.Add(cat2);
        }

        public List<Cat> getRandom()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, context.Count);
            return context;
        }
        public void DeleteCat(int id)
        {
            Cat foundCat = context.FirstOrDefault(c => c.Id == id); 
            context.Remove(foundCat);
        }
    }
}