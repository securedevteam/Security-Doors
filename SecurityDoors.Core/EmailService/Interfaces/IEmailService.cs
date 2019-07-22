using System.Net.Mail;
using System.Threading.Tasks;

namespace SecurityDoors.Core.EmailService.Interfaces
{
	public interface IEmailService
	{
		/// <summary>
		/// Отправить сообщение.
		/// </summary>
		/// <param name="to">e-mail получателя.</param>
		/// <param name="subject">заголовок.</param>
		/// <param name="body">содержимое письма.</param>
		/// <param name="attachment">прикрепленные файлы.</param>
		Task SendEmailAsync(string to, string subject, string body, Attachment attachment = null);
	}
}
