using Ingeniux.CMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkflowDemo.Models;

namespace WorkflowDemo.Controllers
{
    [Export(typeof(CMSControllerBase))]
    [ExportMetadata("controller", "WorkflowDemoController")]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class WorkflowDemoController : WorkflowClientApplicationController
    {
        public ActionResult Index()
        {
            var model = new CustomWorkflowModel();

            using (var session = this._ContentStore.OpenReadSession(_Common.CurrentUser))
            {
                IPage currentPage = TransitionContext.GetPage(session);
                model.UserName = session.OperatingUser.Name;
                model.PageName = currentPage.Name;
                model.BaseUrl = _Common.ServerUrl;
                model.HasSEODescription = !string.IsNullOrWhiteSpace(currentPage.Element("SEODescription")?.Value);
                model.HasSEOKeywords = !string.IsNullOrWhiteSpace(currentPage.Element("SEOKeyword")?.Value);
                model.HasSEOTitle = !string.IsNullOrWhiteSpace(currentPage.Element("SEOTitle")?.Value);
            }
            //set return value on window
            return View(model);
        }
    }
}