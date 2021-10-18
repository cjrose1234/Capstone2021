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
    /// <summary>
    /// Cooper Rosenberg
    /// 9/27/2021
    /// This is the code behind for the analysis page
    /// </summary>
    public partial class ViewAnalysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if there is no logged in user, redirected to Login
            if (Session["UserName"] == null)
            {
                Session["InvalidUsage"] = "You must be logged in to view that site!";

                Response.Redirect("userLogin.aspx");
            }
            if (!IsPostBack)
            {
                //establish connection to database
                SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString.ToString());

                //first string to get the text title and id of all texts submitted by current logged in user.
                //second string to get text title, date done and the ID of analyses submitted by user.
                string sqlQuery = "SELECT T.textTitle, T.textID FROM Texts T, Users U WHERE T.userID = U.userID AND U.username = '" +
                    Session["UserName"].ToString() + "'";
                string completedRequest = "SELECT T.textTitle, A.analysisDate, A.analysisID FROM Texts T, Analysis A, Users U WHERE " +
                    "T.userID = U.userID AND U.username = '" + Session["UserName"].ToString() + "' AND T.textID = A.textID";
                //first command for the first query, second for the second query.
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
                SqlCommand cmd2 = new SqlCommand(completedRequest, sqlCon);

                //open connection
                sqlCon.Open();
                //start data reader
                SqlDataReader results = cmd.ExecuteReader();
                //while results are being read it adds to the drop down list the title of the users texts and a value of the text ID
                while (results.Read())
                {
                    lstManageTexts.Items.Add(new ListItem(results["textTitle"].ToString(), results["textID"].ToString()));
                }
                sqlCon.Close();
                sqlCon.Open();
                SqlDataReader results2 = cmd2.ExecuteReader();
                //while results from second query are read, it adds to the listbox a string of the texts title and the date analyzed
                //and a value of the ID of the analysis
                while (results2.Read())
                {
                    lstCompletedRequests.Items.Add(new ListItem(results2["textTitle"].ToString() + ", " + results2["analysisDate"].ToString(),
                        results2["analysisID"].ToString()));
                }
                //close connection
                sqlCon.Close();
            }
        }

        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            //establish connection
            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString.ToString());
            //get the current date
            DateTime myDateTime = DateTime.Now;
            //query to insert the values into the database
            string sqlQuery = "INSERT INTO Analysis values(@analysisDescription,@analysisDate,@analysisResults,@textID)";

            //command adds the proper parameters with the test results and the text ID being that of the selected text from list
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
            sqlCon.Open();
            cmd.Parameters.AddWithValue("@analysisDescription", "test");
            cmd.Parameters.AddWithValue("@analysisDate", myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("@analysisResults", "test results");
            cmd.Parameters.AddWithValue("@textID", lstManageTexts.SelectedValue.ToString());
            //insert statement executed
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            //this code below is all to repopulate the completed requests list with the new analysis just created
            string completedRequest = "SELECT T.textTitle, A.analysisDate, A.analysisID FROM Texts T, Analysis A, Users U WHERE " +
                    "T.userID = U.userID AND U.username = '" + Session["UserName"].ToString() + "' AND T.textID = A.textID";
            SqlCommand cmd2 = new SqlCommand(completedRequest, sqlCon);

            lstCompletedRequests.Items.Clear();

            sqlCon.Open();
            SqlDataReader results2 = cmd2.ExecuteReader();
            while (results2.Read())
            {
                lstCompletedRequests.Items.Add(new ListItem(results2["textTitle"].ToString() + ", " + results2["analysisDate"].ToString(),
                    results2["analysisID"].ToString()));
            }
            sqlCon.Close();
        }

        protected void btnDeleteAnalysis_Click(object sender, EventArgs e)
        {
            //establish connection
            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString.ToString());

            //string to delete the analysis from the database
            string sqlDelete = "DELETE FROM Analysis WHERE analysisID = '" + lstCompletedRequests.SelectedValue.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlDelete, sqlCon);

            //open connection, execute the delete statement and then close the connection
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            //this code below is all to repopulate the completed requests list with the new analysis just created
            string completedRequest = "SELECT T.textTitle, A.analysisDate, A.analysisID FROM Texts T, Analysis A, Users U WHERE " +
                    "T.userID = U.userID AND U.username = '" + Session["UserName"].ToString() + "' AND T.textID = A.textID";
            SqlCommand cmd2 = new SqlCommand(completedRequest, sqlCon);

            lstCompletedRequests.Items.Clear();

            sqlCon.Open();
            SqlDataReader results2 = cmd2.ExecuteReader();
            while (results2.Read())
            {
                lstCompletedRequests.Items.Add(new ListItem(results2["textTitle"].ToString() + ", " + results2["analysisDate"].ToString(),
                    results2["analysisID"].ToString()));
            }
            sqlCon.Close();
        }

        protected void btnShowResults_Click(object sender, EventArgs e)
        {
            //establish connection
            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString.ToString());

            //query to get the test results from the analysis with the same analysis ID as the selected value in the listbox
            string sqlQuery = "SELECT analysisResults FROM Analysis WHERE analysisID = '" +
                lstCompletedRequests.SelectedValue.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);

            //open connection
            sqlCon.Open();
            //execute reader
            SqlDataReader results = cmd.ExecuteReader();
            //while the results are read, the textbox is filled with the test analysis results
            while (results.Read())
            {
                txtResults.Text = results["analysisResults"].ToString();
            }
            //close connection
            sqlCon.Close();
        }
    }
}