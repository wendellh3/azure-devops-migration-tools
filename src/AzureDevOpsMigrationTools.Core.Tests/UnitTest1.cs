using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using AzureDevOpsMigrationTools.Core;

namespace AzureDevOpsMigrationTools.Core.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MyTestClass
    {

        [TestMethod]
        public void TestConnect()
        {
            Uri organisationUrl = new Uri("https://dev.azure.com/nkdagility-preview");
            string projectName = "TestProject1";
            //Prompt user for credential
            string personalAccessToken = "msiqtdbl3yh7pscriirylkd7rahq36lvqu5gg554buv5pddtmhpq"; // Token is public and only has access to work items in one specific test account.

            IAzureDevOpsSource azureDevOpsSource = new AzureDevOpsSource(organisationUrl, personalAccessToken, projectName);

          WorkItemQueryResult  queryResults = azureDevOpsSource.GetWorkItemsByQuery("");


            Assert.IsNotNull(queryResults);
            Assert.AreNotEqual(0, queryResults.WorkItems.Count());

        }

    }
}
