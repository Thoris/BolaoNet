using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail
{
    public class TagValue
    {
        #region Properties

        public string Tag { get; set; }
        public string Value { get; set; }

        #endregion

        #region Constructors/Destructors

        public TagValue(string tag, string value)
        {
            this.Tag = tag;
            this.Value = value;
        }

        #endregion
    }
}
