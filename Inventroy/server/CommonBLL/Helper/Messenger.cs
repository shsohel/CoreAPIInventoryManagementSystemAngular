using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonBLL.Helper
{
    public static class Messenger
    {
        public static bool SendConfirmMailWithHTMLFormat(MessengeDetails messengeDetails)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(messengeDetails.ShopName, messengeDetails.MailForm));
                message.To.Add(new MailboxAddress(messengeDetails.MailToUserName, messengeDetails.MailTo));
                message.Subject = messengeDetails.MessageSubject;
                BodyBuilder builder = new BodyBuilder();
                builder.HtmlBody = messengeDetails.MessageBodyInHTML;
                message.Body = builder.ToMessageBody();
                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate(messengeDetails.MailForm, messengeDetails.MailFormPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static string GetHTMLMessage(string Link, string UserName, string CampusName)
        {
            string message =
                    "<body>" +
                     "<div style ='background: #1DB9A4; height: 250px; width: 50%; margin: auto; color: white; text-transform: uppercase; padding-top: 5px'>" +
                        "<h1 style = 'font-weight: 600px; font-size: 60px;  line-height: 0px;' >" +
                        "<p style = 'text-align: center;'> Welcome!</p></h1>" +
                        "<p style = 'text-align: center;'>" + UserName + "</p>" +
                        "<p style = 'text-align: center;'> Thank you to be with us.</p>" +
                        "<p style = 'text-align: center;' > some one try to open a account at "+ CampusName + " </p> " + 
                        "<p style = 'text-align: center;' >if its not work send confirm link again</p>" +
                        "<p style = 'text-align: center;' > The purpose of this mail to confirm that it's you</p>" +
                      "</div>" +
                      "<div style = 'width: 50%; margin: auto;'>" +
                        "<p> Dear "+ UserName + ",</p>" +
                        "<p> We are pleased to let you know that your need to click the button bellow to verified successfully.</p>" +
                        " <p> Please click this button to continue your registration:</p>" +
                        " <a style = 'height: 2rem; widht: 2vm; background: #1DB9A4; color: white;  padding: .6rem; margin-top: 30px; text-decoration: none;'" +
                           " href='" + Link + "'>CONFIRM NOW</a>" +
                        "<p>If you nee please contact with us</p>" +
                        "<strong> Email: piasuddin50@gmail.com" +
                        "<p> This is an system generated e-mail.Please do not reply to this e-mail address.</p></strong>" +
                       "</div>" +
                     "</body> ";
            return message;
        }
        public static string GetPasswordResetHTMLMessage(string Link, string UserName)
        {
            string message =
                    "<body>" +
                     "<div style ='background: #1DB9A4; height: 250px; width: 50%; margin: auto; color: white; text-transform: uppercase; padding: 25px'>" +
                       "<h1>Hello! "+ UserName + "</h1>"+
                     "<p>Your Password rest link is below</p>"+
                       "<a href='"+ Link + "'>Reset Password</a>"+
                       "</div>" +
                     "</body> ";
            return message;
        }
    }
    public class MessengeDetails
    {
        public string MessageSubject { get; set; }
        public string MessageBodyInHTML { get; set; }
        public string MailForm { get; set; }
        public string MailFormPassword { get; set; }
        public string MailTo { get; set; }
        public string MailToUserName { get; set; }
        public string ShopName { get; set; }
    }
}
