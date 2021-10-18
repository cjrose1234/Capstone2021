using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone
{
    /// <summary>
    /// Cooper Rosenberg
    /// 9/27/2021
    /// This is the code behind for the User edit page
    /// </summary>
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if user is not logged in, sents back to login page else lets them know they are logged in
            if (Session["UserName"] == null)
            {
                Session["InvalidUsage"] = "You must be logged in to view that site!";

                Response.Redirect("userLogin.aspx");
            }
            else
            {
                lblUserStatus.Text = Session["UserName"].ToString() + " logged in";

            }
            if (!IsPostBack)
            {
                string username = Session["UserName"].ToString();

                //query to find all users with the username
                string sqlQuery = "SELECT * FROM Users WHERE username = '" + username + "'";
                SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString.ToString());

                SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);

                //datareader reads the database and sets the textboxes equal to the users information
                sqlCon.Open();
                SqlDataReader profileReader = cmd.ExecuteReader();
                while (profileReader.Read())
                {
                    txtFirstName.Text = profileReader["firstName"].ToString();
                    txtLastName.Text = profileReader["lastName"].ToString();
                    txtEmailAddress.Text = profileReader["emailAddress"].ToString();
                    txtPhoneNumber.Text = profileReader["phoneNumber"].ToString();
                    txtAddress.Text = profileReader["mailingAddress"].ToString();
                    txtPurpose.Text = profileReader["purposeOfUse"].ToString();
                }
                sqlCon.Close();
            }

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            //abandons the session and redirects back to the login page with parameters to let you know logout successful
            Session.Abandon();

            Response.Redirect("userLogin.aspx?logout=true");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            //sets variables to the text
            string firstName = HttpUtility.HtmlEncode(txtFirstName.Text);
            string lastName = HttpUtility.HtmlEncode(txtLastName.Text);
            string emailAddress = HttpUtility.HtmlEncode(txtEmailAddress.Text);
            string phoneNumber = HttpUtility.HtmlEncode(txtPhoneNumber.Text);
            string mailingAddress = HttpUtility.HtmlEncode(txtAddress.Text);
            string purpose = HttpUtility.HtmlEncode(txtPurpose.Text);
            string username = Session["UserName"].ToString();

            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString.ToString());
            SqlConnection sqlAuth = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());
            //query to update the users information with the new info
            //string sqlQuery = "UPDATE Users SET firstName = '" + firstName + "', lastName = '" + lastName + "', emailAddress = '" +
            //    emailAddress + "', phoneNumber = '" + phoneNumber + "', mailingAddress = '" + mailingAddress + "', purposeOfUse = '" + purpose +
            //    "' WHERE username = '" + username + "';";

            string sqlQuery = "UPDATE Users SET firstName = @firstName, lastName = @lastName, emailAddress = @emailAddress, phoneNumber = @phoneNumber, " +
                "mailingAddress = @mailingAddress, purposeOfUse = @purposeOfUse WHERE username = '" + username + "';";


            //open connection, run query, close connection
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
            cmd.Parameters.Add(new SqlParameter("@firstName", firstName));
            cmd.Parameters.Add(new SqlParameter("@lastName", lastName));
            cmd.Parameters.Add(new SqlParameter("@emailAddress", emailAddress));
            cmd.Parameters.Add(new SqlParameter("@phoneNumber", phoneNumber));
            cmd.Parameters.Add(new SqlParameter("@mailingAddress", mailingAddress));
            cmd.Parameters.Add(new SqlParameter("@purposeOfUse", purpose));
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            string authQuery = "UPDATE Person SET FirstName = @firstName, LastName = @lastName WHERE Username = '" + username + "';";

            sqlAuth.Open();
            SqlCommand cmdAuth = new SqlCommand(authQuery, sqlAuth);
            cmdAuth.Parameters.Add(new SqlParameter("@firstName", firstName));
            cmdAuth.Parameters.Add(new SqlParameter("@lastName", lastName));
            cmdAuth.ExecuteNonQuery();
            sqlAuth.Close();

            //let user know the edit was a success
            lblEditComplete.Text = "Edit Successful!";
            lblEditComplete.ForeColor = Color.Green;
        }
    }
}