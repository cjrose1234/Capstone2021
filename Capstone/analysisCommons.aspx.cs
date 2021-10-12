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
    public partial class analysisCommons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //make sure a user is logged in
            if (Session["UserName"] == null)
            {
                Session["InvalidUsage"] = "You must be logged in to view that site!";

                Response.Redirect("userLogin.aspx");
            }
            //on page load, finds the people the logged in user is already friends with and fills the listbox with their information
            if (!IsPostBack)
            {
                SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                string username = Session["UserName"].ToString();

                lstFriends.Items.Clear();

                string friendsQuery = "SELECT U.emailAddress, U.lastName, U.firstName, F.relatedUserID FROM Users U, UserFriends F WHERE " +
                "U.userID = F.relatedUserID";
                SqlCommand friends = new SqlCommand(friendsQuery, sqlCon);
                sqlCon.Open();
                SqlDataReader results = friends.ExecuteReader();
                while (results.Read())
                {
                    lstFriends.Items.Add(new ListItem(results["lastName"].ToString() + ", " + results["firstName"].ToString() + ": " +
                        results["emailAddress"].ToString(), results["relatedUserID"].ToString()));
                }
                sqlCon.Close();
            }
        }

        protected void btnSearchForUser_Click(object sender, EventArgs e)
        {
            //establish database connection
            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            //protects against CSS attacks
            string email = HttpUtility.HtmlEncode(txtSearchForUser.Text);

            //query to list out the name and email of a user with a similar email to the one searched for
            string sqlQuery = "SELECT emailAddress, lastName, firstName, userID FROM Users WHERE emailAddress LIKE '" + email + "'";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);

            //clears the listbox
            lstUsers.Items.Clear();

            //fills the list box with the users that match the search
            sqlCon.Open();
            SqlDataReader results = cmd.ExecuteReader();
            while (results.Read())
            {
                lstUsers.Items.Add(new ListItem(results["lastName"].ToString() + ", " + results["firstName"].ToString() + ": " +
                    results["emailAddress"].ToString(), results["userID"].ToString()));
            }
            sqlCon.Close();

        }

        protected void btnFriendUser_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            string username = Session["UserName"].ToString();

            //query to find the userID of the user logged in
            string userQuery = "SELECT userID FROM Users WHERE username = '" + username + "'";

            SqlCommand getID = new SqlCommand(userQuery, sqlCon);
            sqlCon.Open();
            //set the userID 
            int userID = Convert.ToInt32(getID.ExecuteScalar());
            sqlCon.Close();

            //query to insert new friends into the database, with the user logged in as the relating user and the friend as the related user
            string sqlQuery = "INSERT INTO UserFriends VALUES(@relatingUserID, @relatedUserID)";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);

            //adds the users userID into the relating user and the selected value of the users from the search they want to friend into the related user
            sqlCon.Open();
            cmd.Parameters.Add(new SqlParameter("@relatingUserID", userID));
            cmd.Parameters.Add(new SqlParameter("@relatedUserID", lstUsers.SelectedValue.ToString()));
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            //resets the listbox and fills with remaining friends
            lstFriends.Items.Clear();

            string friendsQuery = "SELECT U.emailAddress, U.lastName, U.firstName, F.relatedUserID FROM Users U, UserFriends F WHERE " +
                "U.userID = F.relatedUserID";
            SqlCommand friends = new SqlCommand(friendsQuery, sqlCon);
            sqlCon.Open();
            SqlDataReader results = friends.ExecuteReader();
            while (results.Read())
            {
                lstFriends.Items.Add(new ListItem(results["lastName"].ToString() + ", " + results["firstName"].ToString() + ": " +
                    results["emailAddress"].ToString(), results["relatedUserID"].ToString()));
            }
            sqlCon.Close();


        }

        protected void btnRemoveFriend_Click(object sender, EventArgs e)
        {
            //establish connection and set username equal to the sessions logged in user
            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            string username = Session["UserName"].ToString();

            //query to delete from the Users friends where the friends ID value is
            string sqlQuery = "DELETE FROM UserFriends WHERE relatedUserID = '" + lstFriends.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);

            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            //resets the friends table and fills it out with all the users remaining friends
            lstFriends.Items.Clear();

            string friendsQuery = "SELECT U.emailAddress, U.lastName, U.firstName, F.relatedUserID FROM Users U, UserFriends F WHERE " +
                "U.userID = F.relatedUserID";
            SqlCommand friends = new SqlCommand(friendsQuery, sqlCon);
            sqlCon.Open();
            SqlDataReader results = friends.ExecuteReader();
            while (results.Read())
            {
                lstFriends.Items.Add(new ListItem(results["lastName"].ToString() + ", " + results["firstName"].ToString() + ": " +
                    results["emailAddress"].ToString(), results["relatedUserID"].ToString()));
            }
            sqlCon.Close();
        }

        protected void btnShowAnalysis_Click(object sender, EventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            //query to select the title and date from an analysis with the same user as the selected friends
            string sqlQuery = "SELECT T.textTitle, A.analysisDate, A.analysisID FROM Texts T, Analysis A, UserFriends U WHERE " +
                "T.textID = A.textID AND T.userID = '" + lstFriends.SelectedValue.ToString() + "'";

            lstFriendAnalysis.Items.Clear();

            //reads through data and fills the friends listbox with all the analysis that friend has made
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
            sqlCon.Open();
            SqlDataReader results = cmd.ExecuteReader();
            while (results.Read())
            {
                lstFriendAnalysis.Items.Add(new ListItem(results["textTitle"].ToString() + ", " + results["analysisDate"].ToString(),
                    results["analysisID"].ToString()));
            }
            sqlCon.Close();
        }

        protected void btnShowFriendAnalysis_Click(object sender, EventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            //query to select the analysis results from the analysis with the same ID as the selected friends
            string sqlQuery = "SELECT analysisResults FROM Analysis WHERE analysisID = '" + lstFriendAnalysis.SelectedValue.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);

            sqlCon.Open();
            SqlDataReader results = cmd.ExecuteReader();
            //while the results are read, the textbox is filled with the test analysis results
            while (results.Read())
            {
                txtAnalysis.Text = results["analysisResults"].ToString();
            }
            //close connection
            sqlCon.Close();
        }
    }
}