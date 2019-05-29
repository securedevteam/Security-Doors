using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    public class PersonViewModel:Person
	{
		[Required]
		public new string FirstName { get; set; }

		[Required]
		public new string SecondName { get; set; }

		[Required]
		public new string LastName { get; set; }

		[Required]
		public new bool Gender { get; set; }

		[Required]
		public new string Passport { get; set; }
	}

    public class PersonEditModel : Person
    {
        [Required]
        public new string FirstName { get; set; }

        [Required]
        public new string SecondName { get; set; }

        [Required]
        public new string LastName { get; set; }

        [Required]
        public new bool Gender { get; set; }

        [Required]
        public new string Passport { get; set; }
    }
}
