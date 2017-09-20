using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.LayersTests.BaseLayerTests
{
    public class BasePreparingData<T> where T : class
    {
        #region Properties
       
        #endregion

        #region Constructors/Destructors

        public BasePreparingData()
        {

        }

        #endregion

        #region Methods

        protected virtual T GenerateEntity()
        {
            return null;
        }
        protected virtual T GenerateEntityToUpdate()
        {
            return null;
        }

        protected bool IsPropertiesTheSame(object obj, object another)
        {
            if (ReferenceEquals(obj, another)) return true;
            if ((obj == null) || (another == null)) return false;

            //Compare two object's class, return false if they are difference
            if (obj.GetType() != another.GetType()) return false;

            var result = true;
            //Get all properties of obj
            //And compare each other
            foreach (var property in obj.GetType().GetProperties())
            {
                if (string.Compare(property.Name, "CreatedBy", true) == 0 ||
                    string.Compare(property.Name, "CreatedDate", true) == 0 ||
                    string.Compare(property.Name, "ModifiedBy", true) == 0 ||
                    string.Compare(property.Name, "ModifiedDate", true) == 0 ||
                    string.Compare(property.Name, "ActiveFlag", true) == 0)
                    continue;


                var objValue = property.GetValue(obj);
                var anotherValue = property.GetValue(another);

                if ((objValue == null && anotherValue != null) || (objValue != null && anotherValue == null))
                    result = false;

                //if (objValue != null && anotherValue != null && !objValue.Equals(anotherValue))
                //    result = false;
            }

            return result;

        }

        #endregion

    }
}
