using SecurityDoors.Core.EmailService.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace SecurityDoors.Core.EmailService.Implementations
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

		private void GetConfigurationFromFile()
		{
			try
			{
				var jsonFormatter = new DataContractJsonSerializer(typeof((string,string,string,int)));
				using (var fs = new FileStream("emailconfig.json", FileMode.OpenOrCreate))
				{
					var (senderEmail, senderPassword, smtpServerAddress, smtpServerPort) = ((string senderEmail, string senderPassword, string smtpServerAddress, int smtpServerPort))jsonFormatter.ReadObject(fs);

					_senderEmail = senderEmail;
                    _senderPassword = senderPassword;
					_smtpServerAddress = smtpServerAddress;
					_smtpServerPort = smtpServerPort;
				}
			}
			catch (Exception exc)
			{
				throw exc;
			}
		}

        /// <inheritdoc/>
		public async Task SendEmailAsync(string to, string subject, string body, Attachment attachment = null)
		{
			var mailMessage = new MailMessage(new MailAddress(_senderEmail), new MailAddress(to));

			if (attachment != null)
			{
				mailMessage.Attachments.Add(attachment ?? null);
			}
			
			await _smtpClient.SendMailAsync(mailMessage);
		}
	}
}
