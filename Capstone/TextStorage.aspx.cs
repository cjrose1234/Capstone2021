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
    /// This is the code behind for the text storage page page
    /// </summary>
    public partial class TextStorage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //sends user back to login page if no user is logged in
            if (Session["UserName"] == null)
            {
                Session["InvalidUsage"] = "You must be logged in to view that site!";

                Response.Redirect("userLogin.aspx");
            }
            if (!IsPostBack)
            {
                //establish connection
                SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

                //query and command to get text title and text ID to put in the drop down list
                string sqlQuery = "SELECT T.textTitle, T.textID FROM Texts T, Users U WHERE T.userID = U.userID AND U.username = '" +
                    Session["UserName"].ToString() + "'";
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);

                //runs through data and adds items to the drop down list
                sqlCon.Open();
                SqlDataReader results = cmd.ExecuteReader();
                while (results.Read())
                {
                    lstManageTexts.Items.Add(new ListItem(results["textTitle"].ToString(), results["textID"].ToString()));
                }
                sqlCon.Close();
            }
        }

        protected void btnPopulateText_Click(object sender, EventArgs e)
        {
            //fill text boxes with test text
            txtBoxTextTitle.Text = "Dune";
            txtBoxTextSource.Text = "Franklin Patrick Herbert";
            txtBoxTextBody.Text = "In the year 10191, a spice called melange is the most valuable substance known in the universe, and its only source is the desert planet Arrakis. A royal decree awards Arrakis to Duke Leto Atreides and ousts his bitter enemies, the Harkonnens. However, when the Harkonnens violently seize back their fiefdom, it is up to Paul, Letos son, to lead the Fremen, the natives of Arrakis, in a battle for control of the planet and its spice.";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

            //clears all text boxes by setting to blank
            txtBoxTextTitle.Text = "";
            txtBoxTextSource.Text = "";
            txtBoxTextBody.Text = "";
        }

        protected void txtTitleUniqueValidate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //sets title variable to current text in text box
            string title = txtBoxTextTitle.Text;
            //query to find a text with the same title
            string sqlQuery = "SELECT textTitle FROM Texts WHERE textTitle = '" + title + "'";
            string result;
            //establish connection
            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            //command and open connection
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
            sqlCon.Open();
            //if the query returns nothing, then set result to blank which a title could never be cause of requiredfieldvalidator
            //else set the result to the title
            if (Convert.ToString(cmd.ExecuteScalar()) == null)
            {
                result = "";
            }
            else
            {
                result = Convert.ToString(cmd.ExecuteScalar());
            }
            sqlCon.Close();
            //if the result is equal to the title in the text box, set isValid to false
            if (result == title)
            {
                args.IsValid = false;
            }
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            //Put text into variables and get the selected value which is the textID
            string textTitle = HttpUtility.HtmlEncode(txtBoxTextTitle.Text);
            string textSource = HttpUtility.HtmlEncode(txtBoxTextSource.Text);
            string textBody = HttpUtility.HtmlEncode(txtBoxTextBody.Text);
            string textID = lstManageTexts.SelectedValue;

            //establish connection
            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            //updates the text
            //string sqlQuery = "UPDATE Texts SET textTitle='" + textTitle + "', textSource = '" + textSource + "', textBody = '" +
            //    textBody + "' WHERE textID = '" + textID + "'";
            string sqlQuery = "UPDATE Texts SET textTitle = @textTitle, textSource = @textSource, textBody = @textBody WHERE " +
                "textID = '" + textID + "'";

            //open connection and execute the command
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
            cmd.Parameters.Add(new SqlParameter("@textTitle", textTitle));
            cmd.Parameters.Add(new SqlParameter("@textSource", textSource));
            cmd.Parameters.Add(new SqlParameter("@textBody", textBody));
            cmd.ExecuteNonQuery();

            //clears list and repopulates it with updated info
            lstManageTexts.Items.Clear();

            string sqlUpdateListQuery = "SELECT T.textTitle, T.textID FROM Texts T, Users U WHERE T.userID = U.userID AND U.username = '" +
                    Session["UserName"].ToString() + "'";
            SqlCommand updateCmd = new SqlCommand(sqlUpdateListQuery, sqlCon);

            SqlDataReader results = updateCmd.ExecuteReader();
            while (results.Read())
            {
                lstManageTexts.Items.Add(new ListItem(results["textTitle"].ToString(), results["textID"].ToString()));
            }
            sqlCon.Close();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //establish connection
            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            //put text into variables for ease later and get the user logged in
            string title = HttpUtility.HtmlEncode(txtBoxTextTitle.Text);
            string source = HttpUtility.HtmlEncode(txtBoxTextSource.Text);
            string body = HttpUtility.HtmlEncode(txtBoxTextBody.Text);
            string username = Session["UserName"].ToString();

            //query to find the userID of the user logged in
            string userQuery = "SELECT userID FROM Users WHERE username = '" + username + "'";

            SqlCommand getID = new SqlCommand(userQuery, sqlCon);
            //only can happen if validator isValid
            if (IsValid)
            {
                //open connection
                sqlCon.Open();
                //set the userID 
                int userID = Convert.ToInt32(getID.ExecuteScalar());

                //Inserts all the values into the database
                string sqlQuery = "INSERT INTO Texts values(@textTitle,@textSource,@textBody,@userID)";
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
                cmd.Parameters.AddWithValue("@textTitle", title);
                cmd.Parameters.AddWithValue("@textSource", source);
                cmd.Parameters.AddWithValue("@textBody", body);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.ExecuteNonQuery();

                //clears and updates the drop down list with current data
                lstManageTexts.Items.Clear();

                string sqlUpdateListQuery = "SELECT T.textTitle, T.textID FROM Texts T, Users U WHERE T.userID = U.userID AND U.username = '" +
                        Session["UserName"].ToString() + "'";
                SqlCommand updateCmd = new SqlCommand(sqlUpdateListQuery, sqlCon);

                SqlDataReader results = updateCmd.ExecuteReader();
                while (results.Read())
                {
                    lstManageTexts.Items.Add(new ListItem(results["textTitle"].ToString(), results["textID"].ToString()));
                }

                sqlCon.Close();
            }


        }

        protected void btnEditText_Click(object sender, EventArgs e)
        {
            //establish connection
            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            //query to get the text title, source and body
            string sqlQuery = "SELECT textTitle, textSource, textBody FROM Texts WHERE textTitle = '" +
                lstManageTexts.SelectedItem.ToString() + "'";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
            //reads through the database and whatever text has that title it fills the textboxes with it's information
            sqlCon.Open();
            SqlDataReader results = cmd.ExecuteReader();
            while (results.Read())
            {
                txtBoxTextTitle.Text = results["textTitle"].ToString();
                txtBoxTextSource.Text = results["textSource"].ToString();
                txtBoxTextBody.Text = results["textBody"].ToString();
            }
            sqlCon.Close();

        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            //set filepath
            string filePath = Request.PhysicalApplicationPath + "textfiles\\" + fileUploadText.FileName;

            //saves the file into the site
            fileUploadText.SaveAs(filePath);
            lblUploadSuccess.Text = "Success";
            lblUploadSuccess.ForeColor = Color.Green;

            //if the File exists, reads all the text into the textbody and then deletes the file, else warns user something went wrong.
            if (File.Exists(filePath))
            {
                string fileText = File.ReadAllText(filePath);
                txtBoxTextBody.Text = fileText;
                File.Delete(filePath);

            }
            else
            {
                lblUploadSuccess.Text = "Something went wrong!";
                lblUploadSuccess.ForeColor = Color.Red;
            }
        }
    }
}