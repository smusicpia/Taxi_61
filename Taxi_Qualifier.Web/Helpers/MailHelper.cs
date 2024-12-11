using Microsoft.Extensions.Configuration;
//using MimeKit;
using System;
using Taxi_Qualifier.Common.Models;
//using MailKit.Net.Smtp;
using System.Net.Mail;
using System.Net;

namespace Taxi_Qualifier.Web.Helpers
{
    public class MailHelper : IMailHelper
    {
        private readonly IConfiguration _configuration;

        public MailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Response SendMail(string to, string subject, string body)
        {
            try
            {
                string from = _configuration["Mail:From"];
                string smtp = _configuration["Mail:Smtp"];
                string port = _configuration["Mail:Port"];
                string password = _configuration["Mail:Password"];
                string[] displayNameFrom = from.Split('@');
                string[] displayNameTo = to.Split('@');
                
                MailAddress addressFrom = new MailAddress(from, displayNameFrom[0]);
                MailAddress addressTo = new MailAddress(to, displayNameTo[1]);
                MailMessage message = new MailMessage(addressFrom, addressTo);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = int.Parse(port);
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(from, password);
                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.TraceInformation("Exception caught in CreateTestMessage2():{0}", ex.ToString());
                        throw;
                    }
                }

                //MimeMessage message = new MimeMessage();
                //message.From.Add(new MailboxAddress(from));
                //message.To.Add(new MailboxAddress(to));
                //message.Subject = subject;
                //BodyBuilder bodyBuilder = new BodyBuilder
                //{
                //    HtmlBody = body
                //};
                //message.Body = bodyBuilder.ToMessageBody();

                //using (SmtpClient client = new SmtpClient())
                //{
                //    client.Connect(smtp, int.Parse(port), false);
                //    client.Authenticate(from, password);
                //    client.Send(message);
                //    client.Disconnect(true);
                //}

                return new Response { IsSuccess = true };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = ex
                };
            }
        }
    }
}
