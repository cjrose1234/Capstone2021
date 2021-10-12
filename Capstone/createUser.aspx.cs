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
    public partial class createUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("userLogin.aspx", false);
        }

        protected void lnkAnother_Click(object sender, EventArgs e)
        {
            //resets the textboxes to allow text and be empty
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtAddress.Enabled = true;
            txtPurpose.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            btnSubmit.Enabled = true;
            lnkAnother.Visible = false;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtPurpose.Text = "";
            txtUsername.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtPassword.Text != "" && txtUsername.Text != "") // all fields must be filled out
            {
                // COMMIT VALUES
                try
                {
                    System.Data.SqlClient.SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());
                    SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                    lblStatus.Text = "Database Connection Successful";

                    sc.Open();

                    System.Data.SqlClient.SqlCommand createUser = new System.Data.SqlClient.SqlCommand();
                    createUser.Connection = sc;
                    // INSERT USER RECORD
                    createUser.CommandText = "INSERT INTO Person (FirstName, LastName, Username) VALUES (@FName, @LName, @Username)";
                    createUser.Parameters.Add(new SqlParameter("@FName", txtFirstName.Text));
                    createUser.Parameters.Add(new SqlParameter("@LName", txtLastName.Text));
                    createUser.Parameters.Add(new SqlParameter("@Username", txtUsername.Text));
                    createUser.ExecuteNonQuery();

                    sqlCon.Open();
                    SqlCommand supplyUserTable = new SqlCommand();
                    supplyUserTable.Connection = sqlCon;
                    // INSERT USER INTO USERS TABLE
                    supplyUserTable.CommandText = "INSERT INTO Users (firstName, lastName, emailAddress, phoneNumber, mailingAddress, purposeOfUse, username)" +
                        " VALUES (@firstName, @lastName, @emailAddress, @phoneNumber, @mailingAddress, @purposeOfUse, @username)";
                    supplyUserTable.Parameters.Add(new SqlParameter("@firstName", txtFirstName.Text));
                    supplyUserTable.Parameters.Add(new SqlParameter("@lastName", txtLastName.Text));
                    supplyUserTable.Parameters.Add(new SqlParameter("@emailAddress", txtEmail.Text));
                    supplyUserTable.Parameters.Add(new SqlParameter("@phoneNumber", txtPhone.Text));
                    supplyUserTable.Parameters.Add(new SqlParameter("@mailingAddress", txtAddress.Text));
                    supplyUserTable.Parameters.Add(new SqlParameter("@purposeOfUse", txtPurpose.Text));
                    supplyUserTable.Parameters.Add(new SqlParameter("@username", txtUsername.Text));
                    supplyUserTable.ExecuteNonQuery();
                    sqlCon.Close();
                    System.Data.SqlClient.SqlCommand setPass = new System.Data.SqlClient.SqlCommand();
                    setPass.Connection = sc;
                    // INSERT PASSWORD RECORD AND CONNECT TO USER
                    setPass.CommandText = "INSERT INTO Pass (UserID, Username, PasswordHash) VALUES ((select max(userid) from person), @Username, @Password)";
                    setPass.Parameters.Add(new SqlParameter("@Username", txtUsername.Text));
                    setPass.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(txtPassword.Text))); // hash entered password
                    setPass.ExecuteNonQuery();

                    sc.Close();

                    //tells user that a new user has been committed and then makes the text boxes unable to be changed and shows the lnkAnther button
                    lblStatus.Text = "User committed!";
                    txtFirstName.Enabled = false;
                    txtLastName.Enabled = false;
                    txtEmail.Enabled = false;
                    txtPhone.Enabled = false;
                    txtAddress.Enabled = false;
                    txtPurpose.Enabled = false;
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;
                    btnSubmit.Enabled = false;
                    lnkAnother.Visible = true;
                }
                catch
                {
                    lblStatus.Text = "Database Error - User not committed.";
                }
            }
            else
                lblStatus.Text = "Fill all fields.";
        }
    }
}