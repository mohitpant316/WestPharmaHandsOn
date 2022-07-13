using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebApi
{
   public class DataManagerFactory
    {
        private static DataManagerFactory _instance = null;

        DataManagerFactory()
        {
        }

        public static DataManagerFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataManagerFactory();
                }

                return _instance;
            }
        }

        public IData RepositoryType
        {
            get { return new FakeApi(); }
        }
    }
}
