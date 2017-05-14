using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Users
{
    public class User : Base.AuditModel
    {
        #region Properties
        [NotMapped]
        public string FirstName
        {
            get
            {
                string[] name = this.FullName.Split(' ');

                return name[0];
            }
        }
        [NotMapped]
        public string MiddleName
        {
            get
            {
                string[] name = this.FullName.Split(' ');

                string result = "";

                for (int c = 1; c < name.Length - 1; c++)
                    result += " " + name[c];

                return result.Trim();
            }
        }
        [NotMapped]
        public string LastName
        {
            get
            {
                string[] name = this.FullName.Split(' ');

                if (name.Length - 1 > 0)
                    return name[name.Length - 1];
                else
                    return "";

            }
        }

        //[StringLength(25)]
        [Key]        
        public string UserName { get; set; }
        public string Password{ get; set; }
        public int PasswordFormat{ get; set; }
        public string PasswordQuestion{ get; set; }
        public string PasswordAnswer{ get; set; }
        public string FullName{ get; set; }
        public string Email{ get; set; }
        public DateTime ? BirthDate{ get; set; }
        public bool ? Male{ get; set; }
        public string CellPhone{ get; set; }
        public string PhoneNumber{ get; set; }
        public string CompanyPhone{ get; set; }
        public string City{ get; set; }
        public string Country{ get; set; }
        public string State{ get; set; }
        public string Street{ get; set; }
        public int ? StreetNumber{ get; set; }

        public string PostalCode{ get; set; }

        public int ? Marital{ get; set; }

        public string CPF{ get; set; }
        public string RG{ get; set; }
        public string MSN{ get; set; }
        public string Skype{ get; set; }
        public bool IsLockedOut{ get; set; }
        public bool IsApproved{ get; set; }
        public DateTime ? LastActivityDate{ get; set; }
        public DateTime ? LastLockoutDate{ get; set; }
        public DateTime ? LastPasswordChangedDate{ get; set; }
        public DateTime ? LastLoginDate{ get; set; }
        public int ? FailedPasswordAttemptCount{ get; set; }
        public DateTime ? FailedPasswordAttemptWindowStart{ get; set; }
        public int ? FailedPasswordAnswerAttemptCount{ get; set; }
        public DateTime ? FailedPasswordAnswerAttemptWindowStart{ get; set; }
        public string Comments{ get; set; }

        public string ActivateKey{ get; set; }
        public bool ReceiveEmails{ get; set; }
        public string RequestedBy{ get; set; }
        public DateTime ? RequestedDate{ get; set; }
        public string ApprovedBy{ get; set; }
        public DateTime ? ApprovedDate{ get; set; }

        public bool IsOnline{ get; set; }
        public bool IsAdmin { get; set; }

        #endregion

        #region Constructors/Destructors

        public User()
        {

        }
        public User(string userName)
        {
            this.UserName = userName;
        }

        #endregion
    }
}
