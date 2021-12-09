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
    public partial class WebForm3 : System.Web.UI.Page
    {
        System.Data.SqlClient.SqlConnection con;
      //  int tong_ds;//tong so records
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\OneDrive\\Desktop\\Group5_QLCGP\\App_Data\\data.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand("select id,Name from persons", con);
             
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            String columns = "{0, -5}{1, -35}";  //do rong cac cot trong listbox
            if (dt.Rows.Count > 0)
            {
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    choses_relate.Items.Add(String.Format(columns, dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString()));
                   
                }

              //  tong_ds = i; //tong so nguoi trong danh sach              
            }

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\OneDrive\\Desktop\\Group5_QLCGP\\App_Data\\data.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();   //connect db
            SqlCommand cmd = new SqlCommand("insert into persons(id,Name,Gender,Date_of_birth,Pic,user_name,id_partner) values (@id,@Name,@Gender,@Date_of_birth,@Pic,@username,@id_partner)", con);
            cmd.Parameters.AddWithValue("@id", TextBox0.Text);
            cmd.Parameters.AddWithValue("@Name", txt_name.Text);
            cmd.Parameters.AddWithValue("@Gender", gender.SelectedValue);
            cmd.Parameters.AddWithValue("@Date_of_birth", bd.Text);
            cmd.Parameters.AddWithValue("@Pic", image_link.Text);
            cmd.Parameters.AddWithValue("@id_partner", choses_relate.SelectedValue.Substring(0, 3));
            string loggedUsername = Session["UserName"] as string;
            loggedUsername = "Bang3";
            cmd.Parameters.AddWithValue("@username", loggedUsername);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("insert into related(id,name,position,id_related) values (@id,@Name,@position,@id_partner)", con);
            cmd.Parameters.AddWithValue("@name", txt_name.Text);
            cmd.Parameters.AddWithValue("@id", TextBox0.Text);
            cmd.Parameters.AddWithValue("@id_partner", choses_relate.SelectedValue.Substring(0, 3));
            cmd.Parameters.AddWithValue("@position", position.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "insert successfull..";
            Label1.ForeColor = System.Drawing.Color.Green;
        }

        
    }
}