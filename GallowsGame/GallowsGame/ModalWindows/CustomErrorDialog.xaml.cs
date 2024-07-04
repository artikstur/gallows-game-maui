using Microsoft.Maui.Controls;


namespace GallowsGame
{
    public partial class CustomErrorDialog: ContentPage
    {
        public CustomErrorDialog(string errorMessage)
        {
            InitializeComponent();
            ErrorMessage.Text = errorMessage;
        }
        private async void OnOkClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}
