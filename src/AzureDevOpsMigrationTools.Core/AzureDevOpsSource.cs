using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;

namespace AzureDevOpsMigrationTools.Core
{
    public class AzureDevOpsSource : IAzureDevOpsSource
    {
        private Uri organisationUrl;
        private string personalAccessToken;
        private string projectName;
        private VssCredentials credentials;
        private VssConnection connection;

        public AzureDevOpsSource(Uri organisationUrl, string personalAccessToken, string projectName)
        {
            this.organisationUrl = organisationUrl;
            this.personalAccessToken = personalAccessToken;
            this.projectName = projectName;
            credentials = new VssBasicCredential("", personalAccessToken);
            connection = new VssConnection(organisationUrl, credentials);
        }

        public WorkItemQueryResult GetWorkItemsByQuery(string queryBit)
        {
            WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();

            Wiql query = new Wiql() { Query = "SELECT [Id], [Title], [State] FROM workitems" };

            return witClient.QueryByWiqlAsync(query).Result;
        }
    }
}