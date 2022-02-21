using WEB_API_DAY2.Models;
namespace WEB_API_DAY2.Services;
public class PersonService : IPersonService
{
    private static List<Person> _people = new List<Person>
        {
            new Person
            {
                
                FirstName = "Phuong",
                LastName = "Nguyen Nam",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 1, 22),
               
                BirthPlace = "Phu Tho",
                
            },
            new Person
            {
                
                FirstName = "Nam",
                LastName = "Nguyen Thanh",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 1, 20),
                
                BirthPlace = "Ha Noi",
                
            },
            new Person
            {
               
                FirstName = "Son",
                LastName = "Do Hong",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 11, 6),
                
                BirthPlace = "Ha Noi",
                
            },
            new Person
            {
                
                FirstName = "Huy",
                LastName = "Nguyen Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(1996, 1, 26),
                
                BirthPlace = "Ha Noi",
                
            },
            new Person
            {
                
                FirstName = "Hoang",
                LastName = "Phuong Viet",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 2, 5),
                
                BirthPlace = "Ha Noi",
                
            },
            new Person
            {
                
                FirstName = "Long",
                LastName = "Lai Quoc",
                Gender = "Male",
                DateOfBirth = new DateTime(1997, 5, 30),
                
                BirthPlace = "Bac Giang",
                
            },
            new Person
            {
                
                FirstName = "Thanh",
                LastName = "Tran Chi",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 9, 18),
                
                BirthPlace = "Ha Noi",
                
            },
            new Person
            {
                
                FirstName = "Manh",
                LastName = "Le Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(2001,4, 22),
                
                BirthPlace = "Ha Noi",
                
            },
            new Person
            {
                
                FirstName = "Dung",
                LastName = "Dao Tan",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 12, 7),
                
                BirthPlace = "Hung Yen",
                
            }
        };
    public List<Person> GetAll()
    {
        return _people;
    }
    public Person GetOne(int index)
    {
        if (index <= 0 || index > _people.Count) throw new IndexOutOfRangeException();
        return _people[index - 1];
    }
    public Person Create(Person person)
    {
        _people.Add(person);
        return person;
    }

    public Person Update(int index, Person person)
    {
        if (index <= 0 || index > _people.Count) throw new IndexOutOfRangeException();
        _people[index - 1] = person;
        return person;
    }

    public void Delete(int index)
    {
        if (index <= 0 || index > _people.Count) throw new IndexOutOfRangeException();
        _people.RemoveAt(index - 1);
    }


}

