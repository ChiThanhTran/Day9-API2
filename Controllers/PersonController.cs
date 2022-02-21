using Microsoft.AspNetCore.Mvc;
using WEB_API_DAY2.Services;
using WEB_API_DAY2.Models;

namespace WEB_API_DAY2.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{

    private readonly ILogger<PersonController> _logger;
    private readonly IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]
    public List<Person> GetAll()
    {
        return _personService.GetAll();
    }
    // public List<Person> Filter(string name, string gender, string birthPlace)
    // {
    //     var people = _personService.GetAll();
    //     Func<Person, bool> predicate = x => true;
    //     if(!string.IsNullOrEmpty(name))
    //     {
    //         Func<Person, bool> filterByName = x => (x.FirstName!= null && x.FirstName.Contains(name, StringComparison.CurrentCulture)) ||
    //         x.LastName!= null && x.LastName.Contains(name, StringComparison.CurrentCulture);
    //         predicate = predicate.And(filterByName);
    //     }
    //     if(!string.IsNullOrEmpty(gender))
    //     {
    //         Func<Person, bool> filterGender = x => (x.Gender!= null && x.Gender.Equals(gender, StringComparison.CurrentCultureIgnoreCase));
    //         predicate = predicate.And(filterByGender);
    //     }
    //     if(!string.IsNullOrEmpty(birthPlace))
    //     {
    //         Func<Person, bool> filterByBirthPlace = x => (x.BirthPlace!= null && x.BirthPlace.Equals(birthPlace, StringComparison.CurrentCultureIgnoreCase));
    //         predicate = predicate.And(filterByBirthPlace);
    //     }
    //     var results = people.Where(predicate);
    //     return results.ToList();

    // }
    [HttpGet("{index:int}")]
    public IActionResult GetOne(int index)
    {
        try
        {
            var person = _personService.GetOne(index);
            return new JsonResult(person);
        }
        catch (IndexOutOfRangeException ex)
        {
            // return NotFound(ex);
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPost]
    public Person Add(PersonCreateModel model)
    {
        var person = new Person
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Gender = model.Gender,
            DateOfBirth = model.DateOfBirth,
            BirthPlace = model.BirthPlace
        };
        return _personService.Create(person);
    }
    [HttpPut("{index:int}")]
    public IActionResult Edit(int index , PersonUpdateModel model)
    {
        try
        {
            var person = _personService.GetOne(index);
            person.FirstName = model.FirstName;
            person.LastName = model.LastName;
            person.Gender = model.Gender;
            person.BirthPlace = model.BirthPlace;
            _personService.Update(index, person);
            return new JsonResult(person);
        }
        catch (Exception ex)
        {
            // return NotFound(ex);
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpDelete("{index:int}")]
    public IActionResult Remove(int index)
    {
        try
        {
            _personService.Delete(index);
            return Ok();
        }
        catch (IndexOutOfRangeException ex)
        {
            // return NotFound(ex);
            _logger.LogError(ex, ex.Message);
            // return new StatusCodeResult(StatusCodes.Status500InternalServerError); 
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet("filter-by-name")]
    public List<Person> FilterByName(string keyword)
    {
        var people = _personService.GetAll();
        var results = from person in people
                    where (person.FirstName!= null && person.FirstName.Contains(keyword, StringComparison.CurrentCulture)) ||
                    person.LastName!= null && person.LastName.Contains(keyword, StringComparison.CurrentCulture)
                    select person;
        return results.ToList();


    }
    [HttpGet("filter-by-gender")]
    public List<Person> FilterByGender(string gender)
    {
        var people = _personService.GetAll();
        var results = from person in people
                    where person.Gender!= null && person.Gender.Equals(gender, StringComparison.CurrentCultureIgnoreCase)
                    select person;
        return results.ToList();


    }
    [HttpGet("filter-by-birthplace")]
    public List<Person> FilterByBirthPlace(string birthPlace)
    {
        var people = _personService.GetAll();
        var results = from person in people
                    where person.BirthPlace!= null && person.BirthPlace.Equals(birthPlace, StringComparison.CurrentCultureIgnoreCase)
                    select person;
        return results.ToList();


    }

}
