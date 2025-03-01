﻿using GameOfFrameworks.Infrastructure.Commands.Base;
using GameOfFrameworks.ViewModels.ArmoryUserControlsViewModels;

namespace GameOfFrameworks.Infrastructure.Commands.Armory.Merchant
{
    public class RepairAllItemsCommand : Command
    {
        private MerchantControlViewModel ViewModel { get; }
        public RepairAllItemsCommand(MerchantControlViewModel merchantControlViewModel) => ViewModel = merchantControlViewModel;
        public override bool CanExecute(object parameter)
        {
            foreach (var item in ViewModel.PlayerWearedEquipment.ItemsList)
            {
                if (item.ItemDurability.Value < 100) return true;
            }
            foreach (var item in ViewModel.PlayerInventory.ItemsInInventory)
            {
                if (item.ItemDurability.Value < 100) return true;
            }
            return false;
        }
        public override void Execute(object parameter)
        {
            ViewModel.EquipmentHandler.RepairAllItems();

            if (ViewModel.PlayerInventorySelect != null)
            {
                ViewModel.PlayerInventorySelect.Durability = 100;
            }
            ViewModel.OnPropertyChanged(nameof(ViewModel.PlayerInventorySelect));
            ViewModel.ShowInventory();
        }
    }
}
