using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace NEWPROJECT
{
   public class ConnectionClass
    {

       public SqlConnection connect = new SqlConnection(@"data source =.; database=EMS; Integrated Security=SSPI;");
    }
}
