using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone
{
    /// <summary>
    /// Cooper Rosenberg
    /// 9/27/2021
    /// This is the code behind for the main page
    /// </summary>
    public partial class UImainpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    lblViewUserLogin.Text = "Login";
                }
                else
                {
                    lblViewUserLogin.Text = "View User";
                }
            }
        }

        protected void btnStoreTextPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("TextStorage.aspx");
        }

        protected void btnViewAnalysisPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAnalysis.aspx");
        }

        protected void btnViewLoginPage_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("userLogin.aspx");
            }
            else
            {
                Response.Redirect("UserPage.aspx");
            }
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("createUser.aspx");
        }

        protected void btnStoryAnalysis_Click(object sender, EventArgs e)
        {
            Response.Redirect("RESTForm.aspx");
        }

        protected void btnFriendsAnalysis_Click(object sender, EventArgs e)
        {
            Response.Redirect("analysisCommons.aspx");
        }
    }
}