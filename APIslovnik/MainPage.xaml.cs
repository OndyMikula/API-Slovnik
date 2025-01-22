using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using static APIslovnik.tridy;

namespace APIslovnik
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        //private List<Root> slovnik { get; set; }
        public async void vyhledatButton_Clicked(object sender, EventArgs e)
        {
            string slovo = zadaneSlovicko.Text;

            try
            {
                HttpClient client = new HttpClient();
                string adresa = $"https://api.dictionaryapi.dev/api/v2/entries/en/{slovo}";
                string odpoved = await client.GetStringAsync(adresa);
                List<Root> data = System.Text.Json.JsonSerializer.Deserialize<List<Root>>(odpoved);
                odpoved = odpoved.Substring(1, odpoved.Length - 2);

                lblHledaneSlovicko.Text = "Hledané slovíčko: " + data[0].word;
                lblVyslovnost.Text = "Výslovnost: " + data[0].phonetics[0].text;
                lblDefinice.Text = "Definice: " + data[0].meanings[0].definitions[0].definition;
                lblSynonyma.Text = "Synonyma: " + string.Join(", ", data[0].meanings[0].definitions[0].synonyms.Select(s => s.ToString()));
                lblAntonyma.Text = "Antonyma: " + string.Join(", ", data[0].meanings[0].definitions[0].antonyms.Select(a => a.ToString()));
            }
            catch (HttpRequestException ex)
            {
                //chyti chybu ze nenasel slovicko
                lblHledaneSlovicko.Text = "Chyba: Slovíčko zřejmě neexistuje v anglickém jazyce :(";
                lblVyznam.Text = string.Empty;
                lblVyslovnost.Text = string.Empty;
                lblDefinice.Text = string.Empty;
                lblSynonyma.Text = string.Empty;
                lblAntonyma.Text = string.Empty;
            }
        }

        private void resetButton_Clicked(object sender, EventArgs e)
        {
            zadaneSlovicko.Text = string.Empty;
            lblHledaneSlovicko.Text = "Hledané slovíčko: ";
            lblVyznam.Text = "Význam: ";
            lblVyslovnost.Text = "Výslovnost: ";
            lblDefinice.Text = "Definice: ";
            lblSynonyma.Text = "Synonyma: ";
            lblAntonyma.Text = "Antonyma: ";
        }
    }

}
