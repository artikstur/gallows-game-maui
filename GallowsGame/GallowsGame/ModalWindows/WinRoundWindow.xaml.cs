﻿using GallowsGame.Pages;

namespace GallowsGame
{
    public partial class WinRoundWindow : ContentPage
    {
        public WinRoundWindow()
        {
            InitializeComponent();
            this.Opacity = 0;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.FadeTo(1, 1000); 
        }
        public async void OnOkClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public async void OnOkButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EnterWordPage());
        }
    }
}

