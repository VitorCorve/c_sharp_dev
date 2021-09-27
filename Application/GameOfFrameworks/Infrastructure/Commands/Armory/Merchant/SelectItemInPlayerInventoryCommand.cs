﻿using GameOfFrameworks.Models.Armory.EquipmentControl;
using GameOfFrameworks.ViewModels.ArmoryUserControlsViewModels;
using System;
using System.Windows.Input;

namespace GameOfFrameworks.Infrastructure.Commands.Armory.Merchant
{
    public class SelectItemInPlayerInventoryCommand : ICommand
    {
        private MerchantControlViewModel ViewModel { get; }
        public SelectItemInPlayerInventoryCommand(MerchantControlViewModel merchantControlViewModel) => ViewModel = merchantControlViewModel;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            var item = (EquipmentUserInterfaceViewTemplate)parameter;
            ViewModel.PlayerInventorySelect = item;
        }
    }
}
