using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailEntities
{
    public enum EmailFolderChangeType
    {
        Added, Deleted
    }
    public class EmailFolderChangeEventArgs
    {
        public EmailFolderChangeType ChangeType { get; set; }
        public Email Email { get; set; }
    }
}
