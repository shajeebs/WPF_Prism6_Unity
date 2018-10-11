using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EmailInterfaces;
using EmailEntities;

namespace EmailServices.Services
{
    public class EmailService : IEmailService
    {
        public List<EmailFolder> MailFolders { get; private set; }
        public EmailService()
        {
            CreateMailFolders();
            Timer tmr = new Timer((o) => {
                Email email = Email.Create();
                email.Enfolder(MailFolders[0]);
            });
            tmr.Change(0, 10000);
        }

        void CreateMailFolders()
        {
            MailFolders = new List<EmailFolder>()
            {
                new EmailFolder(Email.Create()){ Name = "Inbox"},
                new EmailFolder(){ Name = "Sent Items"},
            };
        }

        public void SendMail(Email email)
        {
            email.Enfolder(MailFolders[1]);
        }

        public void DeleteMail(Email email)
        {
            email.Delete();
        }
    }
}
