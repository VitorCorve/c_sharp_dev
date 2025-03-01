﻿using GameEngine.CombatEngine;
using GameEngine.Locations.Interfaces;
using GameEngine.Locations.Services;
using GameEngine.Player;
using GameOfFrameworks.Infrastructure.Commands.Armory;
using GameOfFrameworks.Infrastructure.Commands.Armory.Options;
using GameOfFrameworks.Infrastructure.Commands.LoadGame;
using GameOfFrameworks.Models.Services;
using GameOfFrameworks.Models.Temporary;
using GameOfFrameworks.ViewModels.Base;
using System.Timers;
using System.Windows.Input;

namespace GameOfFrameworks.ViewModels
{
    public class ArmoryViewModel : ViewModel
    {
        private ILocation _CurrentLocation;
        private AnimatedProgressBar _ProgressBar;
        public AnimatedProgressBar ProgressBar { get => _ProgressBar; set => Set(ref _ProgressBar, value); }
        private PlayerEntity _CharacterEntity;
        public PlayerEntity CharacterEntity { get => _CharacterEntity; set => Set(ref _CharacterEntity, value); }
        private PlayerModelData _PlayerModel;
        public PlayerModelData PlayerModel { get => _PlayerModel; set => Set(ref _PlayerModel, value); }
        public PlayerExperienceConverter Converter { get; set; }
        public ILocation CurrentLocation { get => _CurrentLocation; set => Set(ref _CurrentLocation, value); }
        public static ICommand UpdateArmoryViewModelCommand { get; private set; }
        public static ICommand SaveGameCommand { get; private set; }
        public static ICommand LoadSaveDataCommand { get; private set; }
        public static ICommand LoadAutoSaveDataCommand { get; private set; }
        public ArmoryViewModel()
        {
            if (ArmoryTemporaryData.SaveData is null)
            {
                ApplyCharacterCreationViewModel.SaveCharacterCommand.Execute(null);
                LoadAutoSaveDataCommand = new LoadAutoSaveDataCommand();
                LoadAutoSaveDataCommand.Execute(null);
                MainWindowViewModel.ShowNotificationCommand.Execute("Loaded...");
            }
            var locationBuilder = new LocationBuilder();
            PlayerModel = ArmoryTemporaryData.PlayerModel;

            CharacterEntity = ArmoryTemporaryData.CharacterEntity;

            CurrentLocation = locationBuilder.Build(ArmoryTemporaryData.CurrentLocation.Town);

            Converter = new PlayerExperienceConverter(PlayerModel);

            ProgressBar = new AnimatedProgressBar();
            _ProgressBar.Value = Converter.Convert();

            UpdateArmoryViewModelCommand = new UpdateArmoryViewModelCommand(this);
            SaveGameCommand = new SaveGameCommand();
            LoadSaveDataCommand = new LoadSaveDataCommand();
            LoadAutoSaveDataCommand = new LoadAutoSaveDataCommand();
            ArmoryTemporaryData.Console = ConsoleHandlerService.SetupConsoleConfiguration();
            PlayerModel.NewLevelGainded += NotifyLevelUp;
            var timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CharacterEntity = null;
            CharacterEntity = ArmoryTemporaryData.CharacterEntity;
        }

        private void NotifyLevelUp()
        {
            //debug
            //MainWindowViewModel.ShowNotificationCommand.Execute("New level gained");
        }
    }
}
