using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Apostas
{
    public class ApostaJogoEntryViewModel : Domain.Entities.ValueObjects.JogoUsuarioVO
    {
        #region Constants

        private const string FormatIcon = "/Content/img/database/times/{0}.gif";

        #endregion

        #region Properties

        public new int? ApostaTime1
        {
            get { return base.ApostaTime1; }
            set
            {
                base.ApostaTime1 = value;
                this.SalvarApostaTime1 = value;
            }
        }
        public new int? ApostaTime2
        {
            get { return base.ApostaTime2; }
            set
            {
                base.ApostaTime2 = value;
                this.SalvarApostaTime2 = value;
            }
        }
        public int? SalvarApostaTime1 { get; set; }
        public int? SalvarApostaTime2 { get; set; }

        public new string NomeTime1
        {
            get
            {
                if (!string.IsNullOrEmpty(this.NomeTimeResult1))
                    return this.NomeTimeResult1;
                else if (!string.IsNullOrEmpty(base.NomeTime1))
                    return base.NomeTime1;
                else
                    return "";
            }
        }
        public new string NomeTime2
        {
            get
            {
                if (!string.IsNullOrEmpty(this.NomeTimeResult2))
                    return this.NomeTimeResult2;
                else if (!string.IsNullOrEmpty(base.NomeTime2))
                    return base.NomeTime2;
                else
                    return "";
            }
        }
        public string ImageTime1 
        {
            get
            {
                return string.Format(FormatIcon, this.NomeTime1);
                //if (!string.IsNullOrEmpty (this.NomeTimeResult1))
                //    return string.Format (FormatIcon, this.NomeTimeResult1);
                //else if (!string.IsNullOrEmpty(base.NomeTime1))
                //    return string.Format (FormatIcon, base.NomeTime1);
                //else
                //    return null;
            }
        }
        public string ImageTime2
        {
            get
            {
                return string.Format(FormatIcon, this.NomeTime2);
                //if (!string.IsNullOrEmpty (this.NomeTimeResult2))
                //    return string.Format (FormatIcon, this.NomeTimeResult2);
                //else if (!string.IsNullOrEmpty(this.NomeTime2))
                //    return string.Format (FormatIcon, this.NomeTime2);
                //else
                //    return null;
            }
        }

        public bool IsLocked { get; set; }
        public bool IsPending
        {
            get { return base.DataAposta == null; }
        }
        public bool IsChanged
        {
            get
            {
                if (ApostaTime1 != SalvarApostaTime1)
                    return true;
                else if (ApostaTime2 != SalvarApostaTime2)
                    return true;

                return false;
            }
        }
        
        #endregion
    }
}
