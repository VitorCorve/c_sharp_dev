﻿using GameEngine.CharacterCreationMaster;
using GameEngine.CharacterCreationMaster.Services;
using GameEngine.Player;
using GameEngine.Player.Specializatons.Mage;
using GameOfFrameworks.Infrastructure.Commands.Base;
using GameOfFrameworks.ViewModels;

namespace GameOfFrameworks.Infrastructure.Commands.CharacterCreation
{
    public class SelectMageClassCommand : Command
    {
        public CharacterCreationData CharacterData { get; set; }
        public NewGameViewModel ViewModel { get; set; }
        public SelectMageClassCommand(CharacterCreationData characterData, NewGameViewModel viewModel)
        {
            CharacterData = characterData;
            ViewModel = viewModel;
        }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter)
        {
            CharacterData.CharacterAttributes = new EntityModel_Mage();
            CharacterData.CharacterSpecialization = SPECIALIZATION.Mage;

            ViewModel.SpecializationDescription.SetDescription(CharacterData.CharacterSpecialization);

            var avatarsData = new GetAvatarsData();
            ViewModel.AvatarsList = avatarsData.GetAvatarsList(CharacterData.CharacterSpecialization, CharacterData.Gender);
            ViewModel.CharacterData.AvatarPath.Path = ViewModel.AvatarsList[0].Path;
            ViewModel.CharacterData.AvatarPath.MiniaturePath = ViewModel.AvatarsList[0].MiniaturePath;

            ViewModel.OnPropertyChanged(nameof(ViewModel.CharacterData.AvatarPath.Path));
            ViewModel.OnPropertyChanged(nameof(CharacterData));
            ViewModel.OnPropertyChanged(nameof(ViewModel.SpecializationDescription));
        }
    }
}
