using RoboDogApplication.Data.Enums;
using RoboDogApplication.Models;
using System;
using System.Linq;

namespace RoboDogApplication.Data.Services
{
    public class DogsService : IDogsService
    {
        private readonly DogStorage _dogStorage;

        public DogsService(DogStorage dogStorage)
        {
            _dogStorage = dogStorage;
        }


        public Dog CreateRandomDog()
        {

            // Init Dog class
            Dog newDog = new Dog();


            // Set random name
            List<string> names = new List<string>() { "Pötyi", "Bogyó", "Babóca", "Franklin" };
            Random nameRND = new Random();
            int nameIndex = nameRND.Next(0, names.Count());
            newDog.Name = names[nameIndex];

            // Set random age
            Random ageRND = new Random();
            newDog.Age = ageRND.Next(1, 15);

            // Set random breed
            List<DogType> breed = new List<DogType>();
            breed = Enum.GetValues(typeof(DogType)).Cast<DogType>().ToList();
            Random breedRND = new Random();
            int breedIndex = breedRND.Next(0, breed.Count());
            newDog.Breed = breed[breedIndex];

            return newDog;
        }
        public void Add(Dog dog)
        {
            _dogStorage.Dogs.Add(dog);
        }

        public void AddRandomDog()
        {
            Dog randomDog = CreateRandomDog();
            _dogStorage.Dogs.Add(randomDog);
        }


        public List<Dog> GetAll()
        {
            var result = _dogStorage.Dogs?.ToList();
            return result;
        }

        public Dog GetDogByName(string name)
        {
            var result = _dogStorage.Dogs.FirstOrDefault(doggo => doggo.Name == name);
            return result;
        }
        public Dog Update(Dog dog)
        {
            Dog currentDog = GetDogByName(dog.Name);
            currentDog.Age = dog.Age;
            currentDog.Breed = dog.Breed;
            return currentDog;
        }
    }
}
