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
        public IEnumerable<Card> Cards { get; set; }
    }

    public class CardEditModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Уникальный номер не указан")]
        [Display(Name = "Уникальный номер")]
        public string UniqueNumber { get; set; }

        [Required (ErrorMessage = "Не верный статус")]
        [Display(Name = "Статус")]
        public bool Status { get; set; }
    }
}
