using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application
{
    public class FactoryApp : Domain.Interfaces.Services.IFactoryService
    {
        #region Variables

        private string _userName;
        private string _url;
        private static Domain.Interfaces.Services.IFactoryService _factorySevice;
        
        #endregion

        #region Constructors/Destructors

        public FactoryApp(Domain.Interfaces.Services.IFactoryService factoryService)
        {
            _factorySevice = factoryService;
        }
        public FactoryApp(string userName, string url)
        {
            _userName = userName;
            _url = url;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que retorna o tipo de conexão que deve ser realizado para acesso à base de dados.
        /// </summary>
        /// <returns>Tipo de acesso à dados configurado.</returns>
        private ServiceType GetServiceType()
        {
            //Buscando a configuração do tipo de acesso à dados
            string serviceType = System.Configuration.ConfigurationManager.AppSettings["FactoryServiceType"];

            //Se existe informação configurada para o tipo de acesso
            if (!string.IsNullOrEmpty(serviceType))
            {
                //Verificando qual tipo corresponde ao configurado
                string[] serviceTypes = Enum.GetNames(typeof(ServiceType));

                //Buscando qual tipo se encaixa
                for (int c = 0; c < serviceTypes.Length; c++)
                {
                    //Se encontrou a descrição do tipo de conexão
                    if (string.Compare(serviceType, serviceTypes[c], true) == 0)
                    {
                        return (ServiceType)c;
                    }
                    //Se encontrou o índice do tipo de conexão
                    else if (string.Compare(serviceType, c.ToString(), true) == 0)
                    {
                        return (ServiceType)c;
                    }//endif

                }//end for c

            }//endif tipo de conexão à dados

            return ServiceType.RestFull;
        }
        /// <summary>
        /// Método que retorna o objeto de fábrica de objetos para acesso à banco de dados.
        /// </summary>
        /// <returns>Objeto que possui a fábrica de objetos de conexão com o banco de dados.</returns>
        private Domain.Interfaces.Services.IFactoryService GetFactoryService()
        {
            //Se o objeto de conexão ainda não foi criado
            if (_factorySevice == null)
            {
                
                switch (GetServiceType())
                {
                    case ServiceType.Directly:

                        _factorySevice = new Domain.Services.FactoryService();

                        break;

                    case ServiceType.RestFull:

                        _factorySevice = new WebApi.Integration.FactoryIntegration(_userName, _url);

                        break;

                }

            }//endif factoryDao == null

            return _factorySevice;
        }

        #endregion

        #region IFactoryService members

        public Domain.Interfaces.Services.Boloes.IApostaExtraService CreateApostaExtraService()
        {
            return new Boloes.ApostaExtraApp(GetFactoryService().CreateApostaExtraService());
        }

        public Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService CreateApostaExtraUsuarioService()
        {
            return new Boloes.ApostaExtraUsuarioApp(GetFactoryService().CreateApostaExtraUsuarioService());
        }

        public Domain.Interfaces.Services.Boloes.IApostaPontosService CreateApostaPontosService()
        {
            return new Boloes.ApostaPontosApp(GetFactoryService().CreateApostaPontosService());
        }

        public Domain.Interfaces.Services.Boloes.IApostasRestantesService CreateApostasRestantesService()
        {
            return new Boloes.ApostasRestantesApp(GetFactoryService().CreateApostasRestantesService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoService CreateBolaoService()
        {
            return new Boloes.BolaoApp(GetFactoryService().CreateBolaoService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService CreateBolaoCampeonatoClassificacaoUsuarioService()
        {
            return new Boloes.BolaoCampeonatoClassificacaoUsuarioApp(GetFactoryService().CreateBolaoCampeonatoClassificacaoUsuarioService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService CreateBolaoCriterioPontosService()
        {
            return new Boloes.BolaoCriterioPontosApp(GetFactoryService().CreateBolaoCriterioPontosService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService CreateBolaoCriterioPontosTimesService()
        {
            return new Boloes.BolaoCriterioPontosTimesApp(GetFactoryService().CreateBolaoCriterioPontosTimesService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoMembroService CreateBolaoMembroService()
        {
            return new Boloes.BolaoMembroApp(GetFactoryService().CreateBolaoMembroService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService CreateBolaoMembroClassificacaoService()
        {
            return new Boloes.BolaoMembroClassificacaoApp(GetFactoryService().CreateBolaoMembroClassificacaoService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService CreateBolaoMembroGrupoService()
        {
            return new Boloes.BolaoMembroGrupoApp(GetFactoryService().CreateBolaoMembroGrupoService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService CreateBolaoPontoRodadaService()
        {
            return new Boloes.BolaoPontoRodadaApp(GetFactoryService().CreateBolaoPontoRodadaService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService CreateBolaoPontoRodadaUsuarioService()
        {
            return new Boloes.BolaoPontoRodadaUsuarioApp(GetFactoryService().CreateBolaoPontoRodadaUsuarioService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService CreateBolaoPontuacaoService()
        {
            return new Boloes.BolaoPontuacaoApp(GetFactoryService().CreateBolaoPontuacaoService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPremioService CreateBolaoPremioService()
        {
            return new Boloes.BolaoPremioApp(GetFactoryService().CreateBolaoPremioService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoRegraService CreateBolaoRegraService()
        {
            return new Boloes.BolaoRegraApp(GetFactoryService().CreateBolaoRegraService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoRequestService CreateBolaoRequestService()
        {
            return new Boloes.BolaoRequestApp(GetFactoryService().CreateBolaoRequestService());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService CreateBolaoRequestStatusService()
        {
            return new Boloes.BolaoRequestStatusApp(GetFactoryService().CreateBolaoRequestStatusService());
        }

        public Domain.Interfaces.Services.Boloes.ICriterioService CreateCriterioService()
        {
            return new Boloes.CriterioApp(GetFactoryService().CreateCriterioService());
        }

        public Domain.Interfaces.Services.Boloes.IJogoUsuarioService CreateJogoUsuarioService()
        {
            return new Boloes.JogoUsuarioApp(GetFactoryService().CreateJogoUsuarioService());
        }

        public Domain.Interfaces.Services.Boloes.IMensagemService CreateMensagemService()
        {
            return new Boloes.MensagemApp(GetFactoryService().CreateMensagemService());
        }

        public Domain.Interfaces.Services.Boloes.IPagamentoService CreatePagamentoService()
        {
            return new Boloes.PagamentoApp(GetFactoryService().CreatePagamentoService());
        }

        public Domain.Interfaces.Services.Boloes.IPontuacaoService CreatePontuacaoService()
        {
            return new Boloes.PontuacaoApp(GetFactoryService().CreatePontuacaoService());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoService CreateCampeonatoService()
        {
            return new Campeonatos.CampeonatoApp(GetFactoryService().CreateCampeonatoService());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService CreateCampeonatoClassificacaoService()
        {
            return new Campeonatos.CampeonatoClassificacaoApp(GetFactoryService().CreateCampeonatoClassificacaoService());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService CreateCampeonatoFaseService()
        {
            return new Campeonatos.CampeonatoFaseApp(GetFactoryService().CreateCampeonatoFaseService());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService CreateCampeonatoGrupoService()
        {
            return new Campeonatos.CampeonatoGrupoApp(GetFactoryService().CreateCampeonatoGrupoService());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService CreateCampeonatoGrupoTimeService()
        {
            return new Campeonatos.CampeonatoGrupoTimeApp(GetFactoryService().CreateCampeonatoGrupoTimeService());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService CreateCampeonatoHistoricoService()
        {
            return new Campeonatos.CampeonatoHistoricoApp(GetFactoryService().CreateCampeonatoHistoricoService());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService CreateCampeonatoPosicaoService()
        {
            return new Campeonatos.CampeonatoPosicaoApp(GetFactoryService().CreateCampeonatoPosicaoService());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoRecordService CreateCampeonatoRecordService()
        {
            return new Campeonatos.CampeonatoRecordApp(GetFactoryService().CreateCampeonatoRecordService());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService CreateCampeonatoTimeService()
        {
            return new Campeonatos.CampeonatoTimeApp(GetFactoryService().CreateCampeonatoTimeService());
        }

        public Domain.Interfaces.Services.Campeonatos.IHistoricoService CreateHistoricoService()
        {
            return new Campeonatos.HistoricoApp(GetFactoryService().CreateHistoricoService());
        }

        public Domain.Interfaces.Services.Campeonatos.IJogoService CreateJogoService()
        {
            return new Campeonatos.JogoApp(GetFactoryService().CreateJogoService());
        }

        public Domain.Interfaces.Services.Campeonatos.IPontuacaoService CreateCampeonatoPontuacaoService()
        {
            return new Campeonatos.PontuacaoApp(GetFactoryService().CreateCampeonatoPontuacaoService());
        }

        public Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService CreateCriterioFixoService()
        {
            return new DadosBasicos.CriterioFixoApp(GetFactoryService().CreateCriterioFixoService ());
        }

        public Domain.Interfaces.Services.DadosBasicos.IEstadioService CreateEstadioService()
        {
            return new DadosBasicos.EstadioApp(GetFactoryService().CreateEstadioService ());
        }

        public Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService CreatePagamentoTipoService()
        {
            return new DadosBasicos.PagamentoTipoApp(GetFactoryService().CreatePagamentoTipoService());
        }

        public Domain.Interfaces.Services.DadosBasicos.ITimeService CreateTimeService()
        {
            return new DadosBasicos.TimeApp(GetFactoryService().CreateTimeService());
        }

        public Domain.Interfaces.Services.Users.IRoleService CreateRoleService()
        {
            return new Users.RoleApp(GetFactoryService().CreateRoleService());
        }

        public Domain.Interfaces.Services.Users.IUserService CreateUserService()
        {
            return new Users.UserApp(GetFactoryService().CreateUserService());
        }

        public Domain.Interfaces.Services.Users.IUserInRoleService CreateUserInRoleService()
        {
            return new Users.UserInRoleApp(GetFactoryService().CreateUserInRoleService());
        }

        public Domain.Interfaces.Services.Facade.IBolaoFacadeService CreateBolaoFacadeService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Facade.ICampeonatoFacadeService CreateCampeonatoFacadeService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Facade.IInitializationFacadeService CreateInitializationFacadeService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Facade.IUserFacadeService CreateUserFacadeService()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
