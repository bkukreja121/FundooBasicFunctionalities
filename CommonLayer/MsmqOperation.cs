using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonLayer
{
    public class MsmqOperation
    {
        MessageQueue msmq = new MessageQueue();

        public void SendData(string token)
        {
            //Setting the QueuPath where we want to store the messages.
            msmq.Path = @".\private$\tokenQueue";

            if (!MessageQueue.Exists(msmq.Path))
            {

                // Creates the new queue named "tokenQueue"

                MessageQueue.Create(msmq.Path);

            }
            sendData2Queue(token);

        }

        private void sendData2Queue(string token)
        {
            msmq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            msmq.ReceiveCompleted += Msmq_ReceiveCompleted;
            msmq.Send(token);
            msmq.BeginReceive();
            msmq.Close();

        }

        private void Msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                var msg = msmq.EndReceive(e.AsyncResult);

                string token = msg.Body.ToString();
                // Process the logic be sending the message
                SendMail(token);
                //Restart the asynchronous receive operation.

                msmq.BeginReceive();


            
            }
            catch (MessageQueueException qexception)
            {
                throw;
            }
        }
        private void SendMail(string token)
        {
            using (MailMessage mail = new MailMessage())
            {
                var tokenId = token;
                var link = "localhost:44337/api/user/resetpassword/";
                var final = link + tokenId;
                mail.From = new MailAddress("bhavishkukreja16@gmail.com");
                mail.To.Add("bhavishkukreja16@gmail.com");
                mail.Subject = "Hello World";
                //mail.Body = "Please<a href='" + link +  "'>" + tokenId + "</a> ";
                mail.Body = "CLICK HERE TO RESET PASSWORD!!<br></br><a href='http://" + final + "'>click here</a>";
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("bhavishkukreja16@gmail.com", "942240Bhavish@");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
    }

