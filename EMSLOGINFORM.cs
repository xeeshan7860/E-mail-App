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
    public partial class EMSLOGINFORM : Form 
    {
        
        Form1 f2 = new Form1();
        public string EMSName = null;
        public string LoginUserName = null;
        public string LoginPassword = null;
        ConnectionClass conn = new ConnectionClass();
        public EMSLOGINFORM()
        {
            InitializeComponent();
        }
        private bool CheckLogin()
        {
            bool ret = true;
            try { 
            if (textBox1.Text == "")
            {
                lblUsername.Visible = true;
                ret = false;
            }
            else
            {
                lblUsername.Visible = false;
            }

            if (textBox2.Text == "")
            {
                lblPassword.Visible = true;
                ret = false;
            }
            else
            {
                lblPassword.Visible = false;
            }

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Form1 f2 = new Form1();
                SqlCommand cmd = new SqlCommand("Select Count(*) From Admin Where E_mail= @E_mail AND Password=@Password", conn.connect);
                conn.connect.Open(); cmd.Parameters.AddWithValue("@E_mail", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                int Result = (int)cmd.ExecuteScalar();

                if (Result == 1)
                {
                    SqlCommand cmdNameFetch = new SqlCommand("Select * From Admin Where E_mail = @E_mail AND Password = @Password", conn.connect);
                    cmdNameFetch.Parameters.AddWithValue("@E_mail", textBox1.Text);
                    cmdNameFetch.Parameters.AddWithValue("@Password", textBox2.Text);
                    SqlDataReader rdr = cmdNameFetch.ExecuteReader();
                    if (rdr.Read())
                    {
                        EMSName = rdr["Name"].ToString();
                    }
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show(this, "UserName & Password is Invalid");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.TabIndex = 1;
                }
                conn.connect.Close();
            }

            
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            CheckLogin();
        }
        private void EMSLOGINFORM_Load(object sender, EventArgs e)
        {
            try { 
            ConnectionClass conn = new ConnectionClass();
            SqlCommand cmd = new SqlCommand("select * from Admin", conn.connect);
            conn.connect.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.AutoCompleteCustomSource.Add(dr["E_mail"].ToString());
            }
            conn.connect.Close();
            textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try { 
            if (this.progressBar1.Value < 100) // Should be less than progress bar max value
            {
                pictureBox2.Visible = true;
                this.progressBar1.Value++;
                if (this.progressBar1.Value == 100) //The maximum value of the progress bar
                {
                    Form1 ems = new Form1();
                    this.Hide();
                    ems.UserEmail.Text = textBox1.Text;
                    ems.UserNameEMs.Text = EMSName.ToString();
                    ems.UserName = textBox1.Text;
                   ems.Password = textBox2.Text;
                   ems.ShowDialog();
                }
            }
            else
            {
                this.timer1.Enabled = false;
            }
            //pictureBox2.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signuppage = new SignUp();
            signuppage.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Setting sett = new Setting();
            sett.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePasswordForm ChangePWDForm = new ChangePasswordForm();
            ChangePWDForm.ShowDialog();
        }

      public void EMSLOGINFORM_Load_1(object sender, EventArgs e)
        {
            ////string Bilawal = null;
          
            ////Bilawal = LoadEvent.zeeshansami();
            //comboBox1.Items.Add(LoadEvent.zeeshansami());
            ////textBox1 = LoadEvent.zeeshansami();
            ////LoadEvent();
            RefreshClass LoadEvent = new RefreshClass();
            LoadEvent.zeeshansami(textBox1);
        }

      //public void LoadEvent()
      //{
      //    SqlCommand cmd = new SqlCommand("select * from Admin", conn.connect);
      //    conn.connect.Open();
      //    SqlDataReader dr = cmd.ExecuteReader();
      //    while (dr.Read())
      //    {
      //        //comboBox1.Items.Add(dr["E_mail"]).ToString();
      //        textBox1.AutoCompleteCustomSource.Add(dr["E_mail"].ToString());
      //    }
      //    conn.connect.Close();
      //    textBox1.Focus();
      //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RefreshClass LoadEvent = new RefreshClass();
            LoadEvent.zeeshansami(textBox1);
        }
    }
}
