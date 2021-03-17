using Ingeniux.CMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace WorkflowDemo.Models
{
    [Export(typeof(ICMSCustomApplicationModel))]
    [ExportMetadata("model", "WorkflowDemo")]
    public class CustomWorkflowModel
    {
        public string UserName { get; set; }
        public string PageName { get; set; }
        public string BaseUrl { get; set; }

        public bool HasSEOTitle { get; set; }
        public bool HasSEODescription { get; set; }
        public bool HasSEOKeywords { get; set; }

    }
}