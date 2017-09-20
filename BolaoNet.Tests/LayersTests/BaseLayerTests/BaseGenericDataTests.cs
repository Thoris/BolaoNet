using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.LayersTests.BaseLayerTests
{
    public class BaseGenericDataTests<T, L>
        : BasePreparingData<T> where T : class
    {
        #region Variables

        private L _performer;

        private MethodInfo _load;
        private MethodInfo _insert;
        private MethodInfo _update;
        private MethodInfo _delete;
        private MethodInfo _getList;
        private MethodInfo _getAll;
        private MethodInfo _count;
        private MethodInfo _countWhere;


        #endregion

        #region Constructors/Destructors

        public BaseGenericDataTests(L performer)
        {
            _performer = performer;


            _load = _performer.GetType ()
              .GetMethods()
              .Single(m => m.Name == "Load" );


            _insert = _performer.GetType()
              .GetMethods()
              .Single(m => m.Name == "Insert");


            _update = _performer.GetType()
              .GetMethods()
              .Single(m => m.Name == "Update");


            _delete = _performer.GetType()
              .GetMethods()
              .Single(m => m.Name == "Delete");


            _getList = _performer.GetType()
              .GetMethods()
              .Single(m => m.Name == "GetList");


            _getAll = _performer.GetType()
              .GetMethods()
              .Single(m => m.Name == "GetAll");


            //_count = _performer.GetType()
            //  .GetMethods()
            //  .Single(m => m.Name == "Count" && m.GetParameters().Count() != 0);


            //_countWhere = _performer.GetType()
            //  .GetMethods()
            //  .Single(m => m.Name == "CountWhere" && m.GetParameters().Count() != 0);
        }

        #endregion

        #region Methods

        protected void TestLoad()
        {
            //Preparing
            T entityToTest = GenerateEntity();
            object resPreparing = _insert.Invoke(_performer, new object[] { entityToTest });

            Domain.Entities.Base.BaseEntity x = entityToTest as Domain.Entities.Base.BaseEntity;

            try
            {
                //Testing 
                object data = _load.Invoke(_performer, new object[] { entityToTest });
                Assert.IsNotNull(data);
                Assert.IsTrue(IsPropertiesTheSame(data, entityToTest));
            }
            finally
            {
                //Cleaning
                object resClean = _delete.Invoke(_performer, new object[] {entityToTest});
            }
        }
        protected void TestInsert()
        {
            //Preparing
            long countPreparing = (long)_count.Invoke (_performer, null);
            T entityToTest = GenerateEntity();

            try
            {
                object res = _insert.Invoke(_performer, new object[]{ entityToTest});
                //Assert.Greater(res, 0);
                Assert.AreNotEqual(0, res);
                long countInserted = (long)_count.Invoke(_performer, null) ;
                Assert.AreEqual(countPreparing + 1, countInserted);
                T entityCheck = (T)_load.Invoke(_performer, new object[]{ entityToTest});
                Assert.IsNotNull(entityToTest);

            }
            finally
            {
                //Cleaning
                object resClean = _delete.Invoke(_performer, new object[] { entityToTest });
            }

        }
        protected void TestUpdate()
        {
            T entityToTest = GenerateEntity();
            long resPrep = (long) _insert.Invoke(_performer, new object[] {entityToTest});
            T entityToUpdate = GenerateEntityToUpdate();


            Domain.Entities.Base.BaseEntity dataKey = entityToTest as Domain.Entities.Base.BaseEntity;
            IDictionary<string, object> keys = dataKey.GetPrimaryKey();

            PropertyInfo[] properties = entityToUpdate.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                foreach (var key in keys)
                {
                    if (string.Compare(property.Name, key.Key, true) == 0)
                    {
                        PropertyInfo propertyInfo = entityToUpdate.GetType().GetProperty(property.Name);
                        // make sure object has the property we are after
                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(entityToUpdate, key.Value, null);
                        }

                        break;
                    }
                }
            }


            try
            {
                object res = _update.Invoke(_performer, new object[] {entityToUpdate});
                Assert.AreNotEqual(0, res);
                Assert.IsTrue(IsPropertiesTheSame(entityToTest, entityToUpdate));
            }
            finally
            {
                //Cleaning
                object resClean = _delete.Invoke(_performer, new object[] { entityToTest });
            }
        }
        protected void TestDelete()
        {
            T entityToTest = GenerateEntity();
            object resPrep = _insert.Invoke(_performer, new object [] {entityToTest});

            try
            {
                object res = _delete.Invoke(_performer, new object[]{ entityToTest});
                Assert.AreNotEqual(0, res);
                T entityCheck = (T)_load.Invoke(_performer, new object[] {entityToTest});
                Assert.IsNull(entityCheck);

            }
            finally
            {

            }
        }
        protected void TestGetList()
        {
            T entityToTest = GenerateEntity();
            long countData = (long)_count.Invoke(_performer, null);
            object resPrep = _insert.Invoke(_performer, new object[] {entityToTest});

            try
            {
                ICollection<T> list = (ICollection<T>) _getAll.Invoke(_performer, null);
                //ICollection<T> list = _dao.GetList((Entities.mo));
                Assert.IsNotNull(list);
                Assert.AreEqual(countData + 1, list.Count);
            }
            finally
            {
                //Cleaning
                object resClean = _delete.Invoke(_performer, new object[] { entityToTest });

            }
        }
        protected void TestGetAll()
        {
            T entityToTest = GenerateEntity();
            long countData = (long)_count.Invoke(_performer, null);
            object resPrep = _insert.Invoke(_performer, new object[] {entityToTest});

            try
            {
                ICollection<T> list = (ICollection<T>)_getAll.Invoke(_performer, null);
                Assert.IsNotNull(list);
                Assert.AreEqual(countData + 1, list.Count);
            }
            finally
            {
                //Cleaning
                object resClean = _delete.Invoke(_performer, new object[] { entityToTest });

            }
        }
        protected void TestCount()
        {
            T entityToTest = GenerateEntity();
            long countData = (long)_count.Invoke(_performer, null);
            object resPrep = _insert.Invoke(_performer, new object[] { entityToTest });

            try
            {
                long countVerify = (long) _count.Invoke(_performer, null);
                Assert.AreEqual(countData + 1, countVerify);
            }
            finally
            {
                //Cleaning
                object resClean = _delete.Invoke(_performer, new object[] { entityToTest });

            }
        }
        protected void TestCountWhere()
        {
            //T entityToTest = GenerateEntity();
            //long countData = _dao.Count();
            //long resPrep = _dao.Insert(entityToTest);

            //try
            //{
            //    long countVerify = _dao.Count();
            //    Assert.AreEqual(countData + 1, countVerify);
            //}
            //finally
            //{
            //    //Cleaning
            //    int resClean = _dao.Delete(entityToTest);

            //}
        }

        #endregion
    }
}
