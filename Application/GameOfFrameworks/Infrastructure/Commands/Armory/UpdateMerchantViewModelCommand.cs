﻿using GameOfFrameworks.Infrastructure.Commands.Base;
using GameOfFrameworks.Models.Temporary;
using GameOfFrameworks.ViewModels.ArmoryUserControlsViewModels;

namespace GameOfFrameworks.Infrastructure.Commands.Armory
{
    public class UpdateMerchantViewModelCommand : Command
    {
        public MerchantControlViewModel ViewModel { get; set; }
        public UpdateMerchantViewModelCommand(MerchantControlViewModel merchantControlViewModel) => ViewModel = merchantControlViewModel;
        public override bool CanExecute(object parameter)
        {
            if (ArmoryTemporaryData.IsEquipmentViewModelChanged)
            {
                ArmoryTemporaryData.IsEquipmentViewModelChanged = false;
                return true;
            }
            else return false;
        }
        public override void Execute(object parameter)
        {
            ViewModel.RefreshEquipmentView();
        }
    }
}
