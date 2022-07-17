<%@ Page
    Title="Daris Cappelletti"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="PortFolio._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" class="container-fluid">
    <style>
        .progress-label {
            text-align: left;
            padding-left: 30px;
        }

        .card {
            margin-bottom: 30px;
        }

        .card-hover {
            cursor: pointer;
            color: black;
            text-decoration: none;
        }

            .card-hover:hover {
                color: black;
                -webkit-box-shadow: 0px 0px 15px 5px rgba(0,0,0,0.32);
                box-shadow: 0px 0px 15px 5px rgba(0,0,0,0.32);
                transform: scale(1.1);
                transition: transform .2s;
            }

        .social-pill {
            cursor: pointer;
            color: white;
            text-decoration: none;
            background-color: #0d6efd;
            font-size: 0.95em;
        }

            .social-pill:hover {
                    color: #fff;
                    background-color: #0b5ed7;
            }
    </style>

    <div>
        <!-- Chi sono -->
        <div class="card">
            <h2 id="scrollChiSono" class="card-header text-center"><i class="fa-solid fa-user"></i>Chi sono</h2>
            <div class="card-body">
                <p class="card-text">Benvenuti nel mio sito.</p>
                <p class="card-text">
                    Mi chiamo Daris, ho
                    <asp:Literal ID="litAnniPersona" runat="server" />
                    anni e sono
                    <asp:Literal ID="litAnniLavoro" runat="server" />
                    che lavoro come programmatore full stack.
                </p>
                <p class="card-text">I linguaggi di programmazione che utilizzo sono:</p>

                <div class="progress">
                    <div class="progress-bar progress-bar-striped progress-bar-animated progress-label"
                        role="progressbar"
                        aria-valuenow="100"
                        aria-valuemin="0"
                        aria-valuemax="100"
                        style="width: 100%">
                        <strong>C# Web forms</strong>
                    </div>
                </div>
                <div class="progress mt-2">
                    <div class="progress-bar progress-bar-striped progress-bar-animated progress-label"
                        role="progressbar"
                        aria-valuenow="100"
                        aria-valuemin="0"
                        aria-valuemax="100"
                        style="width: 100%">
                        <strong>C# Web API</strong>
                    </div>
                </div>
                <div class="progress mt-2">
                    <div class="progress-bar progress-bar-striped progress-bar-animated progress-label"
                        role="progressbar"
                        aria-valuenow="90"
                        aria-valuemin="0"
                        aria-valuemax="100"
                        style="width: 90%">
                        <strong>C# MVC</strong>
                    </div>
                </div>
                <div class="progress mt-2">
                    <div class="progress-bar progress-bar-striped progress-bar-animated progress-label"
                        role="progressbar"
                        aria-valuenow="98"
                        aria-valuemin="0"
                        aria-valuemax="100"
                        style="width: 98%">
                        <strong>Html</strong>
                    </div>
                </div>
                <div class="progress mt-2">
                    <div class="progress-bar progress-bar-striped progress-bar-animated progress-label"
                        role="progressbar"
                        aria-valuenow="80"
                        aria-valuemin="0"
                        aria-valuemax="100"
                        style="width: 80%">
                        <strong>Jquery</strong>
                    </div>
                </div>
                <div class="progress mt-2">
                    <div class="progress-bar progress-bar-striped progress-bar-animated progress-label"
                        role="progressbar"
                        aria-valuenow="70"
                        aria-valuemin="0"
                        aria-valuemax="100"
                        style="width: 70%">
                        <strong>Javascript</strong>
                    </div>
                </div>
                <div class="progress mt-2">
                    <div class="progress-bar progress-bar-striped progress-bar-animated progress-label"
                        role="progressbar"
                        aria-valuenow="60"
                        aria-valuemin="0"
                        aria-valuemax="100"
                        style="width: 60%">
                        <strong>PHP</strong>
                    </div>
                </div>
            </div>
        </div>

        <!-- Esperienze lavorative -->
        <div class="card">
            <h2 id="scrollEsperienzeLavorative" class="card-header text-center">
                <i class="fa-solid fa-briefcase"></i>Esperienze lavorative
            </h2>
            <div class="card-body">
                <p class="card-text">
                    Ho lavorato come programmatore per 2 anni per l'azienda <a href="https://www.seiconsulting.it/" target="_blank">"SEI Consulting"</a> come libero professionista
            su un progetto chiamato <a href="https://procedimenti.regione.marche.it/">"ProcediMarche"</a> un sito web della "Regione Marche" dove è possibile gestire i procedimenti
            della regione e la compilazione di pratiche con form customizzabili
                </p>
                <p class="card-text">Il progetto è stato sviluppato con le seguenti tecnologie</p>

                <div class="mb-2">
                    <span class="badge rounded-pill bg-primary">C# Web forms</span>
                    <span class="badge rounded-pill bg-primary">C# Web API</span>
                    <span class="badge rounded-pill bg-primary">C# MVC</span>
                    <span class="badge rounded-pill bg-primary">Html</span>
                    <span class="badge rounded-pill bg-primary">Jquery</span>
                    <span class="badge rounded-pill bg-primary">Javascript</span>
                    <span class="badge rounded-pill bg-primary">PHP</span>
                </div>

                <p class="card-text">Ho utilizzato le seguenti librerie:</p>

                <div class="mb-2">
                    <span class="badge rounded-pill bg-primary">Bootstrap</span>
                    <span class="badge rounded-pill bg-primary">FontAwesome</span>
                    <span class="badge rounded-pill bg-primary">Graph.js</span>
                </div>

                <p class="card-text">
                    Nella soluzione è stato creato un progetto di Web API dove le strutture ed i comuni possono effettuare delle chiamate
                    per gestire i procedimenti/le pratiche create nel sito.
                </p>

                Inoltre sono state integrate delle chiamate ad API esterne ovvero:

                <ul>
                    <li>Ricerca sinonimi in base alla parola inserita</li>
                    <li>Verifica festività nazionali</li>
                    <li>Integrazione sistema di ticketing</li>
                    <li>Integrazione sistema di salvataggio dati su tabelle</li>
                </ul>

                <p class="card-text"><strong>La ricerca dei sinonimi</strong> è stata implementata per estrapolare tutti i sinonimi in base ad una parola passata.</p>
                <p class="card-text">
                    L'integrazione nel progetto è avvenuta impostando una chiamata asincrona che interrogasse le api in base
            all'input dell'utente, in questo modo dopo 1 secondo di delay la chiamata restituiva i sinonimi in modo da 
            facilitare la ricerca all'interno del sito.
                </p>

                <p class="card-text">
                    <strong>La verifica delle festività nazionali</strong> è stata implementata per completare una funzionalità di creazione di richieste di
            attivazione/disattivazione da parte degli utenti limitando le date possibili in base all'orario dell'helpdesk/ai giorni lavorativi e alle festività
            tramite l'interrogazione delle API
                </p>
                <p class="card-text">
                    Inserendo una data corretta l'utente può completare l'operazione ed effettuare la richiesta, in caso contrario
            verrà mostrato un messaggio di errore che invita l'utente alla modifica della data.
                </p>
            </div>
        </div>

        <!-- Formazione -->
        <div class="card">
            <h2 id="scrollFormazione" class="card-header text-center">
                <i class="fa-solid fa-graduation-cap"></i>Formazione
            </h2>
            <div class="card-body">
                <div class="list-group">
                    <a class="list-group-item list-group-item-action" aria-current="true">
                        <div class="d-flex w-100 justify-content-between">
                            <h5 class="mb-1">L-31 - Laurea triennale in scienze e tecnologie informatiche</h5>
                            <small>5 anni fa</small>
                        </div>
                        <p class="mb-1">Università degli studi di Camerino</p>
                        <%--<small>And some small print.</small>--%>
                    </a>
                    <a class="list-group-item list-group-item-action">
                        <div class="d-flex w-100 justify-content-between">
                            <h5 class="mb-1">Diploma di istruzione secondaria superiore ad indirizzo scientifico</h5>
                            <small class="text-muted">11 anni fa</small>
                        </div>
                        <p class="mb-1">Liceo scientifico di Sarnano</p>
                        <%--<small class="text-muted">And some muted small print.</small>--%>
                    </a>
                </div>
            </div>
        </div>

        <!-- Progetti personali -->
        <div class="card">
            <h2 id="scrollProgettiPersonali" class="card-header text-center">
                <i class="fa-solid fa-mug-saucer"></i>Progetti personali
            </h2>
            <div class="card-body">
                <p class="card-text">Nel tempo libero mi piace studiare nuove tecnologie e nuovi modi di implementazione</p>
                <p class="card-text">Attualmente ho creato questi progetti</p>

                <div class="row row-cols-1 row-cols-md-2 g-4">
                    <div class="col">
                        <a class="card card-hover h-100" href="Gff3Reader/reader.aspx">
                            <h2 class="card-header text-center">
                                <i class="fa-solid fa-dna"></i>Gff3 reader
                            </h2>
                            <div class="card-body">
                                <p class="card-text">
                                    Ho sviluppato questo progetto in C# Web Forms.
                            Permette il caricamento di file in formato gff3, la visione dei dati in formato tabellare con la possibilità di
                            ricerca/esclusione di parole, la possibilità di vedere/nascondere colonne della tabella, paginazione per gff3
                            di grandi dimensione con possibilità di modificare i risultati per pagina.
                                </p>
                            </div>
                            <div class="card-footer">
                                <small class="text-muted">
                                    <span class="badge rounded-pill bg-primary">C# Web forms</span>
                                    <span class="badge rounded-pill bg-primary">Html</span>
                                    <span class="badge rounded-pill bg-primary">Jquery</span>
                                    <span class="badge rounded-pill bg-primary">Javascript</span>
                                </small>
                            </div>
                        </a>
                    </div>
                    <!-- Ricerca treni -->
                    <div class="col">
                        <a class="card card-hover h-100">
                            <h2 class="card-header text-center">
                                <i class="fa-solid fa-train"></i>Ricerca treni
                            </h2>
                            <div class="card-body">
                                <p class="card-text">
                                    Ho sviluppato questo progetto in C# Web Forms.
                Permette la ricerca di treni impostando la stazione di partenza e di arrivo ed impostando una data di inizio e una data di fine.
                Il sito si differenziato dalle solite app per la ricerca dei treni perchè permette di impostare un range di date,
                ovvero impostando la data di inizio e di fine il sito restituirà tutte le soluzioni possibili in questo intervallo di date
                in modo da poter pianificare viaggi in base all'offerta migliore.
                                </p>
                            </div>
                            <div class="card-footer">
                                <small class="text-muted">
                                    <span class="badge rounded-pill bg-primary">C# Web forms</span>
                                    <span class="badge rounded-pill bg-primary">Html</span>
                                    <span class="badge rounded-pill bg-primary">Jquery</span>
                                    <span class="badge rounded-pill bg-primary">Javascript</span>
                                </small>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
        </div>

        <!-- Contatti -->
        <div class="card">
            <h2 id="scrollContatti" class="card-header text-center">
                <i class="fa-solid fa-address-book"></i>Contatti
            </h2>
            <div class="card-body">
                <div class="row row-cols-1 row-cols-md-2 g-4">
                    <div class="col">
                        <div class="card h-100">
                            <h2 class="card-header text-center">
                                <i class="fa-solid fa-envelope"></i>Email
                            </h2>
                            <div class="card-body">
                                <p class="card-text">
                                    Potete contattarmi via email compilando questo form.
                                </p>

                                <div class="row mb-2">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtNominativo" runat="server" CssClass="form-control" placeholder="Nominativo o il nome dell'azienda" />
                                    </div>
                                </div>
                                <div class="row mb-2">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email dove ricontattarti" />
                                    </div>
                                </div>
                                <div class="row mb-2">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtOggetto" runat="server" CssClass="form-control" placeholder="Oggetto della tua richiesta" />
                                    </div>
                                </div>
                                <div class="row mb-2">
                                    <div class="col-md-12">
                                        <asp:TextBox
                                            ID="txtCorpo"
                                            runat="server"
                                            CssClass="form-control normal"
                                            placeholder="Inserisci il messaggio"
                                            TextMode="MultiLine" />
                                    </div>
                                </div>
                                <asp:Button ID="btnInviaEmail" runat="server" OnClick="btnInviaEmail_Click" CssClass="btn btn-secondary" Text="Invia" />
                            </div>
                        </div>
                    </div>
                    <!-- Social -->
                    <div class="col text-center">
                        <a class="badge social-pill" href="https://it.linkedin.com/in/dariscappelletti" target="_blank">
                            <i class="fa-brands fa-linkedin"></i> Linkedin
                        </a>
                        <a class="badge social-pill" href="https://github.com/DarisCappelletti"  target="_blank">
                            <i class="fa-brands fa-github-square"></i> Github
                        </a>
                        <a class="badge social-pill" href="https://stackoverflow.com/users/19482018/zackary"  target="_blank">
                            StackOverflow
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function () {

            var bars = $('.progress-bar');
            for (i = 0; i < bars.length; i++) {
                var progress = $(bars[i]).attr('aria-valuenow');

                $(bars[i]).css('background-color', getColor($(this), progress / 100))
            }
        });

        function getColor(el, value) {

            //value from 0 to 1
            var hue = ((value) * 100).toString(10);
            console.log(hue)
            return ["hsl(", hue, ",65%,50%)"].join("");
        }
    </script>

    <script type="text/javascript" src="lib/vendor/autosize/js/autosize.min.js"></script>
    <script>
        var ta = document.querySelector('textarea');
        autosize(ta);
    </script>
</asp:Content>
