﻿using System;
using System.Collections.Generic;
namespace EmailEntities
{
    public class EmailFolder
    {
        private List<Email> emails;

        public event EventHandler<EmailFolderChangeEventArgs> EmailChanged;
        public EmailFolder()
            : this(new List<Email>())
        {
        }
        public EmailFolder(params Email[] emails)
            : this((IEnumerable<Email>)emails)
        {
        }
        public EmailFolder(IEnumerable<Email> emails)
        {
            this.emails = new List<Email>();
            foreach (Email email in emails)
            {
                email.Enfolder(this);
            }
        }
        public string Name { get; set; }
        public IEnumerable<Email> Emails
        {
            get
            {
                IEnumerable<Email> copy;
                lock (emails)
                {
                    copy = new List<Email>(emails);
                }
                return copy;
            }
        }

        internal void AddMail(Email email)
        {
            lock (emails)
            {
                emails.Add(email);
            }
            FireEmailChanged(EmailFolderChangeType.Added, email);
        }
        internal void DeleteMail(Email email)
        {
            lock (emails)
            {
                emails.Remove(email);
            }
            FireEmailChanged(EmailFolderChangeType.Deleted, email);
        }
       internal void FireEmailChanged(EmailFolderChangeType changeType, Email email)
        {
            if(EmailChanged != null)
            {
                EmailChanged(this, new EmailFolderChangeEventArgs()
                {
                    ChangeType = changeType,
                    Email = email
                });
            }
        }
    }
}