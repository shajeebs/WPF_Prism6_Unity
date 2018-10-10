﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
namespace EmailEntities
{
    public class EmailFolder
    {
        public event EventHandler<EmailForlderChangeEventArgs> EmailChanged;
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
                Emails.Add(email);
            }
            FireEmailChanged(EmailForlderChangeType.Added, email);
        }
        internal void DeleteMail(Email email)
        {
            lock (emails)
            {
                Emails.Remove(email);
            }
            FireEmailChanged(EmailForlderChangeType.Deleted, email);
        }
       // internal void FireEmailChanged
    }
}