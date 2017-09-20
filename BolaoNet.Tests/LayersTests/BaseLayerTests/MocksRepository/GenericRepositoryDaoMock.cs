using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.LayersTests.BaseLayerTests.MocksRepository
{
    public class GenericRepositoryDaoMock<L> 
        : IGenericRepositoryDaoMock<L> where L : class 
    { 

        #region Constructors/Destructors

        public GenericRepositoryDaoMock( )
        { 
        }

        #endregion

        #region Methods

        public virtual void Setup(Mock<Domain.Interfaces.Repositories.Base.IGenericDao<L>> mock, IList<L> list)
        {

            mock.Setup(mr => mr.GetAll()).Returns(list);

            mock.Setup(mr => mr.Count()).Returns(list.Count);

            mock.Setup(mr => mr.Load(It.IsAny<L>()))
                .Returns((L s) => list.Where(GetPredicate(s)).Single());

            mock.Setup(mr => mr.Insert(It.IsAny<L>())).Returns(
                (L target) =>
                {
                    list.Add(target);

                    return 1;
                });

            mock.Setup(mr => mr.Update(It.IsAny<L>())).Returns(
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

            mock.Setup(mr => mr.Delete(It.IsAny<L>())).Returns(
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
