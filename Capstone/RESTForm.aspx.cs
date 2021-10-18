using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http; // NuGet WebAPI
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json; // NuGet New Package
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone
{
    public partial class RESTForm : System.Web.UI.Page
    {

        HttpClient hClient = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Session["InvalidUsage"] = "You must be logged in to view that site!";

                Response.Redirect("userLogin.aspx");
            }
            // Some helpful URLs:

            // https://code-maze.com/different-ways-consume-restful-api-csharp/
            // https://code-maze.com/introduction-system-text-json-examples/

            // Populate the DropDownBox with the list of Analyses for the User indicated in the 
            // REST parameter.

            // =====================UNTESTED===========================
            // =====================UNTESTED===========================
            // Making POST Requests using the HttpClient Class.
            // You would NOT have this code in this location in this method.
            //  Better to place POST code like this in its own method that can
            //  use the async status (research this in the documentation links
            //  I've given you in the PowerPoint

            //HttpClient hClient = new HttpClient();

            //HttpContent postContent = 
            //    new StringContent("uid=mitrimx@jmu.edu&extractrequesttime=2021-08-17 20:53:16&request=setsentencedtails-3-token-5-blue",
            //    Encoding.UTF8, "text/html");

            //HttpRequestMessage request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri("http://saworker.storyanalyzer.org/saresults.php"),
            //    Content = postContent
            //};

            //var postResponse = hClient.SendAsync(request);
            // =====================UNTESTED===========================
            // =====================UNTESTED===========================

            if (!IsPostBack)
            {
                //establish connection
                SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString.ToString());

                //set username to logged in user and a query to find the emailAddress of the logged in user
                string email = "";
                string username = Session["UserName"].ToString();
                string sqlQuery = "SELECT emailAddress FROM Users WHERE username = '" + username + "'";

                //while loop runs through database and sets email variable to the email of the logged in user
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
                sqlCon.Open();
                SqlDataReader results = cmd.ExecuteReader();
                while (results.Read())
                {
                    email = results["emailAddress"].ToString();
                }
                sqlCon.Close();

                // Format the URL. We will use the SA API command "listsaextracts" to see all extracts
                //  under this particular user.
                //from the above reader, takes the email of the logged in user and puts it into the REST query
                String URL = "http://saworker.storyanalyzer.org/saresults.php?uid=" + email + "&request=listsaextracts";

                // Issue a GET request and get the results from the server.
                var response = hClient.GetStringAsync(new Uri(URL)).Result;

                // Parse the results into a JSONDocument. This formats the returned data into a traditional
                // JSON structure that can be traversed (walked).
                var jsondata = JsonDocument.Parse(response);

                // Clear out the list (just housekeeping)
                ddlSAList.Items.Clear();

                // for each root element in the JSON array, extract it,
                //  get the properties of each (like columns from a SELECT query)
                //  and display in the DDL.
                foreach (var item in jsondata.RootElement.EnumerateArray())
                {
                    var text = item.GetProperty("userid").GetString()
                        + " " + item.GetProperty("extractrequestdate").GetString();

                    var value = "uid=" + item.GetProperty("userid").GetString()
                        + "&extractrequesttime=" + item.GetProperty("extractrequestdate").GetString();

                    ddlSAList.Items.Add(new ListItem(text, value));

                }

            }
        }

        protected void btnMakeRequest_Click(object sender, EventArgs e)
        {
            // Use the selected command from Dr. Mitri's SA REST API
            // to retrieve results from the SA Server.

            String URL = "http://saworker.storyanalyzer.org/saresults.php?"
                + ddlSAList.SelectedValue.ToString()
                + "&request="
                + ddlRequest.SelectedItem.ToString();

            // Issue the GET command to the SA Server and get the response.
            var response = hClient.GetStringAsync(new Uri(URL)).Result;


            // The response could be plain text for some API commands
            //  or it could be HTML (to show a visualization)
            if (ddlRequest.SelectedIndex >= 0 && ddlRequest.SelectedIndex <= 3)
            {
                // The result is plain text: A URL for the source for example or story title.
                txtDisplay.Text = response;
            }
            else if (ddlRequest.SelectedItem.ToString().Equals("showbootstrapdashboard"))
            {
                // Here the user has selected to show the bootstrap dashboard.
                // We will open the URL for the dashboard in a new tab.
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + URL + "','_newtab');", true);
                //Response.Redirect(URL);
            }
            else
            {
                // The results are HRML for a visualization. I'll replace the contents
                // of a DIV on the ASP.net form with the results
                // This will dynamically update the HTML page.
                displayViz.InnerHtml = response;
            }
        }
    }
}