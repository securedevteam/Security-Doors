using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    public class CardViewModel
    {
        public Card Card { get; set; }
    }

    public class CardEditModel
    {
        public int Id { get; set; }

        [Required]
        public string UniqueNumber { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
