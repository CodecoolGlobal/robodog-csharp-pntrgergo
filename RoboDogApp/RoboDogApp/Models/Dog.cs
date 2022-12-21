using System.ComponentModel.DataAnnotations;
using RoboDogApplication.Data.Enums;

namespace RoboDogApplication.Models
{
    public class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DogType Breed { get; set; }
    }
}
