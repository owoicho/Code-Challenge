using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeChallenge
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // hard code the admin user name and password 
            string psword = txtpass.Text;
            string username = txtuser.Text;

            if (psword != string.Empty && username != string.Empty)
            {
                String ps = "Password1";
                string usn = "Admin";

                //comparing the password before sending the admin to adminstartion webpage 
                if (username == usn && psword == ps)
                {
                    Response.Redirect("updateinfo.aspx");

                }

                else
                {
                    lbldisplay.Text = "Wrong username and Password";
                }
            }
        }


    }
}