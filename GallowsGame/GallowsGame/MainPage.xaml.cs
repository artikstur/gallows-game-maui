﻿namespace GallowsGame
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnExitButtonClicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
            Console.WriteLine("gwegwg");
        }

        private void OnStartGameButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnGameRulesButtonClicked(object sender, EventArgs e)
        {

        }
    }

}
