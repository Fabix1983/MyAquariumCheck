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
            new FishList { Nome ="Oranda", Descrizione="E' una varietà di pesce rosso e uno dei pochi pesci da acquario che si adatta bene ad un range di temperature dell'acqua comprese tra i 18° ed i 28° gradi, ideale tra i 22° e 26°. Presenta varie colorazioni come arancione, rosso, bianco e rosso, rosso e nero, nero, blu. Presente in diversi tipi di varietà, tra i più comuni troviamo Rosso, Shubunkin, Calico, Fantail, Ryukin, Testa di Leone, Black Moor e Ranchu. Puo raggiungere dimensioni da adulto comprese tra i 12 e 15 cm di lunghezza pertanto richiede acquari di alto litraggio, almeno 80/100 litri. Pesce longevo e resistente in condizioni ideali può vivere anche 20 anni.", imgname="oranda.jpg"},
            new FishList { Nome ="Ramirezi", Descrizione="Appartiene alla famiglia dei ciclidi nani detti Ramirez. Pesce esigente e che richiede cura. Presenta colorazioni vivaci e puo raggiungere una dimensione di lunghezza di 7/9 cm.", imgname="ramirezi.jpg"},
            new FishList { Nome ="Betta", Descrizione="Betta Splendens o anche detto Pesce combattente e un pesce elegante di dimensioni ridotte, puo raggiungere i 6/8 cm per i maschi e 5 cm per le femmine. In gradi di respirare ossigeno direttamente dall'aria tramite un organo detto labirinto. Pesce che non richiede alti litraggi e che non ama molto la compagnia. Le principali varietà sono Plakat, Veiltail,Halfmoon e la Crowntail. Predilige temperature tra i 25° e 28° gradi. Necessità di condizioni specifiche in particolare al PH affinche si possa mantenere in buona salute.", imgname="betta.jpg"},
            new FishList { Nome ="Platy", Descrizione="sdfdsfsdfsdfsd", imgname="platy.jpg"},
            new FishList { Nome ="Discus", Descrizione="4354543534", imgname="discus.jpg"},
            new FishList { Nome ="Corydoras", Descrizione="43refsdfsfs", imgname="corydoras.jpg"},
            new FishList { Nome ="Scalare", Descrizione="tryrtdf", imgname="scalare.jpg"},
            new FishList { Nome ="Guppy", Descrizione="jyujghjghj", imgname="guppy.jpg"},
            new FishList { Nome ="Neon", Descrizione="sdfsdrhghgf", imgname="neon.jpg"},
        };

        ListView.ItemsSource= items;  
	}
}