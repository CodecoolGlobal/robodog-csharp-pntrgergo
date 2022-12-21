using RoboDogApplication.Data.Enums;
using RoboDogApplication.Models;

namespace RoboDogApplication.Data.Services;

public interface IDogsService
{
    public Dog CreateRandomDog();
    public void Add(Dog dog);
    public void AddRandomDog();
    public List<Dog> GetAll();
    public Dog GetDogByName(string name);
    public Dog Update(Dog dog);
}