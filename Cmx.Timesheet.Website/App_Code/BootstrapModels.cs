using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ASP;

namespace Cmx.Timesheet.Website.App_Code
{
    public class PanelModel
    {
        public string Title { get; set; }

        public ContextualHelper Context { get; set; }
    }

    public class BootstrapPanel : IDisposable
    {
        private readonly TextWriter _writer;
        public BootstrapPanel(ViewContext viewContext)
        {
            _writer = viewContext.Writer;
        }

        public void Dispose()
        {
            this._writer.Write("<div/>");
        }
    }

    public static class HtmlHelperExtensions
    {
        public static BootstrapPanel BeginPanel(this HtmlHelper htmlHelper, ContextualHelper context, string title)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass(string.Format("panel panel-{0}", Convert.ToString(context).ToLower()));

            var headerTagBuilder = new TagBuilder("div");
            headerTagBuilder.AddCssClass("panel-heading");

            var titleTagBuilder = new TagBuilder("span");
            titleTagBuilder.AddCssClass("panel-title");
            titleTagBuilder.SetInnerText(title);

            headerTagBuilder.InnerHtml += titleTagBuilder.ToString(TagRenderMode.Normal);
            tagBuilder.InnerHtml += headerTagBuilder.ToString(TagRenderMode.Normal);

            var bodyTagBuilder = new TagBuilder("div");
            bodyTagBuilder.AddCssClass("panel-body");
            //bodyTagBuilder.
            tagBuilder.InnerHtml += bodyTagBuilder.ToString(TagRenderMode.Normal);

            htmlHelper.ViewContext.Writer
                            .Write(tagBuilder.ToString(
                                                 TagRenderMode.Normal));
            return new BootstrapPanel(htmlHelper.ViewContext);
        }
    }
}