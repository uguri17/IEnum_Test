using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnum_Test
{
    public class Person // Person: 사람 한명, Peolple: 사람
    {
        // Field
        public string firstName;
        public string lastName;

        // Constructor
        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }

    public class People : IEnumerable
    {
        // Field
        private Person[] person;

        // Constructor
        public People(Person[] pArray)
        {           // System.Array[]
            person = new Person[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                person[i] = pArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return new PeopleEnum(person);
        }
    }

    public class PeopleEnum : IEnumerator
    {
        public Person[] person;

        int position = -1;

        public PeopleEnum(Person[] list)
        {
            person = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < person.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Person Current
        {
            get
            {
                try
                {
                    return person[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Person[] peopleArray = new Person[3]
            {
                new Person("dawon", "kim"),
                new Person("dawon1", "kim1"),
                new Person("dawon2", "kim2")
            };

            foreach (var pA in peopleArray)
            {
                Console.WriteLine(pA);
            }

            People peopleList = new People(peopleArray);
            foreach (Person pL in peopleList)
            {
                Console.WriteLine($"{pL.lastName} {pL.firstName}");
            }
        }
    }
}