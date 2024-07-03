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


        public void OnBackToMainPageBttnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
