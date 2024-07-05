using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.Pages
{
    public partial class GameRulesPage : ContentPage
    {
        public GameRulesPage()
        {
            InitializeComponent();
        }


        public async void OnBackToMainPageBttnClicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            await button.ScaleTo(1.2, 100, Easing.Linear);
            await button.ScaleTo(1, 100, Easing.Linear);

            await Navigation.PopAsync();
        }
    }
}
