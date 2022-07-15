using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortFolio
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                litAnniPersona.Text = CalcolaEtaPersona();
                litAnniLavoro.Text = CalcolaAnniLavoro();
            }
        }

        public string CalcolaEtaPersona()
        {
            var compleanno = new DateTime(1992, 1, 18);

            // Save today's date.
            var oggi = DateTime.Today;

            // Calculate the age.
            var anni = oggi.Year - compleanno.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (compleanno.Date > oggi.AddYears(-anni)) anni--;

            return anni.ToString();
        }

        public string CalcolaAnniLavoro()
        {
            //var inizio = new DateTime(2021, 1, 30);

            //// Save today's date.
            //var oggi = DateTime.Today;

            //// Calculate the age.
            //var anni = oggi - inizio;

            //DateTime resultDate = DateTime.MinValue + anni;

            //return resultDate;

            DateTime zeroTime = new DateTime(1, 1, 1);
            DateTime olddate = new DateTime(2021, 01, 01);

            DateTime curdate = DateTime.Now.ToLocalTime();
            
            TimeSpan span = curdate - olddate;

            // because we start at year 1 for the Gregorian 
            // calendar, we must subtract a year here.

            int anni = (zeroTime + span).Year - 1;
            int mesi = (zeroTime + span).Month - 1;
            int giorni = (zeroTime + span).Day;

            return anni + " anni, " + mesi + " mesi e " + giorni + "giorni ";
        }
    }
}