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
    public partial class createOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //sends user back to login page if no user is logged in
            if (Session["UserName"] == null)
            {
                Session["InvalidUsage"] = "You must be logged in to view that site!";

                Response.Redirect("userLogin.aspx");
            }
        }

        protected void btnCommitOrg_Click(object sender, EventArgs e)
        {
            //establish connection to database
            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            //variable to put all of the address data into the right format
            string address = txtStreet.Text + ", " + txtCity.Text + ", " + txtState.Text + " " + txtZip.Text;
            string username = Session["UserName"].ToString();
            string orgName = txtOrgName.Text;
            //query that inserts textbox values into the database. Parameterized
            string sqlQuery = "INSERT INTO Organization (orgName, orgAddress, orgEmail, orgPhoneNumber) VALUES " +
                "(@orgName, @orgAddress, @orgEmail, @orgPhoneNumber)";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);

            //open connection and add encoded text into the parameters
            sqlCon.Open();
            cmd.Parameters.Add(new SqlParameter("@orgName", HttpUtility.HtmlEncode(txtOrgName.Text)));
            cmd.Parameters.Add(new SqlParameter("@orgAddress", HttpUtility.HtmlEncode(address)));
            cmd.Parameters.Add(new SqlParameter("@orgEmail", HttpUtility.HtmlEncode(txtEmail.Text)));
            cmd.Parameters.Add(new SqlParameter("@orgPhoneNumber", HttpUtility.HtmlEncode(txtPhone.Text)));
            cmd.ExecuteNonQuery();

            sqlCon.Close();

            string sqlSelectUser = "SELECT userID FROM Users WHERE username = '" + username + "'";
            string sqlSelectOrg = "SELECT orgID FROM Organization WHERE orgName = '" + orgName + "'";

            sqlCon.Open();

            SqlCommand getID = new SqlCommand(sqlSelectUser, sqlCon);
            int userID = Convert.ToInt32(getID.ExecuteScalar());
            SqlCommand getOrg = new SqlCommand(sqlSelectOrg, sqlCon);
            int orgID = Convert.ToInt32(getOrg.ExecuteScalar());

            string sqlAffiliation = "INSERT INTO Affiliation (userID, orgID, beginDate, endDate, affiliationActive) VALUES " +
                "(@userID, @orgID, @beginDate, @endDate, @active)";

            SqlCommand addAffiliation = new SqlCommand(sqlAffiliation, sqlCon);
            addAffiliation.Parameters.Add(new SqlParameter("@userID", userID));
            addAffiliation.Parameters.Add(new SqlParameter("@orgID", orgID));
            addAffiliation.Parameters.Add(new SqlParameter("@beginDate", DateTime.Now));
            addAffiliation.Parameters.Add(new SqlParameter("@endDate", DBNull.Value));
            addAffiliation.Parameters.Add(new SqlParameter("@active", 1));
            addAffiliation.ExecuteNonQuery();
            sqlCon.Close();

            //adds success to let user know it worked
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Success!";

            

            //closes all text boxes and makes the create another button visible
            txtOrgName.Enabled = false;
            txtStreet.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtZip.Enabled = false;
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            btnAnother.Visible = true;
        }

        protected void btnAnother_Click(object sender, EventArgs e)
        {
            //resets all textboxes to blank and reenables them. Then makes button invisible
            txtOrgName.Text = "";
            txtStreet.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtOrgName.Enabled = true;
            txtStreet.Enabled = true;
            txtCity.Enabled = true;
            txtState.Enabled = true;
            txtZip.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            btnAnother.Visible = false;
        }
    }
}