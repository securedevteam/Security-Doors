using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    public class ReportDataViewModel
    {
        [Display(Name = "Test")]
        public string TestProperty { get; set; }
    }
}
