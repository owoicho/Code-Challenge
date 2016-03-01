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
using System.Data;


namespace CodeChallenge
{
    public partial class TempRange : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString();

            if (!this.IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string maxvalue = txtmax.Text;
            string minvalue = txtmin.Text;



            if (minvalue != string.Empty || maxvalue != string.Empty)
            {


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string result = "Select City from WeatherInfo where  Temp Between @minValue AND @maxValue";
                    SqlCommand cmd = new SqlCommand(result, conn);

                    cmd.Parameters.AddWithValue("@minValue", minvalue);

                    cmd.Parameters.AddWithValue("@maxValue", maxvalue);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string City = dr["City"].ToString();
                        lbldisplay.Text += City + " ";

                    }
                    conn.Close();
                }
            }

            else
            {
                lblerr.Text = "Error getting City Names. ";
            }


        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            txtmax.Text = string.Empty;
            txtmin.Text = string.Empty;
            lbldisplay.Text = string.Empty;
        }
    }

}