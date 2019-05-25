using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    class DoorViewModel
    {
        public Door Door { get; set; }
    }

    public class DoorEditModel
    {
        [Required]
        public int PersonId { get; set; }
    }
}
