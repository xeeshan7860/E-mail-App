using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NEWPROJECT
{

    // interface emailload
    //{
    //     void load();
    //}
   public class RefreshClass 
    {
       public static ConnectionClass conn = new ConnectionClass();
       public void zeeshansami(TextBox tb1)
       {
           SqlCommand cmd = new SqlCommand("select * from Admin", conn.connect);
           conn.connect.Open();
           SqlDataReader dr = cmd.ExecuteReader();
           while (dr.Read())
           {
               tb1.AutoCompleteCustomSource.Add( dr["E_mail"].ToString());
           }
           conn.connect.Close();
       }

       private void InitializeComponent()
       {
            //this.SuspendLayout();
            //// 
            //// RefreshClass
            //// 
            //this.ClientSize = new System.Drawing.Size(284, 261);
            //this.Name = "RefreshClass";
            //this.Load += new System.EventHandler(this.RefreshClass_Load);
            //this.ResumeLayout(false);

       }

       private void RefreshClass_Load(object sender, EventArgs e)
       {

       }
    }
}
