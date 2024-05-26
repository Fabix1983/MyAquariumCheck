using MyAquariumCheck.Data;
using MyAquariumCheck.ViewModels;
using System.Collections.ObjectModel;

namespace MyAquariumCheck;

public partial class PopupPage : ContentPage
{
    int count = 0;

    readonly DataBase database;
    public ObservableCollection<CheckItemVM> Checks { get; set; } = new();

    public PopupPage(int id)
	{
		InitializeComponent();
        database = new DataBase();
        long idrecord = id;
        LeggiCheckItemDetails(idrecord);

        //DEBUG
        //App.Current.MainPage.DisplayAlert("ID 1", idrecord.ToString(), "OK");
        label0.Text = String.Format("idrecord: {0}", idrecord.ToString());
    }

    private async void LeggiCheckItemDetails(long id)
    {
        foreach (var item in await database.LeggiCheckItemID(id))
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

        //DEBUG
        await App.Current.MainPage.DisplayAlert("ID 3", Checks[0].Id.ToString(), "OK");
    }

}