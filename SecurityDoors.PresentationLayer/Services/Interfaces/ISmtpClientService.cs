using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Interfaces
{
	public interface ISmtpClientService
	{
		/// <summary>
		/// Начинает асинхронную отправку сообщения
		/// </summary>
		/// <param name="to">e-mail получателя</param>
		/// <param name="subject">Заголовок</param>
		/// <param name="body">Содержимое письма</param>
		/// <param name="attachment">Прикрепленные файлы</param>
		Task SendEmailAsync(string to, string subject, string body, Attachment attachment = null);
		
		/// <summary>
		/// Настроить smtp-клиент не из файла настроек
		/// </summary>
		/// <param name="senderEmail">e-mail отправителя</param>
		/// <param name="password">Пароль</param>
		/// <param name="smtpServerAddress">Адрес smtp сервера</param>
		/// <param name="smtpServerPort">Порт smtp сервера</param>
		/// <returns></returns>
		Task ConfigureSmtpClientAsync(string senderEmail, string password, string smtpServerAddress, int smtpServerPort);
	}
}
