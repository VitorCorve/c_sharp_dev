﻿using GameOfFrameworks.Infrastructure.Commands.Base;
using GameOfFrameworks.Models.Armory.EquipmentControl;
using GameOfFrameworks.ViewModels.ArmoryUserControlsViewModels;

namespace GameOfFrameworks.Infrastructure.Commands.Armory.Merchant
{
    public class SellItemCommand : Command
    {
        private MerchantControlViewModel ViewModel { get; }
        public SellItemCommand(MerchantControlViewModel merchantControlViewModel) => ViewModel = merchantControlViewModel;
        public override bool CanExecute(object parameter)
        {
            if (parameter is null) return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            var item = (EquipmentUserInterfaceViewTemplate)parameter;
            ViewModel.EquipmentHandler.SellItem(item);
            ViewModel.PlayerItemsInInventoryCount = ViewModel.PlayerInventory.ItemsInInventory.Count;
            ViewModel.PlayerInventorySelect = null;
        }
    }
}
