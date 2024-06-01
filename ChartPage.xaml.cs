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
        int y = 0;
        ChartEntry[] entriesPH = new ChartEntry[itemnum];
        ChartEntry[] entriesGH = new ChartEntry[itemnum];
        ChartEntry[] entriesKH = new ChartEntry[itemnum];
        ChartEntry[] entriesNo2 = new ChartEntry[itemnum];
        ChartEntry[] entriesNo3 = new ChartEntry[itemnum];

        foreach (var item in await database.LeggiCheckItemNoDesc())
        {
            y = y + 1;
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

            if (y > 0) { 
                entriesPH[i] =
                new ChartEntry((float)Checks[i].PH)
                {
                    Label = Checks[i].Data.ToString().Substring(0, 9),
                    ValueLabel = Checks[i].PH.ToString(),
                    Color = SKColor.Parse("#1A7CA6"),
                };

                entriesGH[i] =
                new ChartEntry((float)Checks[i].GH)
                {
                    Label = Checks[i].Data.ToString().Substring(0, 9),
                    ValueLabel = Checks[i].GH.ToString(),
                    Color = SKColor.Parse("#77d065")
                };

                entriesKH[i] =
                new ChartEntry((float)Checks[i].KH)
                {
                    Label = Checks[i].Data.ToString().Substring(0, 9),
                    ValueLabel = Checks[i].KH.ToString(),
                    Color = SKColor.Parse("#b455b6")
                };

                entriesNo2[i] =
                new ChartEntry((float)Checks[i].NO2)
                {
                    Label = Checks[i].Data.ToString().Substring(0, 9),
                    ValueLabel = Checks[i].NO2.ToString(),
                    Color = SKColor.Parse("#3498db")
                };

                entriesNo3[i] =
                new ChartEntry((float)Checks[i].NO3)
                {
                    Label = Checks[i].Data.ToString().Substring(0, 9),
                    ValueLabel = Checks[i].NO3.ToString(),
                    Color = SKColor.Parse("#e9967a")
                };
            }

            i++;
        }

        if (y > 0)
        {
            chartViewPH.Chart = new BarChart
            {
                Entries = entriesPH,
                LabelTextSize = 25,
                ValueLabelTextSize = 25
            };

            chartViewGH.Chart = new BarChart
            {
                Entries = entriesGH,
                LabelTextSize = 25,
                ValueLabelTextSize = 25
            };

            chartViewKH.Chart = new BarChart
            {
                Entries = entriesKH,
                LabelTextSize = 25,
                ValueLabelTextSize = 25
            };

            chartViewNo2.Chart = new LineChart
            {
                Entries = entriesNo2,
                LabelTextSize = 25,
                ValueLabelTextSize = 25
            };

            chartViewNo3.Chart = new LineChart
            {
                Entries = entriesNo3,
                LabelTextSize = 25,
                ValueLabelTextSize = 25
            };
        }
    }
}