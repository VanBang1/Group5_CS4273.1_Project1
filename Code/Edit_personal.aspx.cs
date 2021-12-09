using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group5_QLCGP
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        System.Data.SqlClient.SqlConnection con;
        public string html;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\OneDrive\\Desktop\\Group5_QLCGP\\App_Data\\data.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand("select id,Name,Gender,Date_of_birth,Pic,user_name from persons ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int i = cmd.ExecuteNonQuery();
         

            if (dt.Rows.Count > 0)
            for(i=0;i< dt.Rows.Count;i++)
            {
                html += "<tr>";
                html += "<td>"+dt.Rows[i][0]+"</td >";
                    html += "<td>" + dt.Rows[i][1] + "</td >";
                    html += "<td>" + dt.Rows[i][2] + "</td >";
                    html += "<td>" + dt.Rows[i][3] + "</td >";
                    html += "<td>" + dt.Rows[i][4] + "</td >";
                    html += "<td>" + dt.Rows[i][5] + "</td >";
                 //   html += "<td>" + dt.Rows[i][6] + "</td >";
                     
                    
                    html += "</tr>";
                }
            con.Close();
            
        }
   

        protected void Button1_Click(object sender, EventArgs e)
        {
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\OneDrive\\Desktop\\Group5_QLCGP\\App_Data\\data.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from persons where id=@id", con);
            cmd.Parameters.AddWithValue("@id", TextBox1.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
           int i = cmd.ExecuteNonQuery();
        }
    }
}