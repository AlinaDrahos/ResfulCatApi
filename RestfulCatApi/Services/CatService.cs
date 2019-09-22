using RestfulCatApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulCatApi.Services
{
    public class CatService
    {
        public static List<Owner> myOwners = new List<Owner>()
            {
                new Owner(){
                    Id = 1,
                    Name ="Jon",
                    Age =31,
                    MyCats = new List<Cat>(){
                        new Cat()
                        {
                            Age = 5,
                            Id = 1,
                            Name = "Atticus",
                            Type = "Gray Stripes"
                        }
                    }
                },
                new Owner(){
                    Id = 2,
                    Name ="Alina",
                    Age =31,
                    MyCats = new List<Cat>
                    {
                        new Cat
                        {
                            Id= 2,
                            Age = 10,
                            Name = "Samantha",
                            Type = "Calico"
                        }
                    }
                },
            };


        public List<Owner> GetOwners()
        {
            return myOwners;
        }

        public void AddOwner(Owner owner)
        {
            myOwners.Add(owner);
        }

        public Owner GetOwner(int id)
        {
            foreach (Owner owner in myOwners)
            {
                if (id == owner.Id)
                {
                    return owner;
                }
            }

            return null;
        }

        public List<Cat> GetCatsforOwner(int ownerId)
        {
            Owner owner = GetOwner(ownerId);
            return owner.MyCats;
        }

        public void AddCat(Cat cat, int ownerId)
        {
            Owner owner = GetOwner(ownerId);
            owner.MyCats.Add(cat);
        }

        public Cat GetCat(int id)
        {
            foreach (Owner owner in myOwners)
            {
                foreach (Cat cat in owner.MyCats)
                {
                    if (cat.Id == id)
                    {
                        return cat;
                    }
                }
            }

            return null;
        }

        public void AddCatToOwner(Cat cat)
        {
            Random someOwner = new Random();
            int ID = someOwner.Next(1, 3);
            AddCat(cat,ID);
        }
    }
}
