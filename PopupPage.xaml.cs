using Microcharts;
using MyAquariumCheck.Data;
using MyAquariumCheck.Models;
using MyAquariumCheck.ViewModels;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace MyAquariumCheck;

public partial class PopupPage : ContentPage
{

    readonly DataBase database;
    public ObservableCollection<CheckItemVM> Checks { get; set; } = new();

    ChartEntry[] entries = new ChartEntry[5];

    public PopupPage(int id)
	{
		InitializeComponent();
        database = new DataBase();
        long idrecord = id;
        LeggiCheckItemDetails(idrecord);

        //DEBUG
        //App.Current.MainPage.DisplayAlert("ID 1", idrecord.ToString(), "OK");
        //label0.Text = String.Format("idrecord: {0}", idrecord.ToString());
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

        entries = new[]
{
            new ChartEntry((float)Checks[0].PH)
            {
                Label = "PH",
                ValueLabel = Checks[0].PH.ToString(),
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry((float)Checks[0].GH)
            {
                Label = "GH",
                ValueLabel = Checks[0].GH.ToString(),
                Color = SKColor.Parse("#77d065")
            },
            new ChartEntry((float)Checks[0].KH)
            {
                Label = "KH",
                ValueLabel = Checks[0].KH.ToString(),
                Color = SKColor.Parse("#b455b6")
            },
            new ChartEntry((float)Checks[0].NO2)
            {
                Label = "No2",
                ValueLabel = Checks[0].NO2.ToString(),
                Color = SKColor.Parse("#3498db")
            },
            new ChartEntry((float)Checks[0].NO3)
            {
                Label = "No3",
                ValueLabel = Checks[0].NO3.ToString(),
                Color = SKColor.Parse("#e9967a")
            }
        };

        chartView.Chart = new BarChart
        {
            Entries = entries
        };

        chartView1.Chart = new RadarChart
        {
            Entries = entries
        };

        data.Text = Checks[0].Data.ToString().Substring(0, 9);

        //DEBUG
        //await App.Current.MainPage.DisplayAlert("ID 3", Checks[0].Id.ToString(), "OK");
    }

    private async void OnButtonCloseClicked(object sender, EventArgs args)
    {
        await Application.Current.MainPage.Navigation.PushModalAsync(new TabPage(), true);
    }

}