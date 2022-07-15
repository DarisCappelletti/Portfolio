﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortFolio
{
    public partial class reader : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<BioTizio> dati = Session["data"] as List<BioTizio>;
                if (dati != null)
                {
                    if (Session["contiene"] != null)
                    {
                        valoriContiene.Value = Session["contiene"].ToString();
                    }
                    if (Session["noncontiene"] != null)
                    {
                        valoriNonContiene.Value = Session["noncontiene"].ToString();
                    }

                    aggiornaTabella(dati);
                }
                visualizzaFileCaricato();
            }
        }

        protected void ImportCSV(object sender, EventArgs e)
        {
            //Create a DataTable.
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[10] {
            new DataColumn("File", typeof(string)),
            new DataColumn("Sequid", typeof(string)),
            new DataColumn("Source", typeof(string)),
            new DataColumn("Type", typeof(string)),
            new DataColumn("Start", typeof(string)),
            new DataColumn("End", typeof(string)),
            new DataColumn("Score", typeof(string)),
            new DataColumn("Strand", typeof(string)),
            new DataColumn("Phase", typeof(string)),
            new DataColumn("Attributes",typeof(string)) });

            var listaTizi = new List<BioTizio>();

            //Read the contents of CSV file.

            //string csvPath;
            //using (StreamReader inputStreamReader = new StreamReader(fileCaricato.PostedFile.InputStream))
            //{
            //    csvPath = inputStreamReader.ReadToEnd();
            //}

            var listaFile = new List<string>();

            if (fileCaricato.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in fileCaricato.PostedFiles)
                {
                    listaFile.Add(uploadedFile.FileName);

                    StreamReader inputStreamReader = new StreamReader(uploadedFile.InputStream);
                    string streamFile = inputStreamReader.ReadToEnd();

                    //Execute a loop over the rows.
                    foreach (string row in streamFile.Split('\n'))
                    {
                        // Se la riga non è vuota e non è un commento la aggiungo
                        if (!string.IsNullOrEmpty(row) && !row.StartsWith("#"))
                        {
                            var tizio = new BioTizio();

                            tizio.File = uploadedFile.FileName;

                            int i = 0;
                            //Execute a loop over the columns.
                            foreach (string cell in row.Split('\t'))
                            {
                                if (i == 0)
                                {
                                    tizio.Sequid = cell;
                                }
                                else if (i == 1)
                                {
                                    tizio.Source = cell;
                                }
                                else if (i == 2)
                                {
                                    tizio.Type = cell;
                                }
                                else if (i == 3)
                                {
                                    tizio.Start = cell;
                                }
                                else if (i == 4)
                                {
                                    tizio.End = cell;
                                }
                                else if (i == 5)
                                {
                                    tizio.Score = cell;
                                }
                                else if (i == 6)
                                {
                                    tizio.Strand = cell;
                                }
                                else if (i == 7)
                                {
                                    tizio.Phase = cell;
                                }
                                else if (i == 8)
                                {
                                    tizio.Attributes = cell;
                                }
                                i++;
                            }

                            listaTizi.Add(tizio);
                        }
                    }
                }
            }

            Session["nomeFile"] = listaFile;

            Session["data"] = listaTizi;

            //Bind the DataTable.
            aggiornaTabella(listaTizi);
            visualizzaFileCaricato();
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            impostaFiltri();
        }

        public void impostaFiltri()
        {
            List<BioTizio> dati = Session["data"] as List<BioTizio>;
            var contiene = valoriContiene.Value;
            var noncontiene = valoriNonContiene.Value;

            var colAttive = impostaColonneRicerca();

            IEnumerable<BioTizio> query = dati;
            //(prova as DataTable).DefaultView.RowFilter = string.Format("Attributes = '{0}'", txtRicerca.Text);
            if (contiene != "")
            {
                Session["contiene"] = contiene;
                var listaParole = contiene.Split(';');
                int conteggioParole = listaParole.Count();
                foreach (var parola in listaParole)
                {
                    query =
                        query.Where(x =>
                                colAttive.inFile && x.File.ToLower().Contains(parola.ToLower()) ||
                                colAttive.inAttributes && x.Attributes.ToLower().Contains(parola.ToLower()) ||
                                colAttive.inSequid && x.Sequid.ToLower().Contains(parola.ToLower()) ||
                                colAttive.inSource && x.Source.ToLower().Contains(parola.ToLower()) ||
                                colAttive.inType && x.Type.ToLower().Contains(parola.ToLower()) ||
                                colAttive.inStart && x.Start.ToLower().Contains(parola.ToLower()) ||
                                colAttive.inEnd && x.End.ToLower().Contains(parola.ToLower()) ||
                                colAttive.inScore && x.Score.ToLower().Contains(parola.ToLower()) ||
                                colAttive.inStrand && x.Strand.ToLower().Contains(parola.ToLower()) ||
                                colAttive.inPhase && x.Phase.ToLower().Contains(parola.ToLower())
                            );
                }
            }
            if (noncontiene.Trim() != "")
            {
                Session["noncontiene"] = noncontiene;

                var listaParole = noncontiene.Split(';');
                foreach (var parola in listaParole)
                {
                    query =
                        query.Where(x =>
                                (!colAttive.inFile || !x.File.ToLower().Contains(parola.ToLower())) &&
                                (!colAttive.inAttributes || !x.Attributes.ToLower().Contains(parola.ToLower())) &&
                                (!colAttive.inSequid || !x.Sequid.ToLower().Contains(parola.ToLower())) &&
                                (!colAttive.inSource || !x.Source.ToLower().Contains(parola.ToLower())) &&
                                (!colAttive.inType || !x.Type.ToLower().Contains(parola.ToLower())) &&
                                (!colAttive.inStart || !x.Start.ToLower().Contains(parola.ToLower())) &&
                                (!colAttive.inEnd || !x.End.ToLower().Contains(parola.ToLower())) &&
                                (!colAttive.inScore || !x.Score.ToLower().Contains(parola.ToLower())) &&
                                (!colAttive.inStrand || !x.Strand.ToLower().Contains(parola.ToLower())) &&
                                (!colAttive.inPhase || !x.Phase.ToLower().Contains(parola.ToLower()))
                            );
                }
            }
            
            var listaTizi = query.ToList();

            aggiornaTabella(listaTizi);
        }

        public InColonne impostaColonneRicerca()
        {
            var colAttive = new InColonne();

            foreach (ListItem item in cklColonne.Items)
            {
                if(item.Value == "File")
                {
                    if (item.Selected) { colAttive.inFile = true; } else { colAttive.inFile = false; }
                }
                else if (item.Value == "Sequid")
                {
                    if (item.Selected) { colAttive.inSequid = true; } else { colAttive.inSequid = false; }
                }
                else if (item.Value == "Source")
                {
                    if (item.Selected) { colAttive.inSource = true; } else { colAttive.inSource = false; }
                }
                else if (item.Value == "Type")
                {
                    if (item.Selected) { colAttive.inType = true; } else { colAttive.inType = false; }
                }
                else if (item.Value == "Start")
                {
                    if (item.Selected) { colAttive.inStart = true; } else { colAttive.inStart = false; }
                }
                else if (item.Value == "End")
                {
                    if (item.Selected) { colAttive.inEnd = true; } else { colAttive.inEnd = false; }
                }
                else if (item.Value == "Score")
                {
                    if (item.Selected) { colAttive.inScore = true; } else { colAttive.inScore = false; }
                }
                else if (item.Value == "Strand")
                {
                    if (item.Selected) { colAttive.inStrand = true; } else { colAttive.inStrand = false; }
                }
                else if (item.Value == "Phase")
                {
                    if (item.Selected) { colAttive.inPhase = true; } else { colAttive.inPhase = false; }
                }
                else if (item.Value == "Attributes")
                {
                    if (item.Selected) { colAttive.inAttributes = true; } else { colAttive.inAttributes = false; }
                }
            }

            return colAttive;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          
        }

        public void aggiornaTabella(List<BioTizio> lista)
        {
            if (lista != null)
            {
                GridView1.DataSource = lista;
                GridView1.DataBind();

                stato.Text = "Ci sono <strong>" + lista.Count + "</strong> risultati.";

                messaggio.Text = "";
                pulsantiColonne.Visible = true;
            }
            else
            {
                pulsantiColonne.Visible = false;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        public void visualizzaFileCaricato()
        {
            if (Session["nomeFile"] != null)
            {
                var files = Session["nomeFile"] as List<string>;
                litFileCaricato.Visible = true;

                litFileCaricato.Text = "";

                foreach (var file in files)
                {
                    litFileCaricato.Text += "<strong>File attivo:</strong> " + file + "<br>";
                }
            }
            else
            {
                litFileCaricato.Text = "";
                litFileCaricato.Visible = false;
            }
        }

        protected void btnEsportaExcel_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }

        private void ExportGridToExcel()
        {
            GridView1.AllowPaging = false;
            impostaFiltri();

            GridView1.BorderStyle = BorderStyle.Solid;
            GridView1.BorderWidth = 1;
            GridView1.BackColor = Color.WhiteSmoke;
            GridView1.GridLines = GridLines.Both;
            GridView1.Font.Name = "Verdana";
            GridView1.Font.Size = FontUnit.XXSmall;
            GridView1.HeaderStyle.BackColor = Color.DimGray;
            GridView1.HeaderStyle.ForeColor = Color.White;
            GridView1.RowStyle.HorizontalAlign = HorizontalAlign.Left;
            GridView1.RowStyle.VerticalAlign = VerticalAlign.Top;

            string FileName = "Gff3ToExcel_" + DateTime.Now + ".xls";
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.Charset = "";
            response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = Encoding.UTF8;
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);

            using (var sw = new StringWriter())
            {
                using (var htw = new HtmlTextWriter(sw))
                {
                    GridView1.RenderControl(htw);
                    response.Write(sw.ToString());
                    response.End();

                    GridView1.AllowPaging = true;
                    impostaFiltri();
                }
            }
        }

        public void mostraNascondiColonne(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridView grid = GridView1 as GridView;

            if (button.CommandName == "1")
            {
                grid.Columns[0].Visible = grid.Columns[0].Visible == true ? false : true;
                aggiornaBottoni(button, grid.Columns[0].Visible);
            }
            else if (button.CommandName == "2")
            {
                grid.Columns[1].Visible = grid.Columns[1].Visible == true ? false : true;
                aggiornaBottoni(button, grid.Columns[1].Visible);
            }
            else if (button.CommandName == "3")
            {
                grid.Columns[2].Visible = grid.Columns[2].Visible == true ? false : true;
                aggiornaBottoni(button, grid.Columns[2].Visible);
            }
            else if (button.CommandName == "4")
            {
                grid.Columns[3].Visible = grid.Columns[3].Visible == true ? false : true;
                aggiornaBottoni(button, grid.Columns[3].Visible);
            }
            else if (button.CommandName == "5")
            {
                grid.Columns[4].Visible = grid.Columns[4].Visible == true ? false : true;
                aggiornaBottoni(button, grid.Columns[4].Visible);
            }
            else if (button.CommandName == "6")
            {
                grid.Columns[5].Visible = grid.Columns[5].Visible == true ? false : true;
                aggiornaBottoni(button, grid.Columns[5].Visible);
            }
            else if (button.CommandName == "7")
            {
                grid.Columns[6].Visible = grid.Columns[6].Visible == true ? false : true;
                aggiornaBottoni(button, grid.Columns[6].Visible);
            }
            else if (button.CommandName == "8")
            {
                grid.Columns[7].Visible = grid.Columns[7].Visible == true ? false : true;
                aggiornaBottoni(button, grid.Columns[7].Visible);
            }
            else if (button.CommandName == "9")
            {
                grid.Columns[8].Visible = grid.Columns[8].Visible == true ? false : true;
                aggiornaBottoni(button, grid.Columns[8].Visible);
            }
            else if (button.CommandName == "10")
            {
                grid.Columns[9].Visible = grid.Columns[9].Visible == true ? false : true;
                aggiornaBottoni(button, grid.Columns[9].Visible);
            }

            //Bind the DataTable.
            impostaFiltri();
        }

        public void aggiornaBottoni(Button button, bool attivo)
        {
            button.CssClass = attivo ? "btn btn-danger" : "btn btn-success";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            impostaFiltri(); // this is whatever method you call to bind your data.
        }
        
        protected void ddlNumeroRisultati_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNumeroPagine.SelectedValue == "all")
            {
                List<BioTizio> dati = Session["data"] as List<BioTizio>;
                GridView1.PageSize = dati.Count;
                impostaFiltri();
            }
            else
            {
                List<BioTizio> dati = Session["data"] as List<BioTizio>;
                GridView1.PageSize = Convert.ToInt32(ddlNumeroPagine.SelectedValue);
                GridView1.DataSource = dati;
                impostaFiltri();
            }
        }

        private void GridViewSortDirection(GridView g, GridViewSortEventArgs e, out SortDirection d, out string f)
        {
            f = e.SortExpression;
            d = e.SortDirection;

            //Check if GridView control has required Attributes
            if (g.Attributes["CurrentSortField"] != null && g.Attributes["CurrentSortDir"] != null)
            {
                if (f == g.Attributes["CurrentSortField"])
                {
                    d = SortDirection.Descending;
                    if (g.Attributes["CurrentSortDir"] == "ASC")
                    {
                        d = SortDirection.Ascending;
                    }
                }

                g.Attributes["CurrentSortField"] = f;
                g.Attributes["CurrentSortDir"] = (d == SortDirection.Ascending ? "DESC" : "ASC");
                
                var tabella = Session["data"] as List<BioTizio>;
                IOrderedEnumerable<BioTizio> tab = null;
                if (f == "file")
                {
                    tab = d == SortDirection.Ascending ? tabella.OrderBy(x => x.File) : tabella.OrderByDescending(x => x.File);
                }
                else if (f == "sequid")
                {
                    tab = d == SortDirection.Ascending ? tabella.OrderBy(x => x.Sequid) : tabella.OrderByDescending(x => x.Sequid);
                }
                else if (f == "source")
                {
                    tab = d == SortDirection.Ascending ? tabella.OrderBy(x => x.Source) : tabella.OrderByDescending(x => x.Source);
                }
                else if (f == "type")
                {
                    tab = d == SortDirection.Ascending ? tabella.OrderBy(x => x.Type) : tabella.OrderByDescending(x => x.Type);
                }
                else if (f == "start")
                {
                    tab = d == SortDirection.Ascending ? tabella.OrderBy(x => x.Start) : tabella.OrderByDescending(x => x.Start);
                }
                else if (f == "end")
                {
                    tab = d == SortDirection.Ascending ? tabella.OrderBy(x => x.End) : tabella.OrderByDescending(x => x.End);
                }
                else if (f == "score")
                {
                    tab = d == SortDirection.Ascending ? tabella.OrderBy(x => x.Score) : tabella.OrderByDescending(x => x.Score);
                }
                else if (f == "strand")
                {
                    tab = d == SortDirection.Ascending ? tabella.OrderBy(x => x.Strand) : tabella.OrderByDescending(x => x.Strand);
                }
                else if (f == "phase")
                {
                    tab = d == SortDirection.Ascending ? tabella.OrderBy(x => x.Phase) : tabella.OrderByDescending(x => x.Phase);
                }
                else if (f == "attributes")
                {
                    tab = d == SortDirection.Ascending ? tabella.OrderBy(x => x.Attributes) : tabella.OrderByDescending(x => x.Attributes);
                }
                aggiornaTabella(tab.ToList());
            }

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string sortField = string.Empty;
            GridViewSortDirection(GridView1, e, out sortDirection, out sortField);
        }

        protected void btnEliminaFiltri_Click(object sender, EventArgs e)
        {
            // Rimuovo i filtri per parola
            Session["contiene"] = null;
            Session["noncontiene"] = null;
            valoriContiene.Value = null;
            valoriNonContiene.Value = null;

            // Ripristino la visione delle colonne
            GridView grid = GridView1 as GridView;
            for (int i = 0; i < 10; i++)
            {
                grid.Columns[i].Visible = true;
            }

            // Ripristino le colonne sui filtri
            foreach(ListItem item in cklColonne.Items)
            {
                item.Selected = true;
            }

            // imposto i pulsanti del mostra/nascondi colonne come attivi
            colonna1.CssClass = "btn btn-danger";
            colonna2.CssClass = "btn btn-danger";
            colonna3.CssClass = "btn btn-danger";
            colonna4.CssClass = "btn btn-danger";
            colonna5.CssClass = "btn btn-danger";
            colonna6.CssClass = "btn btn-danger";
            colonna7.CssClass = "btn btn-danger";
            colonna8.CssClass = "btn btn-danger";
            colonna9.CssClass = "btn btn-danger";

            impostaFiltri();
        }
    }

    public class BioTizio
    {
        public string File { get; set; }
        public string Sequid { get; set; }
        public string Source { get; set; }
        public string Type { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Score { get; set; }
        public string Strand { get; set; }
        public string Phase { get; set; }
        public string Attributes { get; set; }
    }

    public class InColonne
    {
        public bool inFile { get; set; }
        public bool inSequid { get; set; }
        public bool inSource { get; set; }
        public bool inType { get; set; }
        public bool inStart { get; set; }
        public bool inEnd { get; set; }
        public bool inScore { get; set; }
        public bool inStrand { get; set; }
        public bool inPhase { get; set; }
        public bool inAttributes { get; set; }
    }
}