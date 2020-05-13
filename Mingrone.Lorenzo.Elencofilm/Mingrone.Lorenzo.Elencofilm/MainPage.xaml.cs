using Mingrone.Lorenzo.Elencofilm.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Mingrone.Lorenzo.Elencofilm.Models.Film;

namespace Mingrone.Lorenzo.Elencofilm
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    
    public partial class MainPage : ContentPage
     {
        int index = 0;
        Films ArchivioDeiFilm { get; set; }
        public MainPage()
        {
            InitializeComponent();
            ArchivioDeiFilm = new Films();
            ArchivioDeiFilm.Load();
            lvDati.ItemsSource = ArchivioDeiFilm;
        }

         

        async private void btnOpenVideo(object sender, EventArgs e)
        {
            // Il record corrente passato con . , è dentro all'attributo "CommandParameter"
            // il quale è dentro al Button...
            // Button ci arriva come object e va fatto un cast con l'operatore as
            // Se l'operatore as torna null, qualcosa è andato storto... meglio non fare nulla
            Button m = sender as Button;
            if (m != null)
            {
                // Anche CommandParameter è un object e serve un cast a Film
                Film f = m.CommandParameter as Film;
                if (f != null)
                {
                    await Browser.OpenAsync(f.Link, BrowserLaunchMode.SystemPreferred);
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)//save button
        {
            ArchivioDeiFilm.Save();
        }


      
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            ArchivioDeiFilm.Add(new Film { Titolo = "Calcio", Link = "https://www.youtube.com/watch?v=gXlq4kf-qys", Immagine = "image/football.png" });
            ArchivioDeiFilm.Add(new Film { Titolo = "Cartoni", Link = "https://www.youtube.com/watch?v=oRwkKj5zIq0", Immagine = "image/cartoon.png" });
            ArchivioDeiFilm.Add(new Film { Titolo = "Film comici", Link = "https://www.youtube.com/watch?v=CjEkJN1SGik", Immagine = "image/comic.png" });
            
        }

        
        private void lvDati_ItemTapped(object sender, ItemTappedEventArgs e) //seleziona l' indice
        {
            index = (lvDati.ItemsSource as System.Collections.ObjectModel.ObservableCollection<Film>).IndexOf(e.Item as Film);
            
        }

        private void Button_Clicked_2(object sender, EventArgs e) //elimina film
        {
            //problemi con il remove...
        }
    }
}