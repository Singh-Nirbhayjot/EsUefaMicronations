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
    public struct Partita
    {
        public string SquadraCasa;
        public int GolCasa;
        public string SquadraOspite;
        public int GolOspite;

        public Partita(string squadraCasa, int golCasa, string squadraOspite, int golOspite)
        {
            SquadraCasa = squadraCasa;
            GolCasa = golCasa;
            SquadraOspite = squadraOspite;
            GolOspite = golOspite;
        }
    }

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

            Partita nuovaPartita = new Partita(txtSquadraCasa.Text.Trim(), golCasa, txtSquadraOspite.Text.Trim(), golOspite);
            SalvaSuFile(nuovaPartita);
            PulisciCampi();
        }

        private void SalvaSuFile(Partita partita)
        {
            string lineaDaSalvare = $"{partita.SquadraCasa};{partita.GolCasa};{partita.SquadraOspite};{partita.GolOspite}";
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
                    if (!string.IsNullOrWhiteSpace(linea))
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
            if (File.ReadAllLines(percorsoFile).Length == 0)
            {
                MessageBox.Show("Nessuna partita registrata ancora.");
                return;
            }

            string[] lineeFile = File.ReadAllLines(percorsoFile);

            // Converto le linee in array di struct Partita
            List<Partita> partite = new List<Partita>();
            foreach (string linea in lineeFile)
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    string[] dati = linea.Split(';');
                    Partita p = new Partita(dati[0], int.Parse(dati[1]), dati[2], int.Parse(dati[3]));
                    partite.Add(p);
                }
            }

            int totGolCampionato = 0;
            int maxGolPartita = 0;
            string partitaConPiuGol = "";
            string squadraMax = "";
            int maxGol = 0;

            foreach (Partita partita in partite)
            {
                int golTotali = partita.GolCasa + partita.GolOspite;
                totGolCampionato += golTotali;

                if (golTotali > maxGolPartita)
                {
                    maxGolPartita = golTotali;
                    partitaConPiuGol = $"{partita.SquadraCasa} {partita.GolCasa} - {partita.GolOspite} {partita.SquadraOspite}";
                }

                int totaleCasa = ContaGolSquadra(partita.SquadraCasa, partite);
                if (totaleCasa > maxGol)
                {
                    maxGol = totaleCasa;
                    squadraMax = partita.SquadraCasa;
                }

                int totaleOspite = ContaGolSquadra(partita.SquadraOspite, partite);
                if (totaleOspite > maxGol)
                {
                    maxGol = totaleOspite;
                    squadraMax = partita.SquadraOspite;
                }
            }

            MessageBox.Show($"STATISTICHE\n\n" +
                $"Squadra con più gol: {squadraMax} ({maxGol} gol totali)\n" +
                $"Partita con più gol: {partitaConPiuGol} ({maxGolPartita} gol)\n" +
                $"Gol totali nel campionato: {totGolCampionato}");
            AggiornaLista();
        }

        private int ContaGolSquadra(string squadra, List<Partita> partite)
        {
            int totale = 0;
            foreach (Partita partita in partite)
            {
                if (partita.SquadraCasa == squadra)
                    totale += partita.GolCasa;
                if (partita.SquadraOspite == squadra)
                    totale += partita.GolOspite;
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

            foreach (string linea in File.ReadAllLines(percorsoFile))
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    string[] dati = linea.Split(';');
                    Partita partita = new Partita(dati[0], int.Parse(dati[1]), dati[2], int.Parse(dati[3]));

                    string squadraCasa = partita.SquadraCasa.Trim().ToLower();
                    string squadraOspite = partita.SquadraOspite.Trim().ToLower();

                    if (squadraCasa == squadraDaCercare || squadraOspite == squadraDaCercare)
                    {
                        lstInterfaccia.Items.Add(linea);
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
