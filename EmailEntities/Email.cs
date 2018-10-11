using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailEntities
{
    public class Email
    {
        public Email()
        {
            this.Id = Guid.NewGuid();
        }

        EmailFolder _folder;
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Sent { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public void Delete() {
            if (this._folder != null)
                this._folder.DeleteMail(this);
        }
        public void Enfolder(EmailFolder folder) {
            this.Delete();
            this._folder = folder;
            this._folder.AddMail(this);
        }
        public static Email Create() {
            var email = new Email()
            {
                From = "",
                To = "",
                Sent = DateTime.Now,
            };

            email.Subject = string.Format("Email {0} Subject line", email.Id);
            email.Body = string.Format("Email {0} Body Text", email.Id);
            return email;
        }
    }
}
