using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone
{
    public partial class userLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //if the usage is invalid lets the user know it was
            if (Session["InvalidUsage"] != null)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = Session["InvalidUsage"].ToString();
            }
            //if user logs out, lets them know it was successful
            if (Request.QueryString.Get("logout") == "true")
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "User logged out successfully!";
            }
            // connect to database to retrieve stored password string
            try
            {
                System.Data.SqlClient.SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());
                lblStatus.Text = "Database Connection Successful";

                sc.Open();
                System.Data.SqlClient.SqlCommand findPass = new System.Data.SqlClient.SqlCommand();
                findPass.Connection = sc;
                // SELECT PASSWORD STRING WHERE THE ENTERED USERNAME MATCHES
                //findPass.CommandText = "SELECT PasswordHash FROM Pass WHERE Username = @Username";
                //findPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
                findPass.CommandType = CommandType.StoredProcedure;
                findPass.CommandText = "sp_loginQuery";
                findPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
                SqlDataReader reader = findPass.ExecuteReader(); // create a reader

                if (reader.HasRows) // if the username exists, it will continue
                {
                    while (reader.Read()) // this will read the single record that matches the entered username
                    {
                        string storedHash = reader["PasswordHash"].ToString(); // store the database password into this variable

                        if (PasswordHash.ValidatePassword(txtPassword.Text, storedHash)) // if the entered password matches what is stored, it will show success
                        {
                            lblStatus.ForeColor = Color.Green;
                            lblStatus.Text = "Success!";
                            btnLogin.Enabled = false;
                            Session["UserName"] = txtUsername.Text;
                            txtUsername.Enabled = false;
                            txtPassword.Enabled = false;
                        }
                        else
                            lblStatus.Text = "Password is wrong.";
                    }
                }
                else // if the username doesn't exist, it will show failure
                    lblStatus.Text = "Login failed.";

                sc.Close();
            }
            catch
            {
                lblStatus.Text = "Database Error.";
            }
        }

        protected void lnkCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("createUser.aspx", false);
        }
    }
}