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
		private string senderEmail;
		private string password;
		private string smtpServerAddress;
		private int smtpServerPort;

        /// <summary>
        /// Пустой конструктор.
        /// </summary>
		public EmailService()
		{
			GetConfigurationFromFile();
			_ = ConfigureSmtpClientAsync();
		}

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="senderEmail">e-mail отправителя.</param>
        /// <param name="password">пароль.</param>
        /// <param name="smtpServerAddress">SMTP.</param>
        /// <param name="smtpServerPort">SMTP Port.</param>
		public EmailService(string senderEmail, string password, string smtpServerAddress, int smtpServerPort)
		{
			this.senderEmail = senderEmail ?? throw new ArgumentNullException(nameof(senderEmail));
			this.password = password ?? throw new ArgumentNullException(nameof(password));
			this.smtpServerAddress = smtpServerAddress ?? throw new ArgumentNullException(nameof(smtpServerAddress));
			this.smtpServerPort = smtpServerPort;

			_ = ConfigureSmtpClientAsync();
		}

		private async Task ConfigureSmtpClientAsync()
		{
			await Task.Run(ConfigureSmtpClient);
		}

		private void ConfigureSmtpClient()
		{
			_smtpClient = new SmtpClient()
			{
				Host = smtpServerAddress,
				Port = smtpServerPort,
				Credentials = new NetworkCredential(senderEmail, password),
				EnableSsl = true,
			};
		}

		private void GetConfigurationFromFile ()
		{
			try
			{
				DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof((string,string,string,int)));
				using (FileStream fs = new FileStream("emailConfig.json", FileMode.OpenOrCreate))
				{
					var settings = ((string senderEmail, string password, string smtpServerAddress, int smtpServerPort))jsonFormatter.ReadObject(fs);

					senderEmail = settings.senderEmail;
					password = settings.password;
					smtpServerAddress = settings.smtpServerAddress;
					smtpServerPort = settings.smtpServerPort;
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
			var mailMessage = new MailMessage(new MailAddress(senderEmail), new MailAddress(to));

			if (attachment != null)
			{
				mailMessage.Attachments.Add(attachment ?? null);
			}
			
			await _smtpClient.SendMailAsync(mailMessage);
		}
	}
}
