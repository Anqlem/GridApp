using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace GridApp
{
    public partial class MainPage : ContentPage
    {
        BoxView box;
        public MainPage()
        {
            Grid grid = new Grid();
            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            
   
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    box = new BoxView { Color = Color.Blue };
                    grid.Children.Add(box,i,j);
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    box.GestureRecognizers.Add(tap);
                }
            }
            Content = grid;
        }

        List<BoxView> clicked = new List<BoxView> { };
        private void Tap_Tapped(object sender, EventArgs e)
        {
            BoxView boxView = sender as BoxView;
            if (clicked.Contains(boxView))
            {
                boxView.Color = Color.Red;
                clicked.Remove(boxView);
            }
            else
            {
                boxView.Color = Color.Blue;
                clicked.Add(boxView);
            }

        }
    }
}
