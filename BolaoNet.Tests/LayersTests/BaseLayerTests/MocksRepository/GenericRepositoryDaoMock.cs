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
        #region Variables

        private IList<L> _list;

        #endregion


        #region Constructors/Destructors

        public GenericRepositoryDaoMock( )
        { 
        }

        #endregion

        #region Methods

        public virtual T Setup(Mock  mock, IList<L> list)
        {
            _list = list;
           
            mock.As<Domain.Interfaces.Repositories.Base.IGenericDao<L>>().Setup(m => m.GetAll()).Returns(_list);

            mock.As<Domain.Interfaces.Repositories.Base.IGenericDao<L>>().Setup(m => m.Count())
            .Returns(() => 
                {
                    return _list.Count;
                });
            
            mock.As<Domain.Interfaces.Repositories.Base.IGenericDao<L>>().Setup(mr => mr.Load(It.IsAny<L>()))
            .Returns((L s) =>
            {
                var original = _list.Where(GetPredicate(s)).ToList();

                foreach (L entry in original)
                {
                    return entry;
                }                
                return null;
            });

            mock.As<Domain.Interfaces.Repositories.Base.IGenericDao<L>>().Setup(mr => mr.Insert(It.IsAny<L>())).Returns(
                (L target) =>
                {
                    _list.Add(target);

                    return 1;
                });

            mock.As<Domain.Interfaces.Repositories.Base.IGenericDao<L>>().Setup(mr => mr.Update(It.IsAny<L>())).Returns(
                (L target) =>
                {

                    var original = _list.Where(GetPredicate(target)).ToList();

                    for (int c=0; c < original.Count; c++)
                    {
                        SetData(target, original[c]);
                    }

                    return original.Count;

                });

            mock.As<Domain.Interfaces.Repositories.Base.IGenericDao<L>>().Setup(mr => mr.Delete(It.IsAny<L>())).Returns(
                (L target) =>
                {
                    var original = _list.Where(GetPredicate(target)).ToList();
                    
                    for (int c = 0; c < original.Count; c++)
                    {
                        _list.Remove(original[c]);
                    }

                    return original.Count;
                     
                });

            return (T)mock.Object;
        }

        public virtual Func<L, bool> GetPredicate(L entity)
        {
            return x => x.Equals(entity);
        }

        private void SetData(object source, object target)
        {
            if (ReferenceEquals(source, target)) return ;
            if ((source == null) || (target== null)) return ;

            //Compare two object's class, return false if they are difference
            if (source.GetType() != target.GetType()) return;

             
            //Get all properties of obj
            //And compare each other
            foreach (var property in source.GetType().GetProperties())
            {
                //if (string.Compare(property.Name, "CreatedBy", true) == 0 ||
                //    string.Compare(property.Name, "CreatedDate", true) == 0 ||
                //    string.Compare(property.Name, "ModifiedBy", true) == 0 ||
                //    string.Compare(property.Name, "ModifiedDate", true) == 0 ||
                //    string.Compare(property.Name, "ActiveFlag", true) == 0)
                //    continue;


                var objValue = property.GetValue(source);
                var anotherValue = property.GetValue(target);

                //if ((objValue == null && anotherValue != null) || (objValue != null && anotherValue == null))
                //    result = false;

                //if (objValue != null && anotherValue != null && !objValue.Equals(anotherValue))
                //    result = false;

                property.SetValue(target, objValue, null);
            }

            return;
        }

        #endregion
    }
}
