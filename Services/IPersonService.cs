using WEB_API_DAY2.Models;
namespace WEB_API_DAY2.Services;
public interface IPersonService
{
    List<Person> GetAll();
    Person GetOne(int index);
    Person Create(Person person);
    Person Update(int index , Person person);
    void Delete(int index);
}

