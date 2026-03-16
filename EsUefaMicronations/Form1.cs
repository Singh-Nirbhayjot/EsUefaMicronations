using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EsUefaMicronations
{
    public partial class Form1 : Form
    {
        private const string percorsoFile = "partite.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AggiornaLista();
        }
        private void btnSalva_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtSquadraCasa.Text) || string.IsNullOrWhiteSpace(txtSquadraOspite.Text) || string.IsNullOrWhiteSpace(txtGolCasa.Text) || string.IsNullOrWhiteSpace(txtGolOspite.Text))
            {
                MessageBox.Show("Per favore, compila tutti i campi prima di salvare.");
                return;
            }
            if (txtSquadraOspite.Text.Trim().ToLower() == txtSquadraCasa.Text.Trim().ToLower())
            {
                MessageBox.Show("Le squadre non possono essere uguali. Per favore, inserisci due squadre diverse.");
                return;
            }
            if (!int.TryParse(txtGolCasa.Text, out int golCasa) || !int.TryParse(txtGolOspite.Text, out int golOspite))
            {
                MessageBox.Show("Per favore, inserisci un numero valido per i gol.");
                return;
            }
            if (golCasa < 0 || golOspite < 0)
            {
                MessageBox.Show("I gol non possono essere negativi. Per favore, inserisci un numero valido.");
                return;
            }
            SalvaSuFile(txtSquadraCasa.Text.Trim(), txtSquadraOspite.Text.Trim(),
                        golCasa, golOspite);
            PulisciCampi();
        }
        private void SalvaSuFile(string squadraCasa, string squadraOspite,int golCasa, int golOspite)
        {
            string lineaDaSalvare = $"{squadraCasa};{golCasa};{squadraOspite};{golOspite}";
            using (StreamWriter sw = new StreamWriter(percorsoFile, true))
            {
                sw.WriteLine(lineaDaSalvare);
            }
            AggiornaLista();

        }
        private void AggiornaLista()
        {
            lstInterfaccia.Items.Clear();
            if (File.Exists(percorsoFile))
            {
                string[] linee = File.ReadAllLines(percorsoFile);
                foreach (string linea in linee)
                {
                    if(!string.IsNullOrWhiteSpace(linea))  //salta righe vuote o composte solo da spazi per esempio se il file è stato modificato manualmente e sono state aggiunte righe vuote
                        lstInterfaccia.Items.Add(linea);
                }
            }
        }
        private void PulisciCampi()
        {
            txtSquadraCasa.Clear();
            txtSquadraOspite.Clear();
            txtGolCasa.Clear();
            txtGolOspite.Clear();
        }
        private void btnStatistiche_Click(object sender, EventArgs e)  
        {

            if (!File.Exists(percorsoFile))
            {
                MessageBox.Show("Nessuna partita registrata ancora.");
                return;
            }
            if( File.ReadAllLines(percorsoFile).Length == 0) 
            {
                MessageBox.Show("Nessuna partita registrata ancora.");
                return;
            }

            string[] partite = File.ReadAllLines(percorsoFile);

            int totGolCampionato = 0;
            int maxGolPartita = 0;
            string partitaConPiuGol = "";
            string squadraMax = "";
            int maxGol = 0;

            foreach (string partita in partite) 
            {
                string[] dati = partita.Split(';');
                string squadraCasa = dati[0];
                int golCasa = int.Parse(dati[1]);
                string squadraOspite = dati[2];
                int golOspite = int.Parse(dati[3]);
                int golTotali = golCasa + golOspite;

                totGolCampionato += golTotali;

                if (golTotali > maxGolPartita)
                {
                    maxGolPartita = golTotali;
                    partitaConPiuGol = $"{squadraCasa} {golCasa} - {golOspite} {squadraOspite}";
                }

                int totaleCasa = ContaGolSquadra(squadraCasa, partite);  
                if (totaleCasa > maxGol) 
                {
                    maxGol = totaleCasa;    
                    squadraMax = squadraCasa;   
                }

                int totaleOspite = ContaGolSquadra(squadraOspite, partite); 
                if (totaleOspite > maxGol)  
                {
                    maxGol = totaleOspite;
                    squadraMax = squadraOspite;
                }
            }

            MessageBox.Show($"STATISTICHE\n\n" +
                $"Squadra con più gol: {squadraMax} ({maxGol} gol totali)\n" +
                $"Partita con più gol: {partitaConPiuGol} ({maxGolPartita} gol)\n" +
                $"Gol totali nel campionato: {totGolCampionato}");
            AggiornaLista();
        }
        private int ContaGolSquadra(string squadra, string[] partite)   //Prende una squadra e conta quanti gol ha segnato in totale in tutte le partite, sia da casa che da ospite, scorrendo tutte le partite registrate
        {
            int totale = 0;
            foreach (string partita in partite)
            {
                string[] dati = partita.Split(';');
                if (dati[0] == squadra)
                    totale += int.Parse(dati[1]);
                if (dati[2] == squadra)
                    totale += int.Parse(dati[3]);
            }
            return totale;
        }
        private void btnCerca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCerca.Text))
            {
                MessageBox.Show("Per favore, inserisci il nome di una squadra da cercare.");
                return;
            }

            if (!File.Exists(percorsoFile))
            {
                MessageBox.Show("Nessuna partita registrata ancora.");
                return;
            }

            string squadraDaCercare = txtCerca.Text.Trim().ToLower();
            lstInterfaccia.Items.Clear();
            bool trovata = false;

            foreach (string partita in File.ReadAllLines(percorsoFile))
            {
                if (!string.IsNullOrWhiteSpace(partita))
                {

                    string[] dati = partita.Split(';');
                    string squadraCasa = dati[0].Trim().ToLower();
                    string squadraOspite = dati[2].Trim().ToLower();

                    if (squadraCasa == squadraDaCercare || squadraOspite == squadraDaCercare)
                    {
                        lstInterfaccia.Items.Add(partita);
                        trovata = true;
                    }
                }
            }
            if (!trovata)
            {
                MessageBox.Show($"Nessuna partita trovata per: {txtCerca.Text.Trim()}");
                AggiornaLista(); 
            }
        }

        private void txtCerca_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGolCasa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGolOspite_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSquadraOspite_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSquadraCasa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
