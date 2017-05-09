using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Interfaces.Facade
{
    public interface IInitializationFacadeBO
    {
        bool InitAll();
        int InsertList<T>(Base.IGenericBusiness<T> bo, IList<T> list);

        IList<Entities.Users.User> GetMainUsers();
        IList<Entities.Users.Role> GetRoles();
        IList<Entities.Users.UserInRole> GetUsersInRoles();
        
        IList<Entities.DadosBasicos.CriterioFixo> GetCriteriosFixos();        
        IList<Entities.DadosBasicos.PagamentoTipo> GetPagamentoTipo();     
    }
}
