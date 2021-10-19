﻿using GameOfFrameworks.Infrastructure.Commands.Base;
using GameOfFrameworks.ViewModels.ArmoryUserControlsViewModels.Options;

namespace GameOfFrameworks.Infrastructure.Commands.Armory.Options
{
    public class HideLoadingGameConfirmationControlCommand : Command
    {
        private readonly OptionsControlViewModel ViewModel;
        public HideLoadingGameConfirmationControlCommand(OptionsControlViewModel optionsControlViewModel) => ViewModel = optionsControlViewModel;
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => ViewModel.LoadGameConfirmationControlVisibility = System.Windows.Visibility.Hidden;
    }
}
