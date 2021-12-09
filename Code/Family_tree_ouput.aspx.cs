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
    public partial class WebForm4 : System.Web.UI.Page
    {
       
        
        public  String mangtree = "";
        public String mangdetail = "";
        public string html = "";
    
        protected void Page_Load(object sender, EventArgs e)
        { 
            //var TreeRecursion = new TreeRecursion();
            //var TreeUi = TreeRecursion.GenerateTreeUi();
           html = Taotree();
             
        }
        System.Data.SqlClient.SqlConnection con;
        DataTable dt = new DataTable();
        protected String Taotree()
        {

            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\OneDrive\\Desktop\\Group5_QLCGP\\App_Data\\data.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();

            SqlCommand cmd = new SqlCommand("select id,Name,id_partner from persons",con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            int num_rs = dt.Rows.Count;
            

            if (num_rs > 0)  //so duong dong >0
            {
                html =  recurseMenu("1");
               // html = html.Replace(""","");
                 


            }
            //String html = " tree = {1: {2: '',3: {6: '',7: '',},4: '',5: ''},};";
            return html;
        }


        protected String findrelated(String id)
        {

            DataTable dt1= new DataTable();
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\OneDrive\\Desktop\\Group5_QLCGP\\App_Data\\data.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand("select  name,position  from related where id=@id", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@id", id.ToString());
            sda.Fill(dt1);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            int num_rs = dt1.Rows.Count;

            string kq = "";

            if (num_rs > 0)  //so duong dong >0
            {
                //tim vai tro nguoi vo ..chong
                kq = "("+dt1.Rows[0][0].ToString() + ":"+ dt1.Rows[0][1].ToString()+")";
            }
             
            return kq;
        }
        public string recurseMenu(string ID = "0" )
        {
            string s = "<ul class='nested'>";
            foreach (DataRow row in dt.Rows)
            {
                if (row["id_partner"].ToString() == ID)
                { if (!row["name"].ToString().Trim().Equals(null))
                    {
                        String vo = findrelated(row["id"].ToString());
                    s += "<li><span class='caret'>" + row["name"].ToString().Trim() + vo +"</span>";
                    }           
                    if (row["id"].ToString() != "0")
                    {
                     s +=  recurseMenu(row["id"].ToString().Trim());
                    }
                    s += "</li> ";
                }
            }
            return s += "</ul>";
        }
    }
}