using SecurityDoors.DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ViewModels
{
	class DoorViewModel : Door
	{
		[Required]
		public new int Id { get; set; }
		[Required]
		public new int Name { get; set; }
		[Required]
		public new string Description { get; set; }
	}

	public class DoorEditModel : Door
	{
		[Required]
		public new int Id { get; set; }
		[Required]
		public new int Name { get; set; }
		[Required]
		public new string Description { get; set; }
	}
}
