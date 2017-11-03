using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Users
{
    public class UserConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Users.User>
    {
        #region Constants

        public const int NomeLen = 50;

        #endregion

        #region Constructors/Destructors

        public UserConfiguration()
        {
            ToTable("Usuarios");

            Property(c => c.UserName)
                .HasMaxLength(NomeLen);

            Property(c => c.ApprovedBy)
                .HasMaxLength(NomeLen);

            Property(c => c.CellPhone)
                .HasMaxLength(30);

            Property(c => c.City)
                .HasMaxLength(150);

            Property(c => c.Comments)
                .HasMaxLength(255);

            Property(c => c.CompanyPhone)
                .HasMaxLength(30);

            Property(c => c.Country)
                .HasMaxLength(50);

            Property(c => c.CPF)
                .HasMaxLength(20);

            Property(c => c.Email)
                .HasMaxLength(150);

            Property(c => c.FullName)
                .HasMaxLength(250);

            Property(c => c.MSN)
                .HasMaxLength(100);

            Property(c => c.Password)
                .HasMaxLength(50);

            Property(c => c.PasswordAnswer)
                .HasMaxLength(50);

            Property(c => c.PasswordQuestion)
                .HasMaxLength(100);

            Property(c => c.PhoneNumber)
                .HasMaxLength(30);

            Property(c => c.PostalCode)
                .HasMaxLength(20);

            Property(c => c.RequestedBy)
                .HasMaxLength(NomeLen);

            Property(c => c.RG)
                .HasMaxLength(20);

            Property(c => c.Skype)
                .HasMaxLength(20);

            Property(c => c.State)
                .HasMaxLength(20);

            Property(c => c.Street)
                .HasMaxLength(150);




        }

        #endregion
    }
}
