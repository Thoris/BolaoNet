using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Base
{
    //http://www.khalidabuhakmeh.com/entity-framework-6-multiple-result-sets-with-stored-procedures
//    var Policy = "123";
//var Results=   db
//        .MultipleResults($"EXEC GetPolicyInfo '{Policy}'")
//        .AddResult<Driver>()
//        .AddResult<Address>()
//        .AddResult<Phone>()
//        .AddResult<Email>()
//        .AddResult<Vehicle>()
//        .Execute();
//        var Output= new clsPolicyInfo
//        {
//            Drivers = Results[0] as Driver[],
//            Addresses = Results[1] as Address[],
//            Phones = Results[2] as Phone[],
//            Emails = Results[3] as Email[],
//            Vehicles = Results[4] as Vehicle[]
//        };
    public static class MultipleResultSets
    {
        #region Constructors/Destructors

        public static MultipleResultSetWrapper MultipleResults(this DbContext db, string storedProcedure)
        {
            return new MultipleResultSetWrapper(db, storedProcedure);
        }
        #endregion

        public class MultipleResultSetWrapper
        {
            private readonly DbContext _db;
            private readonly string _storedProcedure;
            public List<Func<IObjectContextAdapter, DbDataReader, IEnumerable>> _resultSets;

            public MultipleResultSetWrapper(DbContext db, string storedProcedure)
            {
                _db = db;
                _storedProcedure = storedProcedure;
                _resultSets = new List<Func<IObjectContextAdapter, DbDataReader, IEnumerable>>();
            }

            public MultipleResultSetWrapper With<TResult>()
            {
                _resultSets.Add((adapter, reader) => adapter
                    .ObjectContext
                    .Translate<TResult>(reader)
                    .ToList());

                return this;
            }

            public List<IEnumerable> Execute()
            {
                var results = new List<IEnumerable>();

                using (var connection = _db.Database.Connection)
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "EXEC " + _storedProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        var adapter = ((IObjectContextAdapter)_db);
                        foreach (var resultSet in _resultSets)
                        {
                            results.Add(resultSet(adapter, reader));
                            reader.NextResult();
                        }
                    }

                    return results;
                }
            }
        }
    }
}
