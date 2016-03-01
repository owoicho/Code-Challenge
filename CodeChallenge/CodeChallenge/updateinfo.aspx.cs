using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Text;


namespace CodeChallenge
{
    public partial class updateinfo : System.Web.UI.Page
    {
        //Connects to your database 
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string city = txtcity.Text;
            string newtemp = txtup.Text;

            if (city != string.Empty && newtemp != string.Empty)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string result = "Update WeatherInfo set Temp =@Newtemp where City = @City";
                    SqlCommand cmd = new SqlCommand(result, conn);

                    cmd.Parameters.AddWithValue("@City", city);

                    cmd.Parameters.AddWithValue("@Newtemp", newtemp);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        //    string City = dr["City"].ToString();
                        lblerr.Text = "City temperature updated";

                    }
                    conn.Close();
                }
            }

            else
            {
                lblerr.Text = "Error Connecting to server";
            }
        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            txtcity.Text = string.Empty;
            txtup.Text = string.Empty;
        }
    }
}