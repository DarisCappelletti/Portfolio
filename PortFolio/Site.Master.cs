using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortFolio
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (url.Contains("Gff3Reader"))
            {
                ulHomepage.Visible = false;
                ulProgetti.Visible = true;
            }
            else
            {
                ulHomepage.Visible = true;
                ulProgetti.Visible = false;
            }
        }
    }
}