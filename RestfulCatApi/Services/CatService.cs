using MongoDB.Bson;
using MongoDB.Driver;
using RestfulCatApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulCatApi.Services
{
    public class CatService
    {
        public List<Owner> GetOwners()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = client.GetDatabase("Cats");
            var collection = db.GetCollection<Owner>("Owners");

            BsonDocument filter = new BsonDocument();
            return collection.Find(filter).ToList();

        }

        public void AddOwner(Owner owner)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = client.GetDatabase("Cats");
            var collection = db.GetCollection<Owner>("Owners");

            owner.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            foreach (Cat cat in owner.MyCats)
            {
                cat.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            }
            collection.InsertOne(owner);
        }

        public Owner GetOwner(string id)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = client.GetDatabase("Cats");
            var collection = db.GetCollection<Owner>("Owners");

            BsonDocument filter = new BsonDocument();
            filter.Add("_id", BsonValue.Create(ObjectId.Parse(id)));

            return collection.Find(filter).ToList()[0];
        }

        public List<Cat> GetCatsforOwner(string ownerId)
        {
            Owner owner = GetOwner(ownerId);
            return owner.MyCats;
        }

        public void AddCat(Cat cat, string ownerId)
        {
            Owner owner = GetOwner(ownerId);
            owner.MyCats.Add(cat);

            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = client.GetDatabase("Cats");
            var collection = db.GetCollection<Owner>("Owners");

            BsonDocument filter = new BsonDocument();
            filter.Add("_id", BsonValue.Create(ObjectId.Parse(ownerId)));

            collection.ReplaceOne(filter, owner);
        }

        public Cat GetCat(string id)
        {

            foreach (Owner owner in GetOwners())
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
            List<Owner> myOwners = GetOwners();
            int index = someOwner.Next(1,myOwners.Count+1);
            Owner myOwner=myOwners[index];
            AddCat(cat,myOwner.Id);
        }
    }
}
