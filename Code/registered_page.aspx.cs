using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group5_QLCGP
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        System.Data.SqlClient.SqlConnection con; //khai bao bien connect
        protected void Button1_Click(object sender, EventArgs e)
        {
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\OneDrive\\Documents\\data.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();   //connect db
            SqlCommand cmd = new SqlCommand("insert into account(user_name,password) values (@username,@password)", con);
            if (TextBox2.Text != TextBox3.Text)
            {
                Label1.Text = "Password not the same ";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("select * from account where user_name=@username", con);
                cmd1.Parameters.AddWithValue("@username", TextBox1.Text);
               
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);

                int i = cmd1.ExecuteNonQuery();

                if (dt.Rows.Count > 0)
                {
                    Label1.Text = "Your username was exited!";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@username", TextBox1.Text);
                    cmd.Parameters.AddWithValue("password", encryption(TextBox2.Text));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Label1.Text = "Your username and password is created";
                    Label1.ForeColor = System.Drawing.Color.Green;
                }
            }  
        }
        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
        }
    }
 
}