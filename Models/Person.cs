namespace WEB_API_DAY2.Models;
using System.ComponentModel.DataAnnotations;
public class PersonCreateModel 
{
        [Required, MaxLength(50)]
        public string? FirstName {get;set;}
        [Required,MaxLength(50)]
        public string? LastName {get;set;}
        public string? Gender {get;set;}
        public DateTime DateOfBirth {get;set;}
        [MaxLength(10)]
        public string? BirthPlace {get;set;}
}
public class PersonUpdateModel 
{
        [Required, MaxLength(50)]
        public string? FirstName {get;set;}
        [Required,MaxLength(50)]
        public string? LastName {get;set;}
        public string? Gender {get;set;}
        [MaxLength(10)]
        public string? BirthPlace {get;set;}
}
public class Person : PersonCreateModel
{
        public string FullName 
        {
            get
            {
                return LastName+" "+FirstName;
            }
        }  
        public int Age 
        {
            get 
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }  
}
