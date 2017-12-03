using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace NEWPROJECT
{
    public partial class SignUp : Form 
    {
        ConnectionClass conn = new ConnectionClass();
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SignupUser();
        }
        private bool SignupUser()
        {
            bool ret = true;

            if (txtName.Text == "")
            {
                lblNameIsRequired.Visible = true;
                ret = false;
            }
            else
            {
                lblNameIsRequired.Visible = false;
            }

            if (txtEmail.Text == "")
            {
                lblEmailIsRequired.Visible = true;
                ret = false;
            }
            else
            {
                lblEmailIsRequired.Visible = false;
            }

            if (txtPassword.Text == "")
            {
                lblPasswordIsRequired.Visible = true;
                ret = false;
            }
            else
            {
                lblPasswordIsRequired.Visible = false;
            }

            if (txtConfirmPassword.Text == "")
            {
                lblConfirmPasswordIsRequired.Visible = true;
                ret = false;
            }
            else
            {
                lblConfirmPasswordIsRequired.Visible = false;
            }

            if (txtPassword.Text != "" && txtConfirmPassword.Text != "")
            {
                if (txtPassword != txtConfirmPassword)
                {
                    lblConfirmPasswordAndPasswordSame.Visible = true;
                    ret = false;
                }
            }
            else
            {
                lblConfirmPasswordAndPasswordSame.Visible = false;
            }
            if ((txtName.Text != "") && (txtEmail.Text != "") && (txtPassword.Text != "") && (txtConfirmPassword.Text != "") && (txtPassword.Text == txtConfirmPassword.Text))
            {
                lblConfirmPasswordAndPasswordSame.Visible = false;
                ConnectionClass con = new ConnectionClass();
                SqlCommand cmd = new SqlCommand("Select Count(*) From Admin Where E_mail = @E_mail", con.connect);
                cmd.Parameters.AddWithValue("@E_mail", txtEmail.Text);
                con.connect.Open();
                int Result = (int)cmd.ExecuteScalar();
                if (Result != 1)
                {
                    SqlCommand cmdInsert = new SqlCommand("Insert Into Admin (E_mail,Password,Name) Values (@E_mail,@Password,@Name)", con.connect);
                    cmdInsert.Parameters.AddWithValue("@E_mail", txtEmail.Text);
                    //MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    //UTF8Encoding utf8 = new UTF8Encoding();
                    //byte[] data = md5.ComputeHash(utf8.GetBytes(txtPassword.Text));
                    //string EncryptedPassword = Convert.ToBase64String(data);
                    cmdInsert.Parameters.AddWithValue("@Password", txtConfirmPassword.Text);
                    cmdInsert.Parameters.AddWithValue("@Name", txtName.Text);
                    cmdInsert.ExecuteNonQuery();
                    conn.connect.Close();
                    DialogResult DR=MessageBox.Show("New User Added","Successfully",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    if (DR == DialogResult.OK)
                    {
                        EMSLOGINFORM ems = new EMSLOGINFORM();
                        RefreshClass LoadEvent = new RefreshClass();
                        LoadEvent.zeeshansami(ems.textBox1);
                        //this.Refresh();
                        //MyForm1Instance.Refresh();
                        //MyForm1Instance.EMSLOGINFORM_Load_1(null, null);
                        //MyForm1Instance.EMSLOGINFORM_Load_1(this, new EventArgs());
                        //MessageBoxButtons.OK += new System.EventHandler(this.button1_Click);
                    }
                }
                else
                {
                    MessageBox.Show("This Email is already exist");
                    txtPassword.Clear();
                    txtConfirmPassword.Clear();
                    con.connect.Close();
                }
            }
            return ret;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPasswordIsRequired_Click(object sender, EventArgs e)
        {

        }
        private void SignUp_Load_1(object sender, EventArgs e)
        {

        }
        
    }
}
