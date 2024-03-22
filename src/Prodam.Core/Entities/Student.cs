using System;

namespace Prodam.Core.Entities
{
    public class Student
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ClassId { get; set; }

    }
}
