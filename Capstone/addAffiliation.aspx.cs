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

        }
    }
}