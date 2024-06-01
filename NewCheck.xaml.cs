using MyAquariumCheck.Data;
using MyAquariumCheck.Models;

namespace MyAquariumCheck;

public partial class NewCheck : ContentPage
{
    readonly DataBase database;
    DateTime oggi = DateTime.Now;

    public NewCheck()
    {
        InitializeComponent();
        database = new DataBase();

        DatePicker datePicker = new DatePicker
        {
            MinimumDate = new DateTime(2024, 1, 1),
            MaximumDate = new DateTime(2099, 12, 31),
            Date = oggi
        };
    }

    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        double value = args.NewValue;
        int Temperature = Convert.ToInt32(value);
        T_corrente.Text = String.Format("Temperatura (C°): {0}", Temperature);
    }

    void OnPHValueCanged(object sender, TextChangedEventArgs args)
    {
        PH_corrente.Text = String.Format("PH: {0}", args.NewTextValue);
    }

    void OnGHValueCanged(object sender, TextChangedEventArgs args)
    {
        GH_corrente.Text = String.Format("GH: {0}", args.NewTextValue);
    }

    void OnKHValueCanged(object sender, TextChangedEventArgs args)
    {
        KH_corrente.Text = String.Format("KH: {0}", args.NewTextValue);
    }

    void OnNo2ValueCanged(object sender, TextChangedEventArgs args)
    {
        No2_corrente.Text = String.Format("No2: {0}", args.NewTextValue);
    }

    void OnNo3ValueCanged(object sender, TextChangedEventArgs args)
    {
        No3_corrente.Text = String.Format("No3: {0}", args.NewTextValue);
    }

    private async void OnInsClicked(object sender, EventArgs e)
    {
        if (PH_TXT.Text is null || PH_TXT.Text == "")
        {
            await App.Current.MainPage.DisplayAlert("Dati mancanti",
                "Ehi non hai inserito il PH", "OK");

            return;
        }

        if (GH_TXT.Text is null || GH_TXT.Text == "")
        {
            await App.Current.MainPage.DisplayAlert("Dati mancanti",
                "Ehi non hai inserito il GH", "OK");

            return;
        }

        if (KH_TXT.Text is null || KH_TXT.Text == "")
        {
            await App.Current.MainPage.DisplayAlert("Dati mancanti",
                "Ehi non hai inserito il KH", "OK");

            return;
        }

        if (No2_TXT.Text is null || No2_TXT.Text == "")
        {
            await App.Current.MainPage.DisplayAlert("Dati mancanti",
                "Ehi non hai inserito il No2", "OK");

            return;
        }

        if (No3_TXT.Text is null || No3_TXT.Text == "")
        {
            await App.Current.MainPage.DisplayAlert("Dati mancanti",
                "Ehi non hai inserito il No3", "OK");

            return;
        }

        string formatted = "";

        DateTime? selectedDate = DataTXT.Date;
        if (selectedDate.HasValue)
        {
            // Attenzione:
            // su windows machine e pubblicazione su andorid il formato della data deve essere: dd/MM/yyyy
            // mentre per android in locale: MM/dd/yyyy

            formatted = selectedDate.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Dati mancanti",
                "Ehi non hai indicato la data del controllo", "OK");

            return;
        }

        /*
        if (DateTime.Parse(formatted) < DateTime.Now)
        {
            await App.Current.MainPage.DisplayAlert("Data non valida",
                "Ehi la data del controllo non è valida", "OK");

            return;
        }
        */

        CheckItem nuovoCheckItem = new CheckItem
        {
            Data = DateTime.Parse(formatted),
            Temperatura = Convert.ToInt32(T_TXT.Value),
            PH = Convert.ToDecimal(PH_TXT.Text),
            GH = Convert.ToDecimal(GH_TXT.Text),
            KH = Convert.ToDecimal(KH_TXT.Text),
            NO2 = Convert.ToDecimal(No2_TXT.Text),
            NO3 = Convert.ToDecimal(No3_TXT.Text),
        };

        int esito = await database.AggiungiCheckItem(nuovoCheckItem);

        if (esito != 0)
        {
            await App.Current.MainPage.DisplayAlert("Inserimento Controllo Eseguito",
                "...ho memorizzato il Tuo controllo dei valori", "OK");

            //await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage(), true);

            await Application.Current.MainPage.Navigation.PushModalAsync(new TabPage(), true);

        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Inserimento Controllo FALLITO",
                "mmmh qualcosa si è rotto...", "OK");

            //await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage(), true);
        }
    }

    /*
    private void OnButtonInfoAppClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(new InfoApp(), true);
    }

    private void OnButtonHomeClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(new MainPage(), true);
    }
    */
}