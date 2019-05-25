using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    public class DoorPassingViewModel
    {
        public DoorPassing DoorPassing { get; set; }
    }

    public class DoorPassingEditModel
    {
        [Required]
        public int DoorPassingId { get; set; }
    }
}
