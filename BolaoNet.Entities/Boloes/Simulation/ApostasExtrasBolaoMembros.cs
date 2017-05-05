using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes.Simulation
{
    public class ApostasExtrasBolaoMembros : BolaoMembro
    {
        #region Variables

        private IList<Entities.Boloes.ApostaExtraUsuario> _listApostasExtras = new List<Entities.Boloes.ApostaExtraUsuario>();

        #endregion

        #region Properties
        public int Difference
        {
            get { return this.TotalPontosCalculado - this.LastPontos; }
        }
        public int TotalPontosCalculado
        {
            get
            {
                int totalPontos = 0;

                for (int c = 0; c < _listApostasExtras.Count; c++)
                {
                    if (_listApostasExtras[c].Pontos != null)
                        totalPontos += (int) _listApostasExtras[c].Pontos;
                }

                return totalPontos + this.LastPontos;
            }
        }
        public int LastPontos { get; set; }
        public new int LastPosicao { get; set; }
        public IList<Entities.Boloes.ApostaExtraUsuario> ListApostasExtras
        {
            get { return _listApostasExtras; }
            set { _listApostasExtras = value; }
        }

        public string Campeao
        {
            get
            {
                if (_listApostasExtras.Count > 0)
                    return _listApostasExtras[0].NomeTime;
                else
                    return null;

            }
        }
        public string ViceCampeao
        {
            get
            {
                if (_listApostasExtras.Count > 1)
                    return _listApostasExtras[1].NomeTime;
                else
                    return null;

            }
        }
        public string Terceiro
        {
            get
            {
                if (_listApostasExtras.Count > 2)
                    return _listApostasExtras[2].NomeTime;
                else
                    return null;

            }
        }
        public string QuartoLugar
        {
            get
            {
                if (_listApostasExtras.Count > 3)
                    return _listApostasExtras[3].NomeTime;
                else
                    return null;

            }
        }
        #endregion

        #region Constructors/Destructors

        public ApostasExtrasBolaoMembros()
        {

        }

        #endregion
    }
}
