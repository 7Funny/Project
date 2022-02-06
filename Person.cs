using System;

namespace Project
{
    class Person
    {
        public string Surname { get; }
        public string Name { get; }
        public string Patronomyc { get; }
        public bool Gender { get; }
        public float Height { get; }
        public DateTime Birthday { get; }
        public int Age
        {
            get
            {
                DateTime temp = new DateTime(Birthday.Year, DateTime.Now.Month, DateTime.Now.Day);
                return Birthday.CompareTo(temp) > 0 ? DateTime.Now.Year - Birthday.Year - 1 : DateTime.Now.Year - Birthday.Year;
            }
        }

        public Person(string surname, string name, string patronomyc, bool gender, float height, DateTime birthday)
        {
            this.Surname = surname;
            this.Name = name;
            this.Patronomyc = patronomyc;
            this.Gender = gender;
            this.Height = height;
            this.Birthday = birthday;
        }
        public static Person Parse(string line)
        {
            string[] elem = line.Split(',');
            Person person = new Person(
                     elem[0], elem[1], elem[2],
                     elem[3] == "Male" ? true : false,
                     float.Parse(elem[4]),
                     DateTime.Parse(elem[5])
                     );
            return person;
        }
        public override string ToString()
        {
            string result = $"{this.Surname} {this.Name} {this.Patronomyc}, {(this.Gender ? "Male" : "Female")}, {this.Height:F2}, {this.Birthday.ToString(@"dd MMM yyyy")}, {this.Age} y.o.";
            return result;
        }
    }
}

