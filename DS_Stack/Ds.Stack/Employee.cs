using System.ComponentModel.DataAnnotations;

namespace Ds.Stack
{
    internal class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Custom)]
        public int Age { get; set; }

        public string City { get; set; } = string.Empty;
    }
}
