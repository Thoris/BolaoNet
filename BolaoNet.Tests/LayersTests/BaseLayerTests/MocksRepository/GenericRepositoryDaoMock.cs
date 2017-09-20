using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.LayersTests.BaseLayerTests.MocksRepository
{
    public class GenericRepositoryDaoMock<T, L> 
        : IGenericRepositoryDaoMock<L> where L : class 
    { 

        #region Constructors/Destructors

        public GenericRepositoryDaoMock( )
        { 
        }

        #endregion

        #region Methods

        public virtual void Setup(Mock  mock, IList<L> list)
        {

            mock.As<Domain.Interfaces.Repositories.Base.IGenericDao<L>>().Setup( m => m.GetAll()).Returns(list);
            
            mock.As<Domain.Interfaces.Repositories.Base.IGenericDao<L>>().Setup(m => m.Count()).Returns(list.Count);
            
            mock.As<Domain.Interfaces.Repositories.Base.IGenericDao<L>>().Setup(mr => mr.Load(It.IsAny<L>()))
                .Returns((L s) => list.Where(GetPredicate(s)).Single());
            
            mock.As<Domain.Interfaces.Repositories.Base.IGenericDao<L>>().Setup(mr => mr.Insert(It.IsAny<L>())).Returns(
                (L target) =>
                {
                    list.Add(target);

                    return 1;
                });

            mock.As<Domain.Interfaces.Repositories.Base.IGenericDao<L>>().Setup(mr => mr.Update(It.IsAny<L>())).Returns(
                (L target) =>
                {
                    var original = list.Where(GetPredicate(target)).Single();

                    if (original == null)
                    {
                        return 0;
                    }
                    else
                    {
                        SetData(target, original);
                        return 1;
                    }
                });

            mock.As<Domain.Interfaces.Repositories.Base.IGenericDao<L>>().Setup(mr => mr.Delete(It.IsAny<L>())).Returns(
                (L target) =>
                {
                    var original = list.Where(GetPredicate(target)).Single();

                    if (original == null)
                    {
                        return 0;
                    }
                    else
                    {
                        list.Remove(original);
                        return 1;
                    }
                });


        }

        public virtual Func<L, bool> GetPredicate(L entity)
        {
            return x => x.Equals(entity);
        }

        private void SetData(object source, object target)
        {

        }

        #endregion
    }
}
