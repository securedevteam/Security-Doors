using SecurityDoors.PresentationLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Implementations
{
	public class SmtpClientService : ISmtpClientService
	{
		private SmtpClient _smtpClient;
		private string senderEmail;
		private string password;
		private string smtpServerAddress;
		private int smtpServerPort;

		public SmtpClientService()
		{
			GetConfigurationFromFile();
			_ = ConfigureSmtpClientAsync();
		}

		public SmtpClientService(string senderEmail, string password, string smtpServerAddress, int smtpServerPort)
		{
			_ = ConfigureSmtpClientAsync(senderEmail,password,smtpServerAddress,smtpServerPort);
		}

		private async Task ConfigureSmtpClientAsync()
		{
			await Task.Run(ConfigureSmtpClient);
		}
		public async Task ConfigureSmtpClientAsync(string senderEmail, string password, string smtpServerAddress, int smtpServerPort)
		{
			this.senderEmail = senderEmail ?? throw new ArgumentNullException(nameof(senderEmail));
			this.password = password ?? throw new ArgumentNullException(nameof(password));
			this.smtpServerAddress = smtpServerAddress ?? throw new ArgumentNullException(nameof(smtpServerAddress));
			this.smtpServerPort = smtpServerPort;

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

		}

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
