using PortFolio.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            string strAnni = anni > 1 ? anni + " anni, " : anni + " anno, ";
            string strMesi = mesi > 1 ? mesi + " mesi e " : mesi + " mese e ";
            string strGiorni = giorni > 1 ? giorni + " giorni " : giorni + " giorni ";

            return strAnni + strMesi + strGiorni;
        }

        protected bool inviaEmail()
        {
            try
            {
                // Invio la mail al creatore dell'evento e alle trasmissioni del terzo livello
                //var tipoEvento =
                //    evento.TipoEvento.Codice == "disattivazione" && evento.DataFine != null && evento.DataEffettivaFine != null
                //    ? "Riattivazione"
                //    : evento.TipoEvento.Nome;
                //var creatore = evento.Creatore;
                //var oggetto = $"Richiesta “{tipoEvento}” procedimento “{tpt.NomeSpecifico}” ({tpt.ID})";
                //var messaggio =
                //    $"Salve,<br />" +
                //    $"vi comunichiamo che la richiesta di “{tipoEvento}” del procedimento “{tpt.NomeSpecifico}” ({tpt.ID}) " +
                //    $"creata da “{creatore.Nome} {creatore.Cognome}” in data {evento.DataCreazione.ToShortDateString()} " +
                //    $"è stata effettuata correttamente.<br /><br />" +
                //    "Cordiali saluti,<br />" +
                //    "Team ProcediMarche";

                var mailFrom = ConfigurationManager.AppSettings["email.indirizzo"];
                List<string> destinatario = new List<string>();
                destinatario.Add(mailFrom);

                string messaggio = "<strong>Nominativo/Azienda:</strong> " + txtNominativo.Text + "<br>";
                messaggio += "<strong>Email:</strong> " + txtEmail.Text.Trim() + "<br><br>";
                messaggio += txtCorpo.Text;

                EmailHelper.Send(messaggio, destinatario, null, txtOggetto.Text);

                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        protected void btnInviaEmail_Click(object sender, EventArgs e)
        {
            inviaEmail();
        }
    }
}