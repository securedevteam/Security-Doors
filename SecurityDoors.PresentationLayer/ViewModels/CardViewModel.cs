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
        [Required]
        public int CardId { get; set; }
    }
}
