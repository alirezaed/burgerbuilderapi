using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace BurgerBuilder.WebApi.Tools
{
	public class MailHelper
	{
		MailMessage mail;
		SmtpClient SmtpServer;
		string AdminsEmail = ConfigurationManager.AppSettings["AdminMail"];
		public MailHelper()
		{
			mail = new MailMessage();
			mail.From = new MailAddress("website.BurgerBuilder@gmail.com");
			SmtpServer = new SmtpClient("smtp.gmail.com");
			SmtpServer.Port = 587;
			SmtpServer.Credentials = new System.Net.NetworkCredential("website.BurgerBuilder@gmail.com", "#Ed123!!");
			SmtpServer.EnableSsl = true;
		}
		public bool SendMail(string subject,string body,string to)
		{
			try
			{
				mail.To.Add(to);
				mail.Subject = subject;
				mail.Body = body;
				SmtpServer.Send(mail);
				return true;
			}
			catch (Exception ex)
			{
				/*log*/
				return false;
			}
		}
		public bool SendMailToAdmin(string subject, string body)
		{
			return SendMail(subject, body, AdminsEmail);
		}

		
	}
}