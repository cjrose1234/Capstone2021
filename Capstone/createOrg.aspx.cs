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

        }

        protected void btnCommitOrg_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            string address = txtStreet + ", " + txtCity + ", " + txtState + " " + txtZip;

            string sqlQuery = "INSERT INTO Organization (orgName, orgAddress, orgEmail, orgPhoneNumber) VALUES " +
                "(@orgName, @orgAddress, @orgEmail, @orgPhoneNumber)";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);

            sqlCon.Open();
            cmd.Parameters.Add(new SqlParameter("@orgName", HttpUtility.HtmlEncode(txtOrgName.Text)));
            cmd.Parameters.Add(new SqlParameter("@orgAddress", HttpUtility.HtmlEncode(address)));
            cmd.Parameters.Add(new SqlParameter("@orgEmail", HttpUtility.HtmlEncode(txtEmail.Text)));
            cmd.Parameters.Add(new SqlParameter("@orgPhone", HttpUtility.HtmlEncode(txtPhone.Text)));
            cmd.ExecuteNonQuery();

            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Success!";

            sqlCon.Close();

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