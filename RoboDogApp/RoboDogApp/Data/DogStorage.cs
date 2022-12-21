using RoboDogApplication.Models;

namespace RoboDogApplication.Data
{
    public class DogStorage
    {
        public List<Dog> Dogs { get; set; }

        public DogStorage()
        {
            Dogs = new List<Dog>();
        }
    }
}
