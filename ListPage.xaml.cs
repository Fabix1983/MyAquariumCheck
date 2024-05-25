using Microsoft.VisualBasic;
using MyAquariumCheck.Models;

namespace MyAquariumCheck;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
        InitializeComponent();

        var items = new List<FishList>
        {
            new FishList { Nome ="Oranda", Descrizione="jfskjdfkjsdkjf", imgname="oranda.jpg"},
            new FishList { Nome ="Oranda1", Descrizione="sdfsdfsd", imgname="ramirezi.jpg"},
            new FishList { Nome ="Oranda2", Descrizione="45wererewr", imgname="betta.jpg"},
            new FishList { Nome ="Oranda3", Descrizione="sdfdsfsdfsdfsd", imgname="platy.jpg"},
            new FishList { Nome ="Oranda4", Descrizione="4354543534", imgname="discus.jpg"},
            new FishList { Nome ="Oranda5", Descrizione="43refsdfsfs", imgname="corydoras.jpg"},
            new FishList { Nome ="Oranda6", Descrizione="tryrtdf", imgname="scalare.jpg"},
            new FishList { Nome ="Oranda7", Descrizione="jyujghjghj", imgname="guppy.jpg"},
            new FishList { Nome ="Oranda8", Descrizione="sdfsdrhghgf", imgname="neon.jpg"},
        };

        ListView.ItemsSource= items;  
	}
}