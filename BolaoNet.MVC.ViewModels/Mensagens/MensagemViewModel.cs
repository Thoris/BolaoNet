using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Mensagens
{
    public class MensagemViewModel
    {
        #region Properties

        public string NomeBolao { get; set; }       
        public long MessageID { get; set; }

        [DisplayName("Nome Completo")]
        public string FromFullName { get; set; }
        public long AnsweredMessageID { get; set; }
        public int TotalRead { get; set; }


        [DisplayName("De")]
        public string FromUser { get; set; }

        [DisplayName("Para")]
        [Required(ErrorMessage = "O destinatário precisa ser preenchido.")]
        public string ToUser { get; set; }

        [DisplayName("Privada")]
        public bool Private { get; set; }

        [DisplayName("Data")]
        public DateTime CreationDate { get; set; }

        [DisplayName("Título")]
        //[Required(ErrorMessage = "O título precisa ser preenchido.")]
        public string Title { get; set; }
        
        [DisplayName("Mensagem")]
        [Required(ErrorMessage = "A mensagem precisa ser preenchida.")]        
        public string Message { get; set; }

        #endregion
    }
}
