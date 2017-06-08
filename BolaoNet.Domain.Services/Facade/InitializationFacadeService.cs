using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Facade
{
    public class InitializationFacadeService 
        : Interfaces.Services.Facade.IInitializationFacadeService
    {
        #region Variables

        private Interfaces.Services.DadosBasicos.ICriterioFixoService _criterioFixoBO;
        private Interfaces.Services.DadosBasicos.IPagamentoTipoService _pagamentoTipoBO;
        private Interfaces.Services.Users.IRoleService _roleBO;
        private Interfaces.Services.Users.IUserService _userBO;
        private Interfaces.Services.Users.IUserInRoleService _userInRoleBO;

        #endregion

        #region Constructors/Destructors

        public InitializationFacadeService(Interfaces.Services.IFactoryService factory)
        {
            _criterioFixoBO = factory.CreateCriterioFixoService();
            _pagamentoTipoBO = factory.CreatePagamentoTipoService();
            _roleBO = factory.CreateRoleService();
            _userBO = factory.CreateUserService();
            _userInRoleBO = factory.CreateUserInRoleService();
        }

        #endregion

        #region IInitializationFacadeBO members
        
        public bool InitAll()
        {
            InsertList<Entities.Users.User>((Interfaces.Services.Base.IGenericService<Entities.Users.User>)_userBO, GetMainUsers());
            InsertList<Entities.Users.Role>((Interfaces.Services.Base.IGenericService<Entities.Users.Role>)_roleBO, GetRoles());
            InsertList<Entities.Users.UserInRole>((Interfaces.Services.Base.IGenericService<Entities.Users.UserInRole>)_userInRoleBO, GetUsersInRoles());

            InsertList<Entities.DadosBasicos.CriterioFixo>((Interfaces.Services.Base.IGenericService<Entities.DadosBasicos.CriterioFixo>)_criterioFixoBO, GetCriteriosFixos());
            InsertList<Entities.DadosBasicos.PagamentoTipo>((Interfaces.Services.Base.IGenericService<Entities.DadosBasicos.PagamentoTipo>)_pagamentoTipoBO, GetPagamentoTipo());            


            return true;
        }
        public int InsertList<T>(Interfaces.Services.Base.IGenericService<T> bo, IList<T> list)
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
