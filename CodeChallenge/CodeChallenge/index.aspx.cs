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
    public partial class index : System.Web.UI.Page
    {
        //Connects to your database 
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString();

            if (!this.IsPostBack)
            {
                FillCountry();
            }
        }

        //this fills your listbox with data pull from server 
        private void FillCountry()
        {
            ListBox1.Items.Clear();
            string Sql = "Select Country,AVG(Temp) as Temp from WeatherInfo Group by Country, Temp";
            //Sql += "WHERE Country IN('" + ListBox1.SelectedItem.Text + "') Group by Country";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(Sql, con);
            SqlDataReader reader;


            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["Country"].ToString();
                    newItem.Value = reader["Temp"].ToString();
                    ListBox1.Items.Add(newItem);
                    ListBox1.SelectionMode = ListSelectionMode.Multiple;
                }
                reader.Close();
            }
            catch (Exception err)
            {
                lblResults.Text = "Error reading list of names. ";
                lblResults.Text += err.Message;
            }
            finally
            {
                con.Close();
            }
        }

        //protected void lstCountry_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string selectSQL;
        //    selectSQL = "SELECT AVG(Temp) FROM WeatheInfo ";
        //    selectSQL += "WHERE Country IN('" + ListBox1.SelectedItem.Text + "'";

        //    SqlConnection con = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand(selectSQL, con);
        //    SqlDataReader reader;



        //    try
        //    {
        //        con.Open();
        //        reader = cmd.ExecuteReader();
        //        reader.Read();

        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("<b>");
        //        sb.Append(reader["Country"]);
        //        sb.Append(", ");
        //        lblResults.Text = sb.ToString();

        //        reader.Close();
        //    }
        //    catch (Exception err)
        //    {
        //        //lblResults.Text = "Error getting Country. ";
        //        //lblResults.Text += err.Message;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //}

        //when button clickked it will display your values 
        protected void Button1_Click(object sender, EventArgs e)
        {

            Label1.Text = "";

            for (int i = 0; i < ListBox1.Items.Count; i++)
                if (ListBox1.Items[i].Selected)
                    Label1.Text += "Selected Average: " + ListBox1.Items[i].Value + " Selected Countries: " + ListBox1.Items[i].Text + "<br/>";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            lblResults.Text = string.Empty;
            Label1.Text = string.Empty;
        }
    }
}