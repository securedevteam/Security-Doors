using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SecurityDoors.Core.Mailing.Interfaces;

namespace SecurityDoors.Core.Mailing.Implementations
{
    /// <summary>
    /// Сервис для работы с почтой.
    /// </summary>
	public class EmailService : IEmailService
	{
		private SmtpClient _smtpClient;
		private string _senderEmail;
		private string _senderPassword;
		private string _smtpServerAddress;
		private int _smtpServerPort;

        /// <summary>
        /// Конструктор для установки настроек из файла emailconfig.json.
        /// </summary>
		public EmailService()
        {
            GetConfigurationFromFile();
            ConfigureSmtpClient();
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="senderEmail">e-mail отправителя.</param>
        /// <param name="senderPassword">пароль.</param>
        /// <param name="smtpServerAddress">SMTP.</param>
        /// <param name="smtpServerPort">SMTP Port.</param>
		public EmailService(string senderEmail, string senderPassword, string smtpServerAddress, int smtpServerPort)
		{
			_senderEmail = senderEmail ?? throw new ArgumentNullException(nameof(senderEmail));
			_senderPassword = senderPassword ?? throw new ArgumentNullException(nameof(senderPassword));
			_smtpServerAddress = smtpServerAddress ?? throw new ArgumentNullException(nameof(smtpServerAddress));
			_smtpServerPort = smtpServerPort;

            ConfigureSmtpClient();
		}

		/// <summary>
		/// Инициализирует локальный приватный экзмепляр класса SmtpClient.
		/// </summary>
		private void ConfigureSmtpClient()
		{
			_smtpClient = new SmtpClient()
			{
				Host = _smtpServerAddress,
				Port = _smtpServerPort,
				Credentials = new NetworkCredential(_senderEmail, _senderPassword),
				EnableSsl = true,
			};
		}

		/// <summary>
		/// Получить конфигурацию из файла для инициализации SmtpClient.
		/// </summary>
		private void GetConfigurationFromFile()
		{
			try
			{
				var jsonFormat = new {senderEmail = "", senderPassword = "", smtpServerAddress = "", smtpServerPort = 0 };
				using (var fs = new FileStream("emailconfig.json", FileMode.OpenOrCreate))
				{
					var json = new StreamReader(fs).ReadToEnd();
					var config = JsonConvert.DeserializeAnonymousType(json, jsonFormat);
					
					_senderEmail = config.senderEmail;
					_senderPassword = config.senderPassword;
					_smtpServerAddress = config.smtpServerAddress;
					_smtpServerPort = config.smtpServerPort;
				}
			}
			catch (FileNotFoundException fnfExc)
			{
				throw fnfExc;
			}
			catch (Exception exc)
			{
				throw exc;
			}
		}

        /// <inheritdoc/>
		public async Task SendEmailAsync(string to, string subject, string body, Attachment attachment = null)
		{
			var mailMessage = new MailMessage(new MailAddress(_senderEmail), new MailAddress(to))
			{
				Subject = subject,
				Body = body,
				IsBodyHtml = true,
			};

			if (attachment != null)
			{
				mailMessage.Attachments.Add(attachment);
			}
			
			await _smtpClient.SendMailAsync(mailMessage);
		}
	}
}
