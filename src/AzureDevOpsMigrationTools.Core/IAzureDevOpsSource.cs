using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;

namespace AzureDevOpsMigrationTools.Core
{
    interface IAzureDevOpsSource
    {
        List<WorkItem> GetWorkItems();
    }
}
