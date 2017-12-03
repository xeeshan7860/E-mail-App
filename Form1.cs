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
using System.Net.Mail;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Xml.Linq;
using System.Net;
using PresentationControls;

namespace NEWPROJECT
{
    public partial class Form1 : Form
    {
        
        ConnectionClass conn = new ConnectionClass();
        public string UserName = null;
        public string Password = null;
        public string Status = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            try
            {
                DeleteHistoryCombo();
                P_ID.Items.Clear();
                P_IDD();
                dateTimePicker1.Enabled = false;
                LoadEvent();
                // HistoryGridView();
                //conn.connect.Open();
                //SqlCommand cmd = new SqlCommand("Select * from Email_Sent", conn.connect);
                //SqlDataReader rdr = cmd.ExecuteReader();
                //while (rdr.Read())
                //{
                //    DeleteHistoryComboBox.Items.Add(rdr["EmailID"].ToString());
                //}
                //conn.connect.Close();
                PopulateCombo(comboBox1);
                PopulateCombo(comboBox2);
                PopulateCombo(comboBox3);
                PopulateCombo(comboBox4);
                PopulateCombo(comboBox5);
                PopulateCombo(comboBox6);
                PopulateCombo(comboBox7);
                PopulateCombo(comboBox8);
                PopulateCombo(comboBox9);
                PopulateCombo(comboBox10);
                PopulateCombo(comboBox11);
                PopulateCombo(comboBox12);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        /// <summary>
        /// this funciton is used to Delete History then show the all data in Datagridview1
        /// </summary>
        public void HistoryGridView1()
        {
            try
            {
                ConnectionClass con = new ConnectionClass();
                SqlCommand cmd = new SqlCommand("Select Count(*) From Email_Sent", con.connect);
                con.connect.Open();
                int Result = (int)cmd.ExecuteScalar();

                if (Result >= 1)
                {
                    SqlCommand cmdFounded = new SqlCommand("Select TOP 3000 * From Email_Sent", con.connect);
                    SqlDataReader rdr = cmdFounded.ExecuteReader();
                    BindingSource source = new BindingSource();
                    dataGridView1.Visible = true;
                    source.DataSource = rdr;
                    dataGridView1.DataSource = source;
                    con.connect.Close();
                }
                else
                {
                    lblRecordNotFoundMessagre.Visible = true;
                    dataGridView1.Visible = false;
                    con.connect.Close();
                }
                //try
                //{
                //    DataColumnCollection Columns = dtItems.Columns;

                //    if (Columns.Contains(ColNameToCheck))
                //    {
                //        ConnectionClass conn = new ConnectionClass();
                //        SqlCommand cmd = new SqlCommand("Select * From Email_Sent ", conn.connect);
                //        conn.connect.Open();
                //        SqlDataReader rdr = cmd.ExecuteReader();
                //        BindingSource bs = new BindingSource();
                //        bs.DataSource = rdr;
                //        dataGridView1.DataSource = bs;
                //        conn.connect.Close();
                //    }
                //    else
                //    {
                //        MessageBox.Show("All Data Has Been Deleted");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(this, ex.Message);
                //}
            }
           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// this function is used to History GridView Data 
        /// </summary>
        public void HistoryGridView()
        {
            //if (dataGridView1.Rows.Count != 0 && dataGridView1.Columns.Count != 0)
            //{k
            try { 
                ConnectionClass con = new ConnectionClass();
                SqlCommand cmd = new SqlCommand("Select Count(*) From Email_Sent", con.connect);
                con.connect.Open();
                int Result = (int)cmd.ExecuteScalar();

                if (Result >= 1)
                {
                    SqlCommand cmdFounded = new SqlCommand("Select TOP 3000 * From Email_Sent", con.connect);
                    SqlDataReader rdr = cmdFounded.ExecuteReader();
                    BindingSource source = new BindingSource();
                    dataGridView1.Visible = true;
                    lblRecordNotFoundMessagre.Visible = false;
                    source.DataSource = rdr;
                    dataGridView1.DataSource = source;
                    con.connect.Close();
                }
                else
                {
                    dataGridView1.Visible = false;
                    lblRecordNotFoundMessagre.Visible = true;
                    con.connect.Close();
                }
                //try
                //{
                //    dataGridView1.Columns.Clear();
                //    dataGridView1.Rows.Clear();
                //    ConnectionClass conn = new ConnectionClass();
                //    SqlCommand cmd = new SqlCommand("Select * From Email_Sent ", conn.connect);
                //    conn.connect.Open();
                //    SqlDataReader rdr = cmd.ExecuteReader();
                //    BindingSource bs = new BindingSource();
                //    bs.DataSource = rdr;
                //    dataGridView1.DataSource = bs;
                //    conn.connect.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(this, ex.Message);
                //}
            //}
            //else
            //{
            //    lblRecordNotFoundMessagre.Visible = true;
            //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// this function is used to mailsent history
        /// </summary>
        public void MailSentHistory()
        {
            //if (dataGridView1.Rows.Count != 0 && dataGridView1.Rows.Count != 0)
            //{
            try { 
                ConnectionClass con = new ConnectionClass();
                SqlParameter parStatus = new SqlParameter();
                string StatusOne = parStatus.ParameterName = "Mail Sent";
                SqlCommand cmd = new SqlCommand("Select Count(*) From Email_Sent Where Status = '" + StatusOne + "'", con.connect);
                con.connect.Open();
                int Result = (int)cmd.ExecuteScalar();
                if (Result >= 1)
                {
                    SqlParameter par = new SqlParameter();
                    string Status = par.ParameterName = "Mail Sent";
                    SqlCommand cmdCheck = new SqlCommand("Select TOP 3000 * From Email_Sent Where Status ='" + Status + "'", con.connect);
                    if (Status == "Mail Sent")
                    {
                        dataGridView1.Columns.Clear();
                        dataGridView1.Rows.Clear();
                        DataGridViewImageColumn btnimage = new DataGridViewImageColumn();
                        btnimage.Image = Properties.Resources.images;
                        dataGridView1.Columns.Add(btnimage);
                        btnimage.ImageLayout = (DataGridViewImageCellLayout)ImageLayout.Stretch;
                        SqlDataReader rdr = cmdCheck.ExecuteReader();
                        BindingSource source = new BindingSource();
                        source.DataSource = rdr;
                        dataGridView1.Visible = true;
                        lblRecordNotFoundMessagre.Visible = false;
                        dataGridView1.DataSource = source;
                        con.connect.Close();
                    }
                }
                else
                {
                    lblRecordNotFoundMessagre.Visible = true;
                    dataGridView1.Visible = false;
                    con.connect.Close();
                }
            //}
            //else
            //{
            //    MessageBox.Show("All Data Is Deleted");
            //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// this function is used to mail sending failed history
        /// </summary>
        public void MailSentFailedHistory()
        {
            try { 
            ConnectionClass con = new ConnectionClass();
            con.connect.Open();
            SqlParameter parStatus = new SqlParameter();
            string StatusOne = parStatus.ParameterName = "Mail Sending Failed";
            SqlCommand cmd = new SqlCommand("Select Count(*) From Email_Sent Where Status ='" + StatusOne + "'", con.connect);
            int Result = (int)cmd.ExecuteScalar();

            if (Result >= 1)
            {
                SqlParameter par = new SqlParameter();
                string Status = par.ParameterName = "Mail Sending Failed";
                SqlCommand cmdCheck = new SqlCommand("Select TOP 3000 * From Email_Sent Where Status ='" + Status + "'", con.connect);

                if (Status == "Mail Sending Failed")
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    SqlDataReader rdr = cmdCheck.ExecuteReader();
                    DataGridViewImageColumn btnimage = new DataGridViewImageColumn();
                    btnimage.Image = Properties.Resources.download;
                    dataGridView1.Columns.Add(btnimage);
                    btnimage.ImageLayout = (DataGridViewImageCellLayout)ImageLayout.Stretch;
                    BindingSource source = new BindingSource();
                    source.DataSource = rdr;
                    dataGridView1.Visible = true;
                    lblRecordNotFoundMessagre.Visible = false;
                    dataGridView1.DataSource = source;
                    //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    //btn.Text = "Resend";
                    //dataGridView1.Columns.Add(btn);
                    //btnimage.HeaderText = "Status";
                    con.connect.Close();
                }
            }
            else
            {
                lblRecordNotFoundMessagre.Visible = true;
                dataGridView1.Visible = false;
                con.connect.Close();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// this function is used to loadevent database
        /// </summary>
        public void LoadEvent()
        {
            try
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();
                comboBox6.Items.Clear();
                comboBox7.Items.Clear();
                comboBox8.Items.Clear();
                comboBox9.Items.Clear();
                comboBox10.Items.Clear();
                comboBox11.Items.Clear();
                comboBox12.Items.Clear();
                UCombo1.Items.Clear();
                UCombo2.Items.Clear();
                UCombo3.Items.Clear();
                UCombo4.Items.Clear();
                UCombo5.Items.Clear();
                UCombo6.Items.Clear();
                UCombo7.Items.Clear();
                UCombo8.Items.Clear();
                UCombo9.Items.Clear();
                UCombo10.Items.Clear();
                UCombo11.Items.Clear();
                UCombo12.Items.Clear();
                SCombo1.Items.Clear();
                SCombo2.Items.Clear();
                SCombo3.Items.Clear();
                SCombo4.Items.Clear();
                SCombo5.Items.Clear();
                SCombo6.Items.Clear();
                SCombo7.Items.Clear();
                SCombo8.Items.Clear();
                SCombo9.Items.Clear();
                SCombo10.Items.Clear();
                SCombo11.Items.Clear();
                SCombo12.Items.Clear();
                //DeleteHistoryComboBox.Items.Clear();
                LanguageComboBox.Items.Clear();
                LanguageComboBox.Items.Add("English");
                LanguageComboBox.Items.Add("Urdu");
                LanguageComboBox.Items.Add("Sindhi");
                ConnectionClass conn = new ConnectionClass();
                SqlCommand cmd = new SqlCommand("Select Distinct TOP 3000 P_Name From Paper_New", conn.connect);
                conn.connect.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    comboBox1.Items.Add(rdr["P_Name"].ToString());
                    comboBox2.Items.Add(rdr["P_Name"].ToString());
                    comboBox3.Items.Add(rdr["P_Name"].ToString());
                    comboBox4.Items.Add(rdr["P_Name"].ToString());
                    comboBox5.Items.Add(rdr["P_Name"].ToString());
                    comboBox6.Items.Add(rdr["P_Name"].ToString());
                    comboBox7.Items.Add(rdr["P_Name"].ToString());
                    comboBox8.Items.Add(rdr["P_Name"].ToString());
                    comboBox9.Items.Add(rdr["P_Name"].ToString());
                    comboBox10.Items.Add(rdr["P_Name"].ToString());
                    comboBox11.Items.Add(rdr["P_Name"].ToString());
                    comboBox12.Items.Add(rdr["P_Name"].ToString());
                    UCombo1.Items.Add(rdr["P_Name"]).ToString();
                    UCombo2.Items.Add(rdr["P_Name"]).ToString();
                    UCombo3.Items.Add(rdr["P_Name"]).ToString();
                    UCombo4.Items.Add(rdr["P_Name"]).ToString();
                    UCombo5.Items.Add(rdr["P_Name"]).ToString();
                    UCombo6.Items.Add(rdr["P_Name"]).ToString();
                    UCombo7.Items.Add(rdr["P_Name"]).ToString();
                    UCombo8.Items.Add(rdr["P_Name"]).ToString();
                    UCombo9.Items.Add(rdr["P_Name"]).ToString();
                    UCombo10.Items.Add(rdr["P_Name"]).ToString();
                    UCombo11.Items.Add(rdr["P_Name"]).ToString();
                    UCombo12.Items.Add(rdr["P_Name"]).ToString();
                    SCombo1.Items.Add(rdr["P_Name"]).ToString();
                    SCombo2.Items.Add(rdr["P_Name"]).ToString();
                    SCombo3.Items.Add(rdr["P_Name"]).ToString();
                    SCombo4.Items.Add(rdr["P_Name"]).ToString();
                    SCombo5.Items.Add(rdr["P_Name"]).ToString();
                    SCombo6.Items.Add(rdr["P_Name"]).ToString();
                    SCombo7.Items.Add(rdr["P_Name"]).ToString();
                    SCombo8.Items.Add(rdr["P_Name"]).ToString();
                    SCombo9.Items.Add(rdr["P_Name"]).ToString();
                    SCombo10.Items.Add(rdr["P_Name"]).ToString();
                    SCombo11.Items.Add(rdr["P_Name"]).ToString();
                    SCombo12.Items.Add(rdr["P_Name"]).ToString();

                }
                conn.connect.Close();
                }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        #region ComboBoxPopulate
        /// <summary>
        /// Ye Function Load Event Par Paper_News K Naam Ko Populate Krne k Liye Use Kiya Hy
        /// </summary>
        private void PopulateCombo(ComboBox combo1)
        {
            ConnectionClass con = new ConnectionClass();
            SqlCommand cmd = new SqlCommand("Select Count(*) From Paper_New",con.connect);
            con.connect.Open();
            int Result = (int)cmd.ExecuteScalar();

            if (Result >= 1)
            {
                SqlCommand cmdInsert = new SqlCommand("Select Distinct TOP 3000 P_Name From Paper_New", con.connect);
                SqlDataReader rdr = cmdInsert.ExecuteReader();

                while (rdr.Read())
                {
                    combo1.Items.Add(rdr["P_Name"].ToString());
                }
                con.connect.Close();
            }
            else
            {
                con.connect.Close();
            }
        }
        #endregion
        /// <summary>
        /// this function is used to Paper_New ID DataBase ComboBox
        /// </summary>
        public void P_IDD()
        {
            try { 
            P_ID.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select TOP 3000 P_ID  From Paper_New", conn.connect);
            conn.connect.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                P_ID.Items.Add(rdr["P_ID"]).ToString();
            }
            conn.connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// this function is used to Add ID Database ComboBox
        /// </summary>
        public void DeleteHistoryCombo()
        {
            try { 
            ConnectionClass conn = new ConnectionClass();
            SqlCommand cmdCheck = new SqlCommand("Select Count(*) From Email_Sent", conn.connect);
            conn.connect.Open();
            int Result = (int)cmdCheck.ExecuteScalar();
            if (Result >= 1)
            {
                DeleteHistoryComboBox.Items.Clear();
                SqlCommand cmd = new SqlCommand("Select Distinct  TOP 3000 *  From Email_Sent", conn.connect);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DeleteHistoryComboBox.Items.Add(rdr["EmailID"]).ToString();
                }
                conn.connect.Close();
            }
            else
            {
                conn.connect.Close();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AllCheckBox()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select Distinct TOP 3000 *  From Paper_New", conn.connect);
                conn.connect.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                BindingSource bs = new BindingSource();
                bs.DataSource = rdr;
                dataGridView2.DataSource = bs;
                conn.connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// this function is used to checkboxcombobox database
        /// </summary>
        public void checkboxcombobox(ComboBox combobox, ComboBox checkcombobox)
        {
            try
            {
                //checkcombobox.Items.Clear();
                conn.connect.Open();
                SqlCommand cmd = new SqlCommand("Select TOP 3000 * From Paper_New Where P_Name = @P_Name", conn.connect);
                cmd.Parameters.AddWithValue("@P_Name", combobox.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    checkcombobox.Items.Add(rdr["P_Person_Email"].ToString());
                }
                conn.connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// this funciton is used to Urdu ComboBox Selected Text Changed to CheckBoxComboBox Data Base
        /// </summary>
        /// <param name="UrduCombo"></param>
        /// <param name="UrduCC"></param>
        public void Urducheckboxcombobox(ComboBox UrduCombo,ComboBox UrduCC)
        {
            try
            {
                UrduCC.Items.Clear();
                conn.connect.Open();
                SqlCommand cmd = new SqlCommand("Select TOP 3000 * From Paper_New Where P_Name = @P_Name", conn.connect);
                cmd.Parameters.AddWithValue("@P_Name", UrduCombo.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UrduCC.Items.Add(rdr["P_Person_Email"].ToString());
                }
                conn.connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// this is function is used to Sindhi ComboBoxes Filled Paper_New Name(s)
        /// </summary>
        /// <param name="UrduCombo"></param>
        /// <param name="UrduCC"></param>
        public void Sindhicheckboxcombobox(ComboBox SindhiCombo, ComboBox SindhiCC)
        {
            try
            {
                SindhiCC.Items.Clear();
                conn.connect.Open();
                SqlCommand cmd = new SqlCommand("Select TOP 3000 * From Paper_New Where P_Name = @P_Name", conn.connect);
                cmd.Parameters.AddWithValue("@P_Name", SindhiCombo.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SindhiCC.Items.Add(rdr["P_Person_Email"].ToString());
                }
                
                conn.connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// this function is used to English checkboxcomboBox Data Base Loads Emails
        /// </summary>
        /// <param name="combo"></param>
        public void comboboxselecteddata(ComboBox combo)
        {
            //conn.connect.Open();
            //SqlCommand cmd = new SqlCommand("Select TOP 3000 * From Paper_New", conn.connect);
            //SqlDataReader rdr = cmd.ExecuteReader();
            //while (rdr.Read())
            //{
            //    combo.Items.Add(rdr["P_Person_Email"].ToString());
            //}
            //conn.connect.Close();
        }
        /// <summary>
        /// this function is used to Urdu checkboxcomboBox Data Base Loads Emails
        /// </summary>
        /// <param name="UrduCombo"></param>
        public void Urducomboboxselecteddata(ComboBox UrduCombo)
        {
            //conn.connect.Open();
            //SqlCommand cmd = new SqlCommand("Select TOP 3000 * From Paper_New", conn.connect);
            //SqlDataReader rdr = cmd.ExecuteReader();
            //while (rdr.Read())
            //{
            //    UrduCombo.Items.Add(rdr["P_Person_Email"].ToString());
            //}
            //conn.connect.Close();
        }
        public void Sindhicomboboxselecteddata(ComboBox SindhiCombo)
        {
            //conn.connect.Open();
            //SqlCommand cmd = new SqlCommand("Select TOP 3000 * From Paper_New", conn.connect);
            //SqlDataReader rdr = cmd.ExecuteReader();
            //while (rdr.Read())
            //{
            //    SindhiCombo.Items.Add(rdr["P_Person_Email"].ToString());
            //}
            //conn.connect.Close();
        }
        /// <summary>
        /// this function is used to mail function and its passess 12 aurguments/parameters
        /// </summary>
        /// <param name="cc1"></param>
        /// <param name="cc2"></param>
        /// <param name="cc3"></param>
        /// <param name="cc4"></param>
        /// <param name="cc5"></param>
        /// <param name="cc6"></param>
        /// <param name="cc7"></param>
        /// <param name="cc8"></param>
        /// <param name="cc9"></param>
        /// <param name="cc10"></param>
        /// <param name="cc11"></param>
        /// <param name="cc12"></param>
        public bool MailFunction(ComboBox cc1, ComboBox cc2, ComboBox cc3, ComboBox cc4, ComboBox cc5, ComboBox cc6, ComboBox cc7, ComboBox cc8, ComboBox cc9, ComboBox cc10, ComboBox cc11, ComboBox cc12, TextBox tb)
        {
            bool ret = true;
            try
            {
                if (AddFIleCheckBox.Checked)
                {
                    if(EImagePath.Text=="")
                    {
                        label18.Visible = true;
                        ret = false;
                    }
                    else
                    {
                        label18.Visible =false;
                        ret = false;
                    }
                }
                else if (AddFIle.Text == "")
                {
                    label18.Visible = true;
                    ret = false;
                }
                else
                {
                    label18.Visible = false;
                    ret = false;
                }
                    if ((CC1.Text != "" && CM1.Checked) || (CC2.Text != "" && CM2.Checked) || (CC3.Text != "" && CM3.Checked) || (CC4.Text != "" && CM4.Checked) || (CC5.Text != "" && CM5.Checked) || (CC6.Text != "" && CM6.Checked) || (CC7.Text != "" && CM8.Checked) || (CC8.Text != "" && CM8.Checked) || (CC9.Text != "" && CM9.Checked) || (CC10.Text != "" && CM10.Checked) || (CC11.Text != "" && CM11.Checked) || (CC12.Text != "" && CM12.Checked) || (CustomMail.Text != "" && CCM1.Checked))
                    {
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        MailMessage message = new MailMessage();
                        message.From = new MailAddress(UserName);
                        if (CM1.Checked == true )

                        {
                           message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(cc1.Text));
                        }
                        if (CM2.Checked == true)
                        {
                            message.To.Add("Undisclosed recipients" + UserName);
                            message.Bcc.Add(new MailAddress(cc2.Text));
                        }
                        if (CM3.Checked == true)
                        {
                            message.To.Add("Undisclosed recipients" + UserName);
                            message.Bcc.Add(new MailAddress(cc3.Text));
                        }
                        if (CM4.Checked == true)
                        {
                            message.To.Add("Undisclosed recipients" + UserName);
                            message.Bcc.Add(new MailAddress(cc4.Text));
                        }
                        if (CM5.Checked == true)
                        {
                            message.To.Add("Undisclosed recipients" + UserName);
                            message.Bcc.Add(new MailAddress(cc5.Text));
                        }
                        if (CM6.Checked == true)
                        {
                            message.To.Add("Undisclosed recipients" + UserName);
                            message.Bcc.Add(new MailAddress(cc6.Text));
                        }
                        if (CM7.Checked == true)
                        {
                            message.To.Add("Undisclosed recipients" + UserName);
                            message.Bcc.Add(new MailAddress(cc7.Text));
                        }
                        if (CM8.Checked == true)
                        {
                            message.To.Add("Undisclosed recipients" + UserName);
                            message.Bcc.Add(new MailAddress(cc8.Text));
                        }
                        if (CM9.Checked == true)
                        {
                            message.To.Add("Undisclosed recipients" + UserName);
                            message.Bcc.Add(new MailAddress(cc9.Text));
                        }
                        if (CM10.Checked == true)
                        {
                            message.To.Add("Undisclosed recipients" + UserName);
                            message.Bcc.Add(new MailAddress(cc10.Text));
                        }
                        if (CM11.Checked == true)
                        {
                            message.To.Add("Undisclosed recipients" + UserName);
                            message.Bcc.Add(new MailAddress(cc11.Text));
                        }
                        if (CM12.Checked == true)
                        {
                            message.To.Add("Undisclosed recipients" + UserName);
                            message.Bcc.Add(new MailAddress(cc12.Text));
                        }
                        if (CCM1.Checked == true)
                        {
                            message.To.Add("Undisclosed recipients" + UserName);
                            message.Bcc.Add(new MailAddress(tb.Text));
                        }
                        if (AddFIleCheckBox.Checked)
                        {
                            message.Attachments.Add(new Attachment(EImagePath.Text));
                        }
                        else
                        {
                            message.Attachments.Add(new Attachment(AddFIle.Text));
                        }
                        if (checkBox3.Checked)
                        {
                            message.Body = "ADD-ID : " + AddID.Text + " " + Environment.NewLine + Message.Text;
                        }
                        else
                        {
                            message.Body =Message.Text;
                        }
                        
                        label17.Visible = false;
                        message.Subject = Subject.Text;
                        client.EnableSsl = true;
                        //client.Timeout = 0;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential(UserName, Password);
                        //pictureBox2.Visible = true;
                        client.Send(message);
                        message = null;
                        MessageBox.Show(this, "Mail Sent");
                        //pictureBox2.Visible = false;
                        Status = "Mail Sent";
                        Mail();
                    }
                    else
                    {
                        label17.Visible = true;
                        ret = false;
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Mail Has Been Failed" + Environment.NewLine + ex.Message);
                Status = "Mail Sending Failed";
                Mail();
            }
            return ret;
        }
        /// <summary>
        /// this funciton is used to sent mail info goes into history tab
        /// </summary>
        public void Mail()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Insert Into Email_Sent (Add_ID,P_Person_Email,P_Name,Subject,Message,Status,EmailDate) values (@Add_ID,@P_Person_Email,@P_Name,@Subject,@Message,@Status,@EmailDate)", conn.connect);
                cmd.Parameters.AddWithValue("@Add_ID", AddID.Text);
                cmd.Parameters.AddWithValue("@P_Person_Email", CC1.Text);
                cmd.Parameters.AddWithValue("@P_Name", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Subject", Subject.Text);
                cmd.Parameters.AddWithValue("@Message", Message.Text);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@EmailDate", DateTime.Now.Date);
                conn.connect.Open();
                cmd.ExecuteNonQuery();
                conn.connect.Close();
                DeleteHistoryComboBox.Items.Clear();
                DeleteHistoryCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void checkBoxComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxselecteddata(CC1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CC1.Items.Clear();
            CM1.Enabled = true;
            ComboToCheckCombo(comboBox1, CC1);
            CC1.CheckBoxItems[0].Checked = true;
        }
        private void ComboToCheckCombo(ComboBox combo1, CheckBoxComboBox check2)
        {
            try
            {
                check2.Items.Clear();
                ConnectionClass con = new ConnectionClass();
                SqlCommand cmd = new SqlCommand("Select TOP 3000 * From Paper_New Where P_Name = @P_Name", con.connect);
                cmd.Parameters.AddWithValue("@P_Name", combo1.Text);
                con.connect.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    check2.Items.Add(rdr["P_Person_Email"].ToString());
                }
                con.connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MailFunction(CC1, CC2, CC3, CC4, CC5, CC6, CC7, CC8, CC9, CC10, CC11, CC12, CustomMail);
                HistoryGridView();
                MailSentHistory();
                MailSentFailedHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM2.Enabled = true;
            ComboToCheckCombo(comboBox2, CC2);
            CC2.CheckBoxItems[0].Checked = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM3.Enabled = true; checkboxcombobox(comboBox3, CC3);
            ComboToCheckCombo(comboBox3, CC3);
            CC3.CheckBoxItems[0].Checked = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM4.Enabled = true; checkboxcombobox(comboBox4, CC4);
            ComboToCheckCombo(comboBox4, CC4);
            CC4.CheckBoxItems[0].Checked = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM5.Enabled = true; checkboxcombobox(comboBox5, CC5);
            ComboToCheckCombo(comboBox5, CC5);
            CC5.CheckBoxItems[0].Checked = true;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM6.Enabled = true; CM6.Enabled = true; checkboxcombobox(comboBox6, CC6);
            ComboToCheckCombo(comboBox6, CC6);
            CC6.CheckBoxItems[0].Checked = true;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM7.Enabled = true; checkboxcombobox(comboBox7, CC7);
            ComboToCheckCombo(comboBox7, CC7);
            CC7.CheckBoxItems[0].Checked = true; ;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM8.Enabled = true; checkboxcombobox(comboBox8, CC8);
            ComboToCheckCombo(comboBox8, CC8);
            CC8.CheckBoxItems[0].Checked = true;
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM9.Enabled = true; checkboxcombobox(comboBox9, CC9);
            ComboToCheckCombo(comboBox9, CC9);
            CC9.CheckBoxItems[0].Checked = true;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM10.Enabled = true; checkboxcombobox(comboBox10, CC10);
            ComboToCheckCombo(comboBox10, CC10);
            CC10.CheckBoxItems[0].Checked = true;
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM11.Enabled = true; checkboxcombobox(comboBox11, CC11);
            ComboToCheckCombo(comboBox11, CC11);
            CC11.CheckBoxItems[0].Checked = true;
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM12.Enabled = true; checkboxcombobox(comboBox12, CC12);
            ComboToCheckCombo(comboBox12, CC12);
            CC12.CheckBoxItems[0].Checked = true;
        }

        private void checkBoxComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxselecteddata(CC2);
        }

        private void checkBoxComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxselecteddata(CC3);
        }

        private void checkBoxComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxselecteddata(CC4);
        }

        private void checkBoxComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxselecteddata(CC5);
        }

        private void checkBoxComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxselecteddata(CC6);
        }

        private void checkBoxComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxselecteddata(CC7);
        }

        private void checkBoxComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxselecteddata(CC8);
        }

        private void checkBoxComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxselecteddata(CC9);
        }

        private void checkBoxComboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxselecteddata(CC10);
        }

        private void checkBoxComboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxselecteddata(CC11);
        }

        private void checkBoxComboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxselecteddata(CC12);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            if (AddFIleCheckBox.Checked)
            {
                //open file dialog 
                OpenFileDialog open = new OpenFileDialog();
                // image filters
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box
                    pictureBox1.Image = new Bitmap(open.FileName);
                    // image file path
                    EImagePath.Text = open.FileName;
                }
            }
            else
            {
                //open file dialog 
                OpenFileDialog open = new OpenFileDialog();
                // image filters
                open.Filter = "Files(*.docx; *.pdf; *.xlsx;*.ppt;*.txt;*.zip;*.rar;)|*.docx; *.pdf; *.xlsx;*.ppt;*.txt;*.zip;*.rar;";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // image file path
                    AddFIle.Text = open.FileName;
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
            UrduMail(UCC1,UCC2,UCC3,UCC4,UCC5,UCC6,UCC7,UCC8,UCC9,UCC10,UCC11,UCC12,UrduCustomMailTextBox);
            HistoryGridView();
            MailSentHistory();
            MailSentFailedHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// this funciton is used to Urdu Mail
        /// </summary>
        /// <param name="_UCC1"></param>
        /// <param name="_UCC2"></param>
        /// <param name="_UCC3"></param>
        /// <param name="_UCC4"></param>
        /// <param name="_UCC5"></param>
        /// <param name="_UCC6"></param>
        /// <param name="_UCC7"></param>
        /// <param name="_UCC8"></param>
        /// <param name="_UCC9"></param>
        /// <param name="_UCC10"></param>
        /// <param name="_UCC11"></param>
        /// <param name="_UCC12"></param>
        /// <param name="_UrduCustomMailTextBox"></param>
        public bool UrduMail(ComboBox _UCC1,ComboBox _UCC2,ComboBox _UCC3,ComboBox _UCC4,ComboBox _UCC5,ComboBox _UCC6,ComboBox _UCC7,ComboBox _UCC8,ComboBox _UCC9,ComboBox _UCC10,ComboBox _UCC11,ComboBox _UCC12,TextBox _UrduCustomMailTextBox)
        {
            bool ret = true;
            try
            {
                if (UAddFileCheckBox.Checked)
                {
                    if (UrduimageFile.Text == "")
                    {
                        label32.Visible = true;
                        ret = false;
                    }
                    else
                    {
                        label32.Visible = false;
                        ret = false;
                    }
                }
                else if (UrduFilePath.Text == "")
                {
                    label32.Visible = true;
                    ret = false;
                }
                else
                {
                    label32.Visible = false;
                    ret = false;
                }
                    if ((UCC1.Text != "" && CM14.Checked) || (UCC2.Text != "" && CM15.Checked) || (UCC3.Text != "" && CM16.Checked) || (UCC4.Text != "" && CM17.Checked) || (UCC5.Text != "" && CM18.Checked) || (UCC6.Text != "" && CM19.Checked) || (UCC7.Text != "" && CM20.Checked) || (UCC8.Text != "" && CM21.Checked) || (UCC9.Text != "" && CM22.Checked) || (UCC10.Text != "" && CM23.Checked) || (UCC11.Text != "" && CM24.Checked) || (UCC12.Text != "" && CM25.Checked)||(UrduCustomMailTextBox.Text != "" && CCM2.Checked))
                    {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(UserName);
                    if (CM14.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_UCC1.Text));
                    }
                    if (CM15.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_UCC2.Text));
                    }
                    if (CM16.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_UCC3.Text));
                    }
                    if (CM17.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_UCC4.Text));
                    }
                    if (CM18.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_UCC5.Text));
                    }
                    if (CM19.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_UCC6.Text));
                    }
                    if (CM20.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_UCC7.Text));
                    }
                    if (CM21.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_UCC8.Text));
                    }
                    if (CM22.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_UCC9.Text));
                    }
                    if (CM23.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_UCC10.Text));
                    }
                    if (CM24.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_UCC11.Text));
                    }
                    if (CM25.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_UCC12.Text));
                    }
                    if (CCM2.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_UrduCustomMailTextBox.Text));
                    }
                    if (UAddFileCheckBox.Checked)
                    {
                        message.Attachments.Add(new Attachment(UrduimageFile.Text));
                    }
                    else
                    {
                        message.Attachments.Add(new Attachment(UrduFilePath.Text));
                    }
                    if (checkBox3.Checked)
                    {
                        message.Body = "ADD-ID : " + UrduAddIDTextBox.Text + " " + Environment.NewLine + Message.Text;
                    }
                    else
                    {
                        message.Body = UrduMessageTextBox.Text;
                    }
                    label33.Visible = false;
                    message.Subject = UrduSubjectTextBox.Text;
                    client.EnableSsl = true;
                    //client.Timeout = 0;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(UserName, Password);
                    //pictureBox3.Visible = true;
                    client.Send(message);
                    message = null;
                    MessageBox.Show(this, "Mail Sent");
                    //pictureBox3.Visible = false;
                    Status = "Mail Sent";
                    Mail();
                    }
                    else
                    {
                        label33.Visible = true;
                        ret = false;
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Mail Has Been Failed" + Environment.NewLine + ex.Message);
                Status = "Mail Sending Failed";
                Mail();
            }
            return ret;
        }
        /// <summary>
        /// this funciton is used to Sindhi Mail
        /// </summary>
        /// <param name="_SCC1"></param>
        /// <param name="_SCC2"></param>
        /// <param name="_SCC"></param>
        /// <param name="_SCC4"></param>
        /// <param name="_SCC5"></param>
        /// <param name="_SCC6"></param>
        /// <param name="_SCC7"></param>
        /// <param name="_SCC8"></param>
        /// <param name="_SCC9"></param>
        /// <param name="_SCC10"></param>
        /// <param name="_SCC11"></param>
        /// <param name="_SCC12"></param>
        /// <param name="_SindhiCustomMailTextBox"></param>
        public bool SindhiMail(ComboBox _SCC1, ComboBox _SCC2, ComboBox _SCC3, ComboBox _SCC4, ComboBox _SCC5, ComboBox _SCC6, ComboBox _SCC7, ComboBox _SCC8, ComboBox _SCC9, ComboBox _SCC10, ComboBox _SCC11, ComboBox _SCC12, TextBox _SindhiCustomMailTextBox)
        {
             bool ret = true;
            try
            {
                if (SindhiCheckBox.Checked)
                {
                    if (SindhiPathLabel.Text == "")
                    {
                        label35.Visible = true;
                        ret = false;
                    }
                    else
                    {
                        label35.Visible = false;
                        ret = false;
                    }
                }
                else if (SindhiPathLabelFile.Text == "")
                {
                    label35.Visible = true;
                    ret = false;
                }
                else
                {
                    label35.Visible = false;
                    ret = false;
                }
                    if ((SCC1.Text != "" && CM26.Checked) || (SCC2.Text != "" && CM27.Checked) || (SCC3.Text != "" && CM28.Checked) || (SCC4.Text != "" && CM29.Checked) || (SCC5.Text != "" && CM30.Checked) || (SCC6.Text != "" && CM31.Checked) || (SCC7.Text != "" && CM32.Checked) || (SCC8.Text != "" && CM33.Checked) || (SCC9.Text != "" && CM34.Checked) || (SCC10.Text != "" && CM35.Checked) || (SCC11.Text != "" && CM36.Checked) || (SCC12.Text != "" && CM37.Checked) || (SindhiCustomEmailTextBox.Text != "" && CCM3.Checked))
                    {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(UserName);
                    if (CM26.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_SCC1.Text));
                    }
                    if (CM27.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_SCC2.Text));
                    }
                    if (CM28.Checked == true)
                    {
                     message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_SCC3.Text));
                    }
                    if (CM29.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_SCC4.Text));
                    }
                    if (CM30.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_SCC5.Text));
                    }
                    if (CM31.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_SCC6.Text));
                    }
                    if (CM32.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_SCC7.Text));
                    }
                    if (CM33.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_SCC8.Text));
                    }
                    if (CM34.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_SCC9.Text));
                    }
                    if (CM35.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_SCC10.Text));
                    }
                    if (CM36.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_SCC11.Text));
                    }
                    if (CM37.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_SCC12.Text));
                    }
                    if (CCM3.Checked == true)
                    {
                        message.To.Add("Undisclosed recipients" + UserName);
                        message.Bcc.Add(new MailAddress(_SindhiCustomMailTextBox.Text));
                    }
                    if (SindhiCheckBox.Checked)
                    {
                        message.Attachments.Add(new Attachment(SindhiPathLabel.Text));
                    }
                    else
                    {
                        message.Attachments.Add(new Attachment(SindhiPathLabelFile.Text));
                    }
                    if (checkBox5.Checked)
                    {
                        message.Body = "ADD-ID : " + SindhiAddIDTextBox.Text + " " + Environment.NewLine + UrduMessageTextBox.Text;
                    }
                    else
                    {
                        message.Body = UrduMessageTextBox.Text;
                    }
                    label36.Visible = false;
                    message.Subject = UrduSubjectTextBox.Text;
                    client.EnableSsl = true;
                    //client.Timeout = 0;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(UserName, Password);
                    //pictureBox4.Visible = true;
                    client.Send(message);
                    message = null;
                    MessageBox.Show(this, "Mail Sent");
                    //pictureBox4.Visible = false;
                    Status = "Mail Sent";
                    Mail();
                    }
                    else
                    {
                        label36.Visible = true;
                        ret = false;
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Mail Failed" + Environment.NewLine + ex.Message);
                Status = "Mail Sending Failed";
                Mail();
            }
            return ret;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (P_ID.Text != "" && PersonNameTextBox.Text != "" && LanguageComboBox.Text != "" && PaperNameTextBox.Text != "" && PersonEmailTextBox.Text != "" && PersonContactTextBox.Text != "")
                {
                    LanguageComboBox.Items.Clear();
                    P_ID.Items.Clear();
                    ConnectionClass conn = new ConnectionClass();
                    SqlCommand cmd = new SqlCommand("Update Paper_New set P_Name=@P_Name,P_Langugae=@P_Langugae,P_Person_Name=@P_Person_Name,P_Person_Email=@P_Person_Email,P_Person_Contact_Number=@P_Person_Contact_Number where P_ID=@P_ID", conn.connect);
                    cmd.Parameters.AddWithValue("@P_ID", P_ID.Text);
                    cmd.Parameters.AddWithValue("@P_Name", PaperNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@P_Langugae", LanguageComboBox.Text);
                    cmd.Parameters.AddWithValue("@P_Person_Name", PersonNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@P_Person_Email", PersonEmailTextBox.Text);
                    cmd.Parameters.AddWithValue("@P_Person_Contact_Number", PersonContactTextBox.Text);
                    conn.connect.Open();
                    cmd.ExecuteNonQuery();
                    conn.connect.Close();
                    MessageBox.Show(this, "Record have Edited Successfully");
                    LoadEvent();
                    dataGridView2.Show();
                    NotFoundLabel.Hide();
                    AllCheckBox();
                    P_IDD();
                }
                else
                {
                    MessageBox.Show("Please Select an ID From DropDownBox For Update A Record","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox1.Checked == true)
            {
                dataGridView2.Show();
                AllCheckBox();
            }
            else
            {
                dataGridView2.Hide();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { 
            if (PaperNameTextBox.Text != "")
            {

                checkBox1.Checked = false;
                ConnectionClass con = new ConnectionClass();
                SqlCommand cmd = new SqlCommand("Select Count(*) From Paper_New Where P_Name Like '" + PaperNameTextBox.Text + "%'", con.connect);
                con.connect.Open();
                int Result = (int)cmd.ExecuteScalar();

                if (Result >= 1)
                {
                    NotFoundLabel.Visible = false;
                    dataGridView2.Visible = true;
                    SqlCommand cmdSearch = new SqlCommand("Select TOP 3000 * From Paper_New Where P_Name LiKe '" + PaperNameTextBox.Text + "%'", con.connect);
                    SqlDataReader rdr = cmdSearch.ExecuteReader();
                    BindingSource source = new BindingSource();
                    source.DataSource = rdr;
                    dataGridView2.DataSource = source;
                    con.connect.Close();
                }
                else
                {
                    dataGridView2.Visible = false;
                    NotFoundLabel.Visible = true;
                }
            }
            else
            {
                dataGridView2.Visible = false;
                NotFoundLabel.Visible = false;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void P_ID_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                conn.connect.Open();
                SqlCommand cmd = new SqlCommand("Select TOP 3000 * from Paper_New where P_ID=@P_ID", conn.connect);
                cmd.Parameters.AddWithValue("@P_ID", P_ID.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    LanguageComboBox.Text = dr["P_Langugae"].ToString();
                    PaperNameTextBox.Text = dr["P_Name"].ToString();
                    PersonNameTextBox.Text = dr["P_Person_Name"].ToString();
                    PersonEmailTextBox.Text = dr["P_Person_Email"].ToString();
                    PersonContactTextBox.Text = dr["P_Person_Contact_Number"].ToString();
                }
                conn.connect.Close();
                conn.connect.Open();
                SqlCommand cmd2 = new SqlCommand("Select Count(*) From Paper_New Where P_ID = @P_ID", conn.connect);
                cmd2.Parameters.AddWithValue("@P_ID", P_ID.Text);
                int Result = (int)cmd2.ExecuteScalar();
                if (Result == 1)
                {
                    SqlCommand cmd3 = new SqlCommand("Select TOP 3000 * From Paper_New Where P_ID = @P_Id", conn.connect);
                    cmd3.Parameters.AddWithValue("@P_Id", P_ID.Text);
                    SqlDataReader rdr = cmd3.ExecuteReader();
                    BindingSource source = new BindingSource();
                    source.DataSource = rdr;
                    dataGridView2.DataSource = source;
                }
                conn.connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (P_ID.Text != "" && PersonNameTextBox.Text != "" && LanguageComboBox.Text != "" && PaperNameTextBox.Text!="" && PersonEmailTextBox.Text!="" && PersonContactTextBox.Text!="")
                {
                LanguageComboBox.Items.Clear();
                P_ID.Items.Clear();
                ConnectionClass conn = new ConnectionClass();
                SqlCommand cmd = new SqlCommand("Insert into Paper_New (P_ID,P_Name,P_Langugae,P_Person_Name,P_Person_Email,P_Person_Contact_Number) values (@P_ID,@P_Name,@P_Langugae,@P_Person_Name,@P_Person_Email,@P_Person_Contact_Number)", conn.connect);
                cmd.Parameters.AddWithValue("@P_ID", P_ID.Text);
                cmd.Parameters.AddWithValue("@P_Name", PaperNameTextBox.Text);
                cmd.Parameters.AddWithValue("@P_Langugae", LanguageComboBox.Text);
                cmd.Parameters.AddWithValue("@P_Person_Name", PersonNameTextBox.Text);
                cmd.Parameters.AddWithValue("@P_Person_Email", PersonEmailTextBox.Text);
                cmd.Parameters.AddWithValue("@P_Person_Contact_Number", PersonContactTextBox.Text);
                conn.connect.Open();
                cmd.ExecuteNonQuery();
                conn.connect.Close();
                MessageBox.Show(this, "Saved Succeed");
                LoadEvent();
                dataGridView2.Show();
                NotFoundLabel.Hide();
                AllCheckBox();
                }
                else
                {
                    MessageBox.Show("Please Insert a Data in TextBoxes", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ConnectionClass conn = new ConnectionClass();
            conn.connect.Open();
            try
            {
                if (P_ID.Text != "" && PersonNameTextBox.Text != "" && LanguageComboBox.Text != "" && PaperNameTextBox.Text != "" && PersonEmailTextBox.Text != "" && PersonContactTextBox.Text != "")
                {
                    LanguageComboBox.Items.Clear();
                    P_ID.Items.Clear();
                    SqlCommand cmd = new SqlCommand("Delete from [dbo].[Paper_New] where P_ID=@P_ID", conn.connect);
                    cmd.Parameters.AddWithValue("@P_ID", P_ID.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Record has been Deleted Successfully", "Deleted");
                    LoadEvent();
                    dataGridView2.Show();
                    NotFoundLabel.Hide();
                    AllCheckBox();
                    P_IDD();
                }
                else
                {
                    MessageBox.Show("Please Select an ID From DropDownBox For Delete A Record", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            conn.connect.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                AllCheckBox();
                LoadEvent();
                dataGridView2.Hide();
                NotFoundLabel.Hide();
                checkBox1.Checked = false;
                PersonContactTextBox.Clear();
                PersonEmailTextBox.Clear();
                PersonNameTextBox.Clear();
                PaperNameTextBox.Clear();
                P_ID.Text = "";
                LanguageComboBox.Text = "";
                P_IDD();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                conn.connect.Open();
                SqlCommand cmdcheck = new SqlCommand("Select count(*) from Email_Sent ", conn.connect);
                int Result = (int)cmdcheck.ExecuteScalar();
                if (Result >= 1)
                {
                    dateTimePicker1.Enabled = false;
                    
                    lblRecordNotFoundMessagre.Visible = false;
                    SqlCommand cmd = new SqlCommand("Select TOP 3000 * From Email_Sent", conn.connect);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    BindingSource source = new BindingSource();
                    source.DataSource = rdr;
                    dataGridView1.DataSource = source;
                    dataGridView1.Visible = true;
                    conn.connect.Close();
                }
                else
                {
                    lblRecordNotFoundMessagre.Visible = true;
                   lblRecordNotFoundMessagre.Text="No Record Found";
                    conn.connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            lblRecordNotFoundMessagre.Visible = false;
            dataGridView1.Visible = false;
            if (radioButton2.Checked)
            {
                MailSentHistory();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            lblRecordNotFoundMessagre.Visible = false;
            dataGridView1.Visible = false;
            if (radioButton3.Checked)
            {
                MailSentFailedHistory();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// this funciton is used to today date radio button
        /// </summary>
        public void radioButton()
        {
            try { 
            if (radioButton4.Checked)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Visible = false;
                ConnectionClass con = new ConnectionClass();
                SqlCommand cmd = new SqlCommand("Select Count(*) From Email_Sent Where EmailDate = @EmailDate", con.connect);
                cmd.Parameters.AddWithValue("@EmailDate", DateTime.Today);
                con.connect.Open();
                int Result = (int)cmd.ExecuteScalar();

                if (Result >= 1)
                {
                    SqlCommand cmdFound = new SqlCommand("Select TOP 3000 * From Email_Sent Where EmailDate = @EmailDate", con.connect);
                    cmdFound.Parameters.AddWithValue("@EmailDate", DateTime.Today);
                    SqlDataReader rdr = cmdFound.ExecuteReader();
                    dataGridView1.Visible = true;
                    BindingSource source = new BindingSource();
                    source.DataSource = rdr;
                    dataGridView1.DataSource = source;
                    con.connect.Close();
                }
                else
                {
                    dataGridView1.Visible = false;
                    lblRecordNotFoundMessagre.Visible = true;
                    con.connect.Close();
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radioButton();
            

        }
        /// <summary>
        /// this funciton is datetime picker funciton data 
        /// </summary>
        public void datetimepicker()
        {
            try { 
            if (rbSelectByDate.Checked)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                ConnectionClass con = new ConnectionClass();
                SqlCommand cmd = new SqlCommand("Select Count(*) From Email_Sent Where EmailDate = @EmailDate", con.connect);
                con.connect.Open();
                cmd.Parameters.AddWithValue("@EmailDate", dateTimePicker1.Value.Date);
                int Result = (int)cmd.ExecuteScalar();
                    
                if (Result >= 1)
                {
                    SqlCommand cmdData = new SqlCommand("Select TOP 3000 * From Email_Sent Where EmailDate = @EmailDate", con.connect);
                    cmdData.Parameters.AddWithValue("@EmailDate", dateTimePicker1.Value.Date);
                    SqlDataReader rdr = cmdData.ExecuteReader();
                    BindingSource source = new BindingSource();
                    dataGridView1.Visible = true;
                    lblRecordNotFoundMessagre.Visible = false;
                    source.DataSource = rdr;
                    dataGridView1.DataSource = source;
                    con.connect.Close();
                }
                else
                {
                    dataGridView1.Visible = false;
                    lblRecordNotFoundMessagre.Visible = true;
                    con.connect.Close();
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            datetimepicker();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            try { 
          DialogResult DR = MessageBox.Show("Do you Want TO Delete Selected History", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DR == DialogResult.Yes)
            {
                conn.connect.Open();
                SqlCommand cmd = new SqlCommand("Delete From Email_Sent Where EmailID=@EmailID", conn.connect);
                cmd.Parameters.AddWithValue("@EmailID", DeleteHistoryComboBox.Text);
                cmd.ExecuteScalar();
                conn.connect.Close();
                MessageBox.Show("Data has been Deleted", "Command Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HistoryGridView1();
                DeleteHistoryComboBox.Items.Clear();
                DeleteHistoryCombo();
            }
            else if (DR == DialogResult.No) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (checkBox2.Checked == true)
            {
               DialogResult DR = MessageBox.Show("Do you Want TO Delete All History", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DR == DialogResult.Yes)
                {
                    conn.connect.Open();
                    SqlCommand cmd = new SqlCommand("Delete  From Email_Sent", conn.connect);
                    cmd.ExecuteNonQuery();
                    dataGridView1.Visible = false;
                    lblRecordNotFoundMessagre.Visible = true;
                    DeleteHistoryComboBox.Items.Clear();
                    DeleteHistoryCombo();
                    HistoryGridView();
                    MailSentHistory();
                    MailSentFailedHistory();
                    radioButton();
                    datetimepicker();
                    conn.connect.Close();
                }
                else if (DR == DialogResult.No) { }
            }
            else { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UrduBrwoseButton_Click(object sender, EventArgs e)
        {
            try { 
            if (UAddFileCheckBox.Checked)
            {
                //open file dialog 
                OpenFileDialog open = new OpenFileDialog();
                // image filters
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box
                    UrduPictureBox.Image = new Bitmap(open.FileName);
                    // image file path
                    UrduimageFile.Text = open.FileName;
                }
            }
            else
            {
                //open file dialog 
                OpenFileDialog open = new OpenFileDialog();
                // image filters
                open.Filter = "Files(*.docx; *.pdf; *.xlsx;*.ppt;*.txt;*.zip;*.rar;)|*.docx; *.pdf; *.xlsx;*.ppt;*.txt;*.zip;*.rar;";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // image file path
                    UrduFilePath.Text = open.FileName;
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SindhiBrowseButton_Click(object sender, EventArgs e)
        {
            try { 
            if (SindhiCheckBox.Checked)
            {
                //open file dialog 
                OpenFileDialog open = new OpenFileDialog();
                // image filters
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box
                    SindhiPictureBox.Image = new Bitmap(open.FileName);
                    // image file path
                    SindhiPathLabel.Text = open.FileName;
                }
            }
            else
            {
                //open file dialog 
                OpenFileDialog open = new OpenFileDialog();
                // image filters
                open.Filter = "Files(*.docx; *.pdf; *.xlsx;*.ppt;*.txt;*.zip;*.rar;)|*.docx; *.pdf; *.xlsx;*.ppt;*.txt;*.zip;*.rar;";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // image file path
                    SindhiPathLabelFile.Text = open.FileName;
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SindhiSendButton_Click(object sender, EventArgs e)
        {
            try { 
            SindhiMail(SCC1, SCC2, SCC3, SCC4, SCC5, SCC6, SCC7, SCC8, SCC9, SCC10, SCC11, SCC12, SindhiCustomEmailTextBox);
            HistoryGridView();
            MailSentHistory();
            MailSentFailedHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SCombo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM26.Enabled = true;
            Sindhicheckboxcombobox(SCombo1,SCC1);
            SCC1.CheckBoxItems[0].Checked = true;

        }
        private void UCombo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM14.Enabled = true; 
            Urducheckboxcombobox(UCombo1, UCC1);
            UCC1.CheckBoxItems[0].Checked = true;
        }

        private void UCombo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM15.Enabled = true; 
            Urducheckboxcombobox(UCombo2, UCC2);
            UCC2.CheckBoxItems[0].Checked = true;
        }

        private void UCombo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM16.Enabled = true; Urducheckboxcombobox(UCombo3, UCC3);
            UCC3.CheckBoxItems[0].Checked = true;
        }

        private void UCombo4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM17.Enabled = true; Urducheckboxcombobox(UCombo4, UCC4);
            UCC5.CheckBoxItems[0].Checked = true;
        }

        private void UCombo5_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM18.Enabled = true; Urducheckboxcombobox(UCombo5, UCC5);
            UCC6.CheckBoxItems[0].Checked = true;
        }

        private void UCombo6_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM19.Enabled = true; Urducheckboxcombobox(UCombo6, UCC6);
            UCC6.CheckBoxItems[0].Checked = true;
        }

        private void UCombo7_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM21.Enabled = true; CM20.Enabled = true; Urducheckboxcombobox(UCombo7, UCC7);
            UCC8.CheckBoxItems[0].Checked = true;
        }

        private void UCombo8_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM22.Enabled = true; Urducheckboxcombobox(UCombo8, UCC8);
            UCC8.CheckBoxItems[0].Checked = true;
        }

        private void UCombo9_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM23.Enabled = true; Urducheckboxcombobox(UCombo9, UCC9);
            UCC9.CheckBoxItems[0].Checked = true;
        }

        private void UCombo10_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM24.Enabled = true; Urducheckboxcombobox(UCombo10, UCC10);
            UCC10.CheckBoxItems[0].Checked = true;
        }

        private void UCombo11_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM25.Enabled = true; Urducheckboxcombobox(UCombo11, UCC11);
            UCC11.CheckBoxItems[0].Checked = true;
        }

        private void UCombo12_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM26.Enabled = true; Urducheckboxcombobox(UCombo12, UCC12);
            UCC12.CheckBoxItems[0].Checked = true;
        }

        private void UCC1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urducomboboxselecteddata(UCC1);
        }

        private void UCC2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urducomboboxselecteddata(UCC2);
        }

        private void UCC3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urducomboboxselecteddata(UCC3);
        }

        private void UCC4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urducomboboxselecteddata(UCC4);
        }

        private void UCC5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urducomboboxselecteddata(UCC5);
        }

        private void UCC6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urducomboboxselecteddata(UCC6);
        }

        private void UCC7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urducomboboxselecteddata(UCC7);
        }

        private void UCC8_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urducomboboxselecteddata(UCC8);
        }

        private void UCC9_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urducomboboxselecteddata(UCC9);
        }

        private void UCC10_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urducomboboxselecteddata(UCC10);
        }

        private void UCC11_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urducomboboxselecteddata(UCC10);
        }

        private void UCC12_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urducomboboxselecteddata(UCC12);
        }

        private void DeleteHistoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void CM1_CheckedChanged(object sender, EventArgs e)
        {
            if (CM1.Checked == true)
            {
                CC1.Enabled = true;
            }
            else
            {
                CC1.Enabled =false;
            }
        }

        private void CM2_CheckedChanged(object sender, EventArgs e)
        {
            if (CM2.Checked == true)
            {
                CC2.Enabled = true;
            }
            else
            {
                CC2.Enabled = false;
            }
        }

        private void CM3_CheckedChanged(object sender, EventArgs e)
        {
            if (CM3.Checked == true)
            {
                CC3.Enabled = true;
            }
            else
            {
                CC3.Enabled = false;
            }
        }

        private void CM4_CheckedChanged(object sender, EventArgs e)
        {
            if (CM4.Checked == true)
            {
                CC4.Enabled = true;
            }
            else
            {
                CC4.Enabled = false;
            }
        }

        private void CM5_CheckedChanged(object sender, EventArgs e)
        {
            if (CM5.Checked == true)
            {
                CC5.Enabled = true;
            }
            else
            {
                CC5.Enabled = false;
            }
        }

        private void CM6_CheckedChanged(object sender, EventArgs e)
        {
            if (CM6.Checked == true)
            {
                CC6.Enabled = true;
            }
            else
            {
                CC6.Enabled = false;
            }
        }

        private void CM7_CheckedChanged(object sender, EventArgs e)
        {
            if (CM7.Checked == true)
            {
                CC7.Enabled = true;
            }
            else
            {
                CC7.Enabled = false;
            }
        }

        private void CM8_CheckedChanged(object sender, EventArgs e)
        {
            if (CM8.Checked == true)
            {
                CC8.Enabled = true;
            }
            else
            {
                CC8.Enabled = false;
            }
        }

        private void CM9_CheckedChanged(object sender, EventArgs e)
        {
            if (CM9.Checked == true)
            {
                CC9.Enabled = true;
            }
            else
            {
                CC9.Enabled = false;
            }
        }

        private void CM10_CheckedChanged(object sender, EventArgs e)
        {
            if (CM10.Checked == true)
            {
                CC10.Enabled = true;
            }
            else
            {
                CC10.Enabled = false;
            }
        }

        private void CM11_CheckedChanged(object sender, EventArgs e)
        {
            if (CM11.Checked == true)
            {
                CC11.Enabled = true;
            }
            else
            {
                CC11.Enabled = false;
            }
        }

        private void CM12_CheckedChanged(object sender, EventArgs e)
        {
            if (CM12.Checked == true)
            {
                CC12.Enabled = true;
            }
            else
            {
                CC12.Enabled = false;
            }
        }

        private void CCM1_CheckedChanged(object sender, EventArgs e)
        {
            if (CCM1.Checked == true)
            {
                CustomMail.Enabled = true;
            }
            else
            {
                CustomMail.Enabled = false;
            }
        }

        private void CCM3_CheckedChanged(object sender, EventArgs e)
        {
            if (CCM3.Checked == true)
            {
                SindhiCustomEmailTextBox.Enabled = true;
            }
            else
            {
                SindhiCustomEmailTextBox.Enabled = false;
            }
        }

        private void CCM2_CheckedChanged(object sender, EventArgs e)
        {
            if (CCM2.Checked == true)
            {
                UrduCustomMailTextBox.Enabled = true;
            }
            else
            {
                UrduCustomMailTextBox.Enabled = false;
            }
        }

        private void CM14_CheckedChanged(object sender, EventArgs e)
        {
            if (CM14.Checked == true)
            {
                UCC1.Enabled = true;
            }
            else
            {
                UCC1.Enabled = false;
            }
        }

        private void CM15_CheckedChanged(object sender, EventArgs e)
        {
            if (CM15.Checked == true)
            {
                UCC2.Enabled = true;
            }
            else
            {
                UCC2.Enabled = false;
            }
        }

        private void CM16_CheckedChanged(object sender, EventArgs e)
        {
            if (CM16.Checked == true)
            {
                UCC3.Enabled = true;
            }
            else
            {
                UCC3.Enabled = false;
            }
        }

        private void CM17_CheckedChanged(object sender, EventArgs e)
        {
            if (CM17.Checked == true)
            {
                UCC4.Enabled = true;
            }
            else
            {
                UCC4.Enabled = false;
            }
        }

        private void CM18_CheckedChanged(object sender, EventArgs e)
        {
            if (CM18.Checked == true)
            {
                UCC5.Enabled = true;
            }
            else
            {
                UCC5.Enabled = false;
            }
        }

        private void CM19_CheckedChanged(object sender, EventArgs e)
        {
            if (CM19.Checked == true)
            {
                UCC6.Enabled = true;
            }
            else
            {
                UCC6.Enabled = false;
            }
        }

        private void CM20_CheckedChanged(object sender, EventArgs e)
        {
            if (CM20.Checked == true)
            {
                UCC7.Enabled = true;
            }
            else
            {
                UCC7.Enabled = false;
            }
        }

        private void CM21_CheckedChanged(object sender, EventArgs e)
        {
            if (CM21.Checked == true)
            {
                UCC8.Enabled = true;
            }
            else
            {
                UCC8.Enabled = false;
            }
        }

        private void CM22_CheckedChanged(object sender, EventArgs e)
        {
            if (CM22.Checked == true)
            {
                UCC9.Enabled = true;
            }
            else
            {
                UCC9.Enabled = false;
            }
        }

        private void CM23_CheckedChanged(object sender, EventArgs e)
        {
            if (CM23.Checked == true)
            {
                UCC10.Enabled = true;
            }
            else
            {
                UCC10.Enabled = false;
            }
        }

        private void CM24_CheckedChanged(object sender, EventArgs e)
        {
            if (CM24.Checked == true)
            {
                UCC11.Enabled = true;
            }
            else
            {
                UCC11.Enabled = false;
            }
        }

        private void CM25_CheckedChanged(object sender, EventArgs e)
        {
            if (CM25.Checked == true)
            {
                UCC12.Enabled = true;
            }
            else
            {
                UCC12.Enabled = false;
            }
        }

        private void CM27_CheckedChanged(object sender, EventArgs e)
        {
            if (CM27.Checked == true)
            {
                SCC2.Enabled = true;
            }
            else
            {
                SCC2.Enabled = false;
            }
        }

        private void CM26_CheckedChanged(object sender, EventArgs e)
        {
            if (CM26.Checked == true)
            {
                SCC1.Enabled = true;
            }
            else
            {
                SCC1.Enabled = false;
            }
        }

        private void CM28_CheckedChanged(object sender, EventArgs e)
        {
            if (CM28.Checked == true)
            {
                SCC3.Enabled = true;
            }
            else
            {
                SCC3.Enabled = false;
            }
        }

        private void CM29_CheckedChanged(object sender, EventArgs e)
        {
            if (CM29.Checked == true)
            {
                SCC4.Enabled = true;
            }
            else
            {
                SCC4.Enabled = false;
            }
        }

        private void CM30_CheckedChanged(object sender, EventArgs e)
        {
            if (CM30.Checked == true)
            {
                SCC5.Enabled = true;
            }
            else
            {
                SCC5.Enabled = false;
            }
        }

        private void CM31_CheckedChanged(object sender, EventArgs e)
        {
            if (CM31.Checked == true)
            {
                SCC6.Enabled = true;
            }
            else
            {
                SCC6.Enabled = false;
            }
        }

        private void CM32_CheckedChanged(object sender, EventArgs e)
        {
            if (CM32.Checked == true)
            {
                SCC7.Enabled = true;
            }
            else
            {
                SCC7.Enabled = false;
            }
        }

        private void CM33_CheckedChanged(object sender, EventArgs e)
        {
            if (CM33.Checked == true)
            {
                SCC8.Enabled = true;
            }
            else
            {
                SCC8.Enabled = false;
            }
        }

        private void CM34_CheckedChanged(object sender, EventArgs e)
        {
            if (CM34.Checked == true)
            {
                SCC9.Enabled = true;
            }
            else
            {
                SCC9.Enabled = false;
            }
        }

        private void CM35_CheckedChanged(object sender, EventArgs e)
        {
            if (CM35.Checked == true)
            {
                SCC10.Enabled = true;
            }
            else
            {
                SCC10.Enabled = false;
            }
        }

        private void CM36_CheckedChanged(object sender, EventArgs e)
        {
            if (CM36.Checked == true)
            {
                SCC11.Enabled = true;
            }
            else
            {
                SCC11.Enabled = false;
            }
        }

        private void CM37_CheckedChanged(object sender, EventArgs e)
        {
            if (CM37.Checked == true)
            {
                SCC12.Enabled = true;
            }
            else
            {
                SCC12.Enabled = false;
            }
        }

        private void rbSelectByDate_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
 
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void SCombo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM27.Enabled = true;
            Sindhicheckboxcombobox(SCombo2, SCC2);
            SCC1.CheckBoxItems[0].Checked = true;
        }

        private void SCombo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM28.Enabled = true;
            Sindhicheckboxcombobox(SCombo3, SCC3);
            SCC3.CheckBoxItems[0].Checked = true;
        }

        private void SCombo4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM29.Enabled = true;
            Sindhicheckboxcombobox(SCombo4, SCC4);
            SCC4.CheckBoxItems[0].Checked = true;
        }

        private void SCombo5_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM30.Enabled = true;
            Sindhicheckboxcombobox(SCombo5, SCC5);
            SCC5.CheckBoxItems[0].Checked = true;
        }

        private void SCombo6_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM31.Enabled = true;
            Sindhicheckboxcombobox(SCombo6, SCC6);
            SCC6.CheckBoxItems[0].Checked = true;
        }

        private void SCombo7_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM32.Enabled = true;
            Sindhicheckboxcombobox(SCombo7, SCC7);
            SCC7.CheckBoxItems[0].Checked = true;
        }

        private void SCombo8_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM33.Enabled = true;
            Sindhicheckboxcombobox(SCombo8, SCC8);
            SCC8.CheckBoxItems[0].Checked = true;
        }

        private void SCombo9_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM34.Enabled = true;
            Sindhicheckboxcombobox(SCombo9, SCC9);
            SCC9.CheckBoxItems[0].Checked = true;
        }

        private void SCombo10_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM35.Enabled = true;
            Sindhicheckboxcombobox(SCombo10, SCC10);
            SCC10.CheckBoxItems[0].Checked = true;
        }

        private void SCombo11_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM36.Enabled = true;
            Sindhicheckboxcombobox(SCombo11, SCC11);
            SCC11.CheckBoxItems[0].Checked = true;
        }

        private void SCombo12_SelectedIndexChanged(object sender, EventArgs e)
        {
            CM37.Enabled = true;
            Sindhicheckboxcombobox(SCombo12, SCC12);
            SCC12.CheckBoxItems[0].Checked = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (AddFIleCheckBox.Checked)
            {
                EImagePath.Visible = true;
                label7.Visible = true;
                pictureBox1.Visible = true;
                AddFIle.Visible = false;
                AddFIle.Enabled = false;
                label9.Visible = false;
            }
            else
            {
                AddFIle.Visible = true;
                AddFIle.Enabled = true;
                label9.Visible = true;
                EImagePath.Visible = false;
                label7.Visible = false;
                pictureBox1.Visible = false;
            }
        }

        private void UAddFIleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UAddFileCheckBox.Checked)
            {
                UrduimageFile.Visible = true;
                UPreview.Visible = true;
                UrduPictureBox.Visible = true;
                UFile.Visible = false;
                UrduFilePath.Visible = false;
            }
            else
            {
                UrduimageFile.Visible = false;
                UPreview.Visible = false;
                UrduPictureBox.Visible =false;
                UFile.Visible = true;
                UrduFilePath.Visible = true;
            }
        }

        private void UrduPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void SindhiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SindhiCheckBox.Checked)
            {
                File.Visible = false;
                SindhiPathLabelFile.Visible = false;
                SPreview.Visible = true;
                SindhiPathLabel.Visible = true;
                SindhiPictureBox.Visible = true;
            }
            else
            {
                File.Visible = true;
                SindhiPathLabelFile.Visible = true;
                SPreview.Visible = false;
                SindhiPathLabel.Visible = false;
                SindhiPictureBox.Visible = false;
            }
        }

        private void SCC1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sindhicomboboxselecteddata(SCC1);
        }

        private void SCC2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sindhicomboboxselecteddata(SCC2);
        }

        private void SCC3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sindhicomboboxselecteddata(SCC3);
        }

        private void SCC4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sindhicomboboxselecteddata(SCC4);
        }

        private void SCC5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sindhicomboboxselecteddata(SCC5);
        }

        private void SCC6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sindhicomboboxselecteddata(SCC6);
        }

        private void SCC7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sindhicomboboxselecteddata(SCC7);
        }

        private void SCC8_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sindhicomboboxselecteddata(SCC8);
        }

        private void SCC9_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sindhicomboboxselecteddata(SCC9);
        }

        private void SCC10_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sindhicomboboxselecteddata(SCC10);
        }

        private void SCC11_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sindhicomboboxselecteddata(SCC11);
        }

        private void SCC12_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sindhicomboboxselecteddata(SCC12);
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                AddID.Enabled = true;
            }
            else
            {
                AddID.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                UrduAddIDTextBox.Enabled = true;
            }
            else
            {
                UrduAddIDTextBox.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                SindhiAddIDTextBox.Enabled = true;
            }
            else
            {
                SindhiAddIDTextBox.Enabled = false;
            }
        }
    }
}

