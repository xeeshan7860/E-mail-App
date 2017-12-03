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

namespace NEWPROJECT
{
    public partial class ChangePasswordForm : Form
    {
        ConnectionClass conn = new ConnectionClass();
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("select * from Admin", conn.connect);
            conn.connect.Open();
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                Emailbox.AutoCompleteCustomSource.Add(dr["E_mail"].ToString());
            }
            conn.connect.Close();
            Emailbox.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public void Load()
        //{
        //    EMSLOGINFORM loginform = new EMSLOGINFORM();
        //    ConnectionClass conn = new ConnectionClass();
        //    SqlCommand cmd = new SqlCommand("select * from Admin", conn.connect);
        //    conn.connect.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        loginform.textBox1.AutoCompleteCustomSource.Add(dr["E_mail"].ToString());
        //    }
        //    conn.connect.Close();
        //    loginform.textBox1.Focus();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            SubmitBtn();
            
        }
        private bool SubmitBtn()
        {
            bool ret = true;
            {
                try
                {
                    if (Emailbox.Text == "")
                    {
                        lblNameIsRequired.Visible = true;
                        ret = false;
                    }
                    else
                    {
                        lblNameIsRequired.Visible = false;
                    }

                    if (CurrentPasswordBox.Text == "")
                    {
                        lblEmailIsRequired.Visible = true;
                        ret = false;
                    }
                    else
                    {
                        lblEmailIsRequired.Visible = false;
                    }

                    if (NewPasswordBox.Text == "")
                    {
                        lblPasswordIsRequired.Visible = true;
                        ret = false;
                    }
                    else
                    {
                        lblPasswordIsRequired.Visible = false;
                    }

                    if (ConfirmPasswordBox.Text == "")
                    {
                        lblConfirmPasswordIsRequired.Visible = true;
                        ret = false;
                    }
                    else
                    {
                        lblConfirmPasswordIsRequired.Visible = false;
                    }

                    //if (NewPasswordBox.Text != "" && ConfirmPasswordBox.Text != "")
                    //{
                    //    if (NewPasswordBox != ConfirmPasswordBox)
                    //    {
                    //        lblConfirmPasswordAndPasswordSame.Visible = true;
                    //        ret = false;
                    //    }
                    //}
                    //else
                    //{
                    //    lblConfirmPasswordAndPasswordSame.Visible = false;
                    //}
                    if ((Emailbox.Text != "") && (CurrentPasswordBox.Text != "") && (NewPasswordBox.Text != "") && (ConfirmPasswordBox.Text != ""))
                    {

                        //this is connection check email is exist  if condtion is true so then check current password is exist into the database
                        SqlCommand cmd = new SqlCommand("Select Count(*) From Admin Where E_mail = @E_mail", conn.connect);
                        cmd.Parameters.AddWithValue("@E_mail", Emailbox.Text);
                        conn.connect.Open();
                        int Result = (int)cmd.ExecuteScalar();
                        if (Result == 1)
                        {
                            //this connection is check that current password is exist
                            SqlCommand cmd2 = new SqlCommand("Select Count(*) From Admin Where Password = @Password AND E_mail = @Email", conn.connect);
                            cmd2.Parameters.AddWithValue("@Email", Emailbox.Text);
                            cmd2.Parameters.AddWithValue("@Password", CurrentPasswordBox.Text);
                            //conn.connect.Open();
                            int Result2 = (int)cmd2.ExecuteScalar();
                            //conn.connect.Close();
                            if (Result2 == 1)
                            {
                                if(NewPasswordBox.Text == ConfirmPasswordBox.Text)
                                {
                                    SqlCommand cmd3 = new SqlCommand("update Admin Set Password=@Password where E_mail=@E_mail",conn.connect);
                                    cmd3.Parameters.AddWithValue("@E_mail", Emailbox.Text);
                                    cmd3.Parameters.AddWithValue("@Password",ConfirmPasswordBox.Text);
                                    cmd3.ExecuteNonQuery();
                                    DialogResult Dr = MessageBox.Show("Password have changed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if(Dr==DialogResult.OK)
                                    {
                                        CurrentPasswordBox.Clear();
                                        NewPasswordBox.Clear();
                                        ConfirmPasswordBox.Clear();
                                    }
                                    conn.connect.Close();
                                }
                                else
                                {
                                    lblConfirmPasswordIsRequired.Text = "Password does not match";
                                    lblConfirmPasswordIsRequired.Visible = true;
                                    conn.connect.Close();
                                }
                            }
                            else
                            {
                                lblEmailIsRequired.Text = "Password does not exist";
                                lblEmailIsRequired.Visible = true;
                                CurrentPasswordBox.Clear();
                                NewPasswordBox.Clear();
                                ConfirmPasswordBox.Clear();
                                conn.connect.Close();
                            }
                            
                        }
                        else
                        {
                            lblNameIsRequired.Text = "Email does not exist";
                            lblNameIsRequired.Visible = true;
                            Emailbox.Clear();
                            CurrentPasswordBox.Clear();
                            NewPasswordBox.Clear();
                            ConfirmPasswordBox.Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return ret;
            }
        }
        private void Emailbox_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Count(*) From Admin Where E_mail = @E_mail", conn.connect);
            cmd.Parameters.AddWithValue("@E_mail", Emailbox.Text);
            conn.connect.Open();
            int Result = (int)cmd.ExecuteScalar();
            if (Result != 1)
            {
                lblNameIsRequired.Text = "Email Does Not Exist";
                lblNameIsRequired.Visible = true;
            }
            else
            {
                lblNameIsRequired.Visible = false;
            }
                
            conn.connect.Close();
        }

        private void lblNameIsRequired_Click(object sender, EventArgs e)
        {

        }

        private void lblConfirmPasswordIsRequired_Click(object sender, EventArgs e)
        {

        }

        private void ChangePasswordForm_Load_1(object sender, EventArgs e)
        {
            
            ConnectionClass conn = new ConnectionClass();
            SqlCommand cmd = new SqlCommand("select * from Admin", conn.connect);
            conn.connect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
              Emailbox.AutoCompleteCustomSource.Add(dr["E_mail"].ToString());
            }
            conn.connect.Close();
            Emailbox.Focus();
        }
    
    }
}
