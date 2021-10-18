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
    public partial class addAffiliation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //sends user back to login page if no user is logged in
            if (Session["UserName"] == null)
            {
                Session["InvalidUsage"] = "You must be logged in to view that site!";

                Response.Redirect("userLogin.aspx");
            }
            if (!IsPostBack) {

                //establish connection to database
                SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString.ToString());

                string sqlQuery = "SELECT orgName, orgID FROM Organization";

                SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);

                sqlCon.Open();

                lstOrganizations.Items.Clear();

                SqlDataReader results = cmd.ExecuteReader();
                while ( results.Read() )
                {
                    lstOrganizations.Items.Add(new ListItem(results["orgName"].ToString(), results["orgID"].ToString()));
                }
                sqlCon.Close();
            }
        }

        protected void btnJoinOrg_Click(object sender, EventArgs e)
        {
            //establish connection to database
            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString.ToString());

            string username = Session["UserName"].ToString();
            string orgIDvar = lstOrganizations.SelectedValue.ToString();

            //insert query to add an affiliation between the creating user and the created organization
            string sqlAffiliation = "INSERT INTO Affiliation (userID, orgID, beginDate, endDate, affiliationActive) VALUES " +
                "(@userID, @orgID, @beginDate, @endDate, @active)";

            //queries to get userID and orgID for the affiliation
            string sqlSelectUser = "SELECT userID FROM Users WHERE username = '" + username + "'";
            string sqlSelectOrg = "SELECT orgID FROM Organization WHERE orgID = '" + orgIDvar + "'";

            sqlCon.Open();

            //sets userID and orgID to variables
            SqlCommand getID = new SqlCommand(sqlSelectUser, sqlCon);
            int userID = Convert.ToInt32(getID.ExecuteScalar());
            SqlCommand getOrg = new SqlCommand(sqlSelectOrg, sqlCon);
            int orgID = Convert.ToInt32(getOrg.ExecuteScalar());

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


        }
    }
}