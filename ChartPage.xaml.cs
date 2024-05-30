using Microcharts;
using Microcharts.Maui;
using MyAquariumCheck.Data;
using MyAquariumCheck.ViewModels;
using SkiaSharp;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;

namespace MyAquariumCheck;

public partial class ChartPage : ContentPage
{
    readonly DataBase database;
    public ObservableCollection<CheckItemVM> Checks { get; set; } = new();

    int numDBcheckItem = 0;

    public ChartPage()
	{
		InitializeComponent();
        database = new DataBase();
        LeggiCheckItemDett();
    }

    private async void LeggiCheckItemDett()
    {
        int itemnum = 0;
        itemnum = await database.CountCheckItem();

        int i = 0;
        ChartEntry[] entriesPH = new ChartEntry[itemnum];
        ChartEntry[] entriesGH = new ChartEntry[itemnum];
        ChartEntry[] entriesKH = new ChartEntry[itemnum];
        ChartEntry[] entriesNo2 = new ChartEntry[itemnum];
        ChartEntry[] entriesNo3 = new ChartEntry[itemnum];

        foreach (var item in await database.LeggiCheckItemNoDesc())
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

            entriesPH[i] =
            new ChartEntry((float)Checks[i].PH)
            {
                Label = Checks[i].Data.ToString().Substring(0, 9),
                ValueLabel = Checks[i].PH.ToString(),
                Color = SKColor.Parse("#2c3e50")
            };

            entriesGH[i] =
            new ChartEntry((float)Checks[i].GH)
            {
                Label = Checks[i].Data.ToString().Substring(0, 9),
                ValueLabel = Checks[i].GH.ToString(),
                Color = SKColor.Parse("#77d065")
            };

            i++;
        }

        chartViewPH.Chart = new BarChart
        {
            Entries = entriesPH
        };

        chartViewGH.Chart = new BarChart
        {
            Entries = entriesGH
        };
    }
}