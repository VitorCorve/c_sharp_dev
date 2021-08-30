﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace GameOfFrameworks.Scenes
{
    /// <summary>
    /// Логика взаимодействия для RunGame.xaml
    /// </summary>
    public partial class RunGame : Page
    {
        public RunGame()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) => Environment.Exit(0);

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGame newGame = new NewGame();
            NavigationService.Navigate(newGame);
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadGame loadGame = new LoadGame();
            NavigationService.Navigate(loadGame);
        }

        private void ArmoryButton_Click(object sender, RoutedEventArgs e)
        {
            Armory armory = new Armory();
            NavigationService.Navigate(armory);
        }

        private void BattleScene_Click(object sender, RoutedEventArgs e)
        {
            BattleWindow battleWindow = new BattleWindow();
            NavigationService.Navigate(battleWindow);
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            GameOptions gameOptions = new GameOptions();
            NavigationService.Navigate(gameOptions);
        }
    }
}
