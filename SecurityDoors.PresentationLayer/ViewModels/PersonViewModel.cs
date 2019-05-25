using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    public class PersonViewModel
    {
        public Person Person { get; set; }
    }

    public class PersonEditModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public string Passport { get; set; }

        public int? CardId { get; set; }
    }
}
