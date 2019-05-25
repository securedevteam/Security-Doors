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
        ICollection<PersonViewModel> People { get; set; }
        ICollection<DoorViewModel> Doors { get; set; }
    }

    public class DoorPassingEditModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime PassingTime { get; set; } = DateTime.Now;

        [Required]
        public int? DoorId { get; set; }

        [Required]
        public int? PersonId { get; set; }
    }
}
