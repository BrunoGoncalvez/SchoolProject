using System;

namespace Prodam.Core.Entities
{
    public class Class
    {

        public Guid Id { get; set; }

        public int Number { get; set; }

        public string SchoolSubject { get; set; }

        public Professor Professor { get; set; }

        public Guid ProfessorId { get; set; }

        public List<Student> Students { get; set; }

    }
}
