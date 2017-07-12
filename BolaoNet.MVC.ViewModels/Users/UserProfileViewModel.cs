﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users
{
    public class UserProfileViewModel
    {
        #region Properties


        [DisplayName("Login")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome Completo é obrigatório.")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "O campo Nome completo deve ter entre 10 à 250 caracteres.")]
        [DisplayName("Nome Completo *")]
        public string FullName { get; set; }

        [DisplayName("Sexo")]
        public bool? Male { get; set; }

        [DataType(DataType.Date, ErrorMessage = "O campo precisa ser uma data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Data de Nascimento {yyyy-MM-dd}")]
        public Nullable<DateTime> BirthDate { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Formato de telefone inválido")]
        [Phone(ErrorMessage = "O telefone de entrada não é válido.")]
        [DisplayName("Telefone")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email de entrada não é válido")]
        [DisplayName("Email *")]
        public string Email { get; set; }

        [DisplayName("Quero receber emails")]
        public bool ReceiveEmails { get; set; }

        public string CellPhone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public int? StreetNumber { get; set; }
        public string PostalCode { get; set; }


        #endregion
    }
}
