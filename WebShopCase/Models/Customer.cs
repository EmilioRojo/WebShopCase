using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShopCase.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Please enter your title")]
        public string Title {get;set;}

        [Required(ErrorMessage = "Please enter your fisrt name")]
        public string FirstName {get;set;}

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName  {get;set;}

        [Required(ErrorMessage = "Please enter your address")]
        public string Address  {get;set;}

        [Required(ErrorMessage = "Please enter your house number")]
        public string HouseNumber  {get;set;}

        [Required(ErrorMessage = "Please enter your zip code")]
        public string ZipCode  {get;set;}

        [Required(ErrorMessage = "Please enter your city")]
        public string City  {get;set;}
        
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage = "Please enter a valid email address")]
        public string Email {get;set;}
    }
}