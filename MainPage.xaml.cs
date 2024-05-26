using MyAquariumCheck.Data;
using MyAquariumCheck.Models;
using MyAquariumCheck.ViewModels;
using System.Collections.ObjectModel;

namespace MyAquariumCheck
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        readonly DataBase database;
        public ObservableCollection<CheckItemVM> Checks { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();
            database = new DataBase();
            LeggiCheckItemDett();
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            //var item = sender as SwipeItem;
            //await DisplayAlert(item.Text, $"Hai invocato l'azione {item.Text}.", "OK");

            var item = (sender as BindableObject).BindingContext as CheckItemVM;

            try
            {

                CheckItem delCheckItem = new CheckItem
                {
                    Id = item.Id,
                    Data = item.Data,
                    Temperatura = item.Temperatura,
                    PH = item.PH,
                    GH = item.GH,
                    KH = item.KH,
                    NO2 = item.NO2,
                    NO3 = item.NO3,
                    Eseguito = item.Eseguito,
                };

                int esito = await database.EliminaCheckItem(delCheckItem);

                if (esito == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Errore",
                        "...questo check non vuole sparire!", "OK");
                }
                else
                {
                    Checks.Remove(item);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Errore", $"Attenzione si è verifcato un errore imprevisto.", "KO");
            }
        }

        private async void LeggiCheckItemDett()
        {
            foreach (var item in await database.LeggiCheckItem())
            {
                Checks.Add(new CheckItemVM
                {
                    Id = item.Id,
                    Data = item.Data,
                    Temperatura = item.Temperatura,
                    PH = item.PH,
                    GH = item.GH,
                    KH = item.KH,
                    NO2 = item.NO2,
                    NO3 = item.NO3,
                    Eseguito = item.Eseguito,
                });
            }
        }

        private async void OnButtonEliminaCheckClicked(object sender, EventArgs args)
        {
            int pos = 0;

            while (pos < Checks.Count)
                if (Checks[pos].Eseguito)
                {
                    CheckItem delCheckItem = new CheckItem
                    {
                        Id = Checks[pos].Id,
                        Data = Checks[pos].Data,
                        Temperatura = Checks[pos].Temperatura,
                        PH = Checks[pos].PH,
                        GH = Checks[pos].GH,
                        KH = Checks[pos].KH,
                        NO2 = Checks[pos].NO2,
                        NO3 = Checks[pos].NO3,
                        Eseguito = Checks[pos].Eseguito
                    };

                    int esito = await database.EliminaCheckItem(delCheckItem);

                    if (esito == 0)
                    {
                        await App.Current.MainPage.DisplayAlert("Errore Del Check",
                            "...questo check non vuole sparire!", "OK");
                    }
                    else
                    {
                        Checks.Remove(Checks[pos]);
                    }

                }
                else
                    pos++;
        }

        private async void OnButtonDetailsClicked(object sender, EventArgs args)
        {
            var item = (sender as BindableObject).BindingContext as CheckItemVM;

            try
            {

                CheckItem DettCheckItem = new CheckItem
                {
                    Id = item.Id,
                    Data = item.Data,
                    Temperatura = item.Temperatura,
                    PH = item.PH,
                    GH = item.GH,
                    KH = item.KH,
                    NO2 = item.NO2,
                    NO3 = item.NO3,
                    Eseguito = item.Eseguito,
                };

                int id = Convert.ToInt32(DettCheckItem.Id); 

                if (id > 0)
                {
                    //DEBUG
                    //await App.Current.MainPage.DisplayAlert("ID", id.ToString(), "OK");

                    await Navigation.PushModalAsync(new PopupPage(id));
                }
                else
                {
                    await DisplayAlert("Errore", $"Controllo Non trovato...!", "KO");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Errore", $"Attenzione si è verifcato un errore imprevisto...(ex:" + ex.Message + ")", "KO");
            }


        }

    }

}
