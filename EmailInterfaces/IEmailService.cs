using EmailEntities;
using System.Collections.Generic;

namespace EmailInterfaces
{
    public class IEmailService
    {
        List<EmailFolder> MailFolders { get; }
        void SendMail(Email email);
        void DeleteMail(Email email);
    }
}
