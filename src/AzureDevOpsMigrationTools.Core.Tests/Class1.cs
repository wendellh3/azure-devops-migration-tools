using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AzureDevOpsMigrationTools.Core.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MyTestClass
    {

        [TestMethod]
        public void TestConnect()
        {
            Uri orgUrl = new Uri("https://dev.azure.com/nkdagility-preview");
            //Prompt user for credential
            string personalAccessToken = "msiqtdbl3yh7pscriirylkd7rahq36lvqu5gg554buv5pddtmhpq"; // Token is public and only has access to work items in one specific test account.
            // Create a connection
            VssCredentials credentials = new VssBasicCredential("", personalAccessToken);
            VssConnection connection = new VssConnection(orgUrl, credentials);

            //create http client and query for resutls
            WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();

            Wiql query = new Wiql() { Query = "SELECT [Id], [Title], [State] FROM workitems" };

            WorkItemQueryResult queryResults = witClient.QueryByWiqlAsync(query).Result;

       


            Assert.IsNotNull(queryResults);
            Assert.AreNotEqual(0, queryResults.WorkItems.Count());

        }

    }
}
