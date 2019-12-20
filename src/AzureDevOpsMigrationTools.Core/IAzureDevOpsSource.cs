using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;

namespace AzureDevOpsMigrationTools.Core
{
    public interface IAzureDevOpsSource
    {
       public WorkItemQueryResult GetWorkItemsByQuery(string queryBit);
    }
}
