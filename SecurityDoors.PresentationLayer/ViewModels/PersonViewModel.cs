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
        [Required]
        public int PersonId { get; set; }
    }
}
