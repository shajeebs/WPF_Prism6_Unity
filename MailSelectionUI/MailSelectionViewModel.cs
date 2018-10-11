using EmailEntities;
using EmailInterfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSelectionUI
{
    public class MailSelectionViewModel : BindableBase
    {
        private IEmailService _emailService;

        public MailSelectionViewModel(IEmailService emailService)
        {
            this._emailService = emailService;
        }
        public IEnumerable<EmailFolder> Folders
        {
            get
            {
                return _emailService.MailFolders;
            }
        }
    }
}
