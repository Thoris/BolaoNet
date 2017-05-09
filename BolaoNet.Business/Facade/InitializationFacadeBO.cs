using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Facade
{
    public class InitializationFacadeBO : Interfaces.Facade.IInitializationFacadeBO
    {
        #region Variables

        private Interfaces.DadosBasicos.ICriterioFixoBO _criterioFixoBO;
        private Interfaces.DadosBasicos.IPagamentoTipoBO _pagamentoTipoBO;
        private Interfaces.Users.IRoleBO _roleBO;
        private Interfaces.Users.IUserBO _userBO;
        private Interfaces.Users.IUserInRoleBO _userInRoleBO;

        #endregion

        #region Constructors/Destructors

        public InitializationFacadeBO(Interfaces.IFactoryBO factory)
        {
            _criterioFixoBO = factory.CreateCriterioFixoBO();
            _pagamentoTipoBO = factory.CreatePagamentoTipoBO();
            _roleBO = factory.CreateRoleBO();
            _userBO = factory.CreateUserBO();
            _userInRoleBO = factory.CreateUserInRoleBO();
        }

        #endregion

        #region IInitializationFacadeBO members
        
        public bool InitAll()
        {
            InsertList<Entities.Users.User>((Base.IGenericBusiness<Entities.Users.User>)_userBO, GetMainUsers());
            InsertList<Entities.Users.Role>((Base.IGenericBusiness<Entities.Users.Role>)_roleBO, GetRoles());
            InsertList<Entities.Users.UserInRole>((Base.IGenericBusiness<Entities.Users.UserInRole>)_roleBO, GetUsersInRoles());

            InsertList<Entities.DadosBasicos.CriterioFixo>((Base.IGenericBusiness<Entities.DadosBasicos.CriterioFixo>)_userBO, GetCriteriosFixos());
            InsertList<Entities.DadosBasicos.PagamentoTipo>((Base.IGenericBusiness<Entities.DadosBasicos.PagamentoTipo>)_userBO, GetPagamentoTipo());            


            return true;
        }
        public int InsertList<T>(Base.IGenericBusiness<T> bo, IList<T> list)
        {
            int total = 0;

            for (int c = 0; c < list.Count; c++)
            {
                T loadedEntry = bo.Load(list[c]);

                if (loadedEntry == null)
                {
                    if (bo.Insert(list[c]) > 0)
                        total++;
                }
            }

            return total;
        }


        public IList<Entities.Users.User> GetMainUsers()
        {
            IList<Entities.Users.User> list = new List<Entities.Users.User>();

            list.Add(new Entities.Users.User()
            {
                UserName ="Admin",
                IsAdmin = true,
                IsApproved = true,                
            });

            return list;
        }
        public IList<Entities.Users.Role> GetRoles()
        {
            IList<Entities.Users.Role> list = new List<Entities.Users.Role>();

            list.Add(new Entities.Users.Role()
            {
                RoleName = "Administrador",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Apostador",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Convidado",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Gerenciador de Avisos",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Gerenciador de Bolão",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Gerenciador de Critérios",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Gerenciador de Dados Básicos",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Gerenciador de Enquetes",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Gerenciador de Mensagens",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Gerenciador de Pagamentos",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Gerenciador de Pontuação",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Gerenciador de Publicidade",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Gerenciador de Resultados",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Visitante de Bolão",
                Descricao = ""
            });
            list.Add(new Entities.Users.Role()
            {
                RoleName = "Visitante de Campeonato",
                Descricao = ""
            });

            return list;
        }
        public IList<Entities.Users.UserInRole> GetUsersInRoles()
        {
            IList<Entities.Users.UserInRole> list = new List<Entities.Users.UserInRole>();

            list.Add(new Entities.Users.UserInRole()
            {
                UserName = "Admin",
                RoleName = "Administrador",                
            });

            return list;
        }

        public IList<Entities.DadosBasicos.CriterioFixo> GetCriteriosFixos()
        {
            IList<Entities.DadosBasicos.CriterioFixo> list = new List<Entities.DadosBasicos.CriterioFixo>();

            int c = 1;
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Empate"
            }); 
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Vitória"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Derrota"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Ganhador"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Perdedor"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Time 1"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Time 2"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Vitória/Empate/Derrota"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Erro"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Ganhador Fora"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Ganhador Dentro"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Perdedor Fora"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Perdedor Dentro"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Empate Gols"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Gols Time 1"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Gols Time 2"
            });
            list.Add(new Entities.DadosBasicos.CriterioFixo()
            {
                CriterioId = c++,
                Descricao = "Cheio"
            });

            return list;
        }        
        public IList<Entities.DadosBasicos.PagamentoTipo> GetPagamentoTipo()
        {
            IList<Entities.DadosBasicos.PagamentoTipo> list = new List<Entities.DadosBasicos.PagamentoTipo>();

            int c = 1;
            list.Add(new Entities.DadosBasicos.PagamentoTipo()
            {
                TipoPagamento = c++,
                Descricao = "Dinheiro"
            }); 
            list.Add(new Entities.DadosBasicos.PagamentoTipo()
            {
                TipoPagamento = c++,
                Descricao = "Cheque"
            }); 
            list.Add(new Entities.DadosBasicos.PagamentoTipo()
            {
                TipoPagamento = c++,
                Descricao = "Depósito"
            });

            return list;
        }        
         
        #endregion



    }
}
