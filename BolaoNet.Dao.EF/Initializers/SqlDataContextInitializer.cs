using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Initializers
{
    public class SqlDataContextInitializer : DropCreateDatabaseAlways<UnitOfWork>
    {
        #region Constants

        public const string ScriptsFolder = "..\\..\\..\\BolaoNet.Database.SqlServer\\build";
        public const string StoredProcedureFile = "*Create_StoredProcedure*.sql";
        
        #endregion

        #region Constructors/Destructors

        public SqlDataContextInitializer()
        {

        }

        #endregion

        #region Methods

        protected override void Seed(UnitOfWork context)
        {
            string [] files = GetStoredProcedureFiles();

            for (int c = 0; c < files.Length; c++ )
            {
                string script = ReadFile(files[c]);

                int total = context.Database.ExecuteSqlCommand(script);
            }

            context.Save();

            base.Seed(context);
        }

        public string [] GetStoredProcedureFiles()
        {
            string[] files = System.IO.Directory.GetFiles(ScriptsFolder, StoredProcedureFile);

            return files;
        }

        public string ReadFile(string file)
        {

            string res = "";

            StreamReader reader = new StreamReader(file);
            bool started = false;
            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();

                if (!started)
                {
                    if (line.Trim().ToUpper().StartsWith("CREATE"))
                    {
                        started = true;
                        res += line + "\r\n";
                    }
                }
                else
                {
                    if (string.Compare(line.Trim(), "GO", true) == 0)
                        break;

                    res += line + "\r\n";
                }

            }

            reader.Close();

            return res;
        }

        
        #endregion
    }
}
