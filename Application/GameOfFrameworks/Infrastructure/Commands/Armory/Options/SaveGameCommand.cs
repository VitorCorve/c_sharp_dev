﻿using GameEngine.Data;
using GameEngine.Data.Interfaces;
using GameEngine.Data.Services;
using GameOfFrameworks.Infrastructure.Commands.Base;
using GameOfFrameworks.Models.Services;
using GameOfFrameworks.Models.Temporary;
using System;

namespace GameOfFrameworks.Infrastructure.Commands.Armory.Options
{
    public class SaveGameCommand : Command
    {
        private object Parameter;
        private PlayerSaveData DataToSave;
        private SaveGameService SaveService;
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter)
        {
            Parameter = parameter;
            InitializeManagers();
            PrepareSaveData();
            SetDataSaveTime();
            SaveData();
            ArmoryTemporaryData.SaveData = DataToSave;
        }
        private void InitializeManagers()
        {
            DataToSave = new PlayerSaveData();
            SaveService = new SaveGameService();
        }
        private void PrepareSaveData()
        {
            var playerSaveDataBuilder = new PlayerSaveDataBuilder();
            DataToSave = playerSaveDataBuilder.Build(
                ArmoryTemporaryData.PlayerModel,
                ArmoryTemporaryData.CurrentLocation,
                ArmoryTemporaryData.PlayerInventory,
                ArmoryTemporaryData.PlayerEquipment,
                ArmoryTemporaryData.PlayerSkills,
                ArmoryTemporaryData.PlayerAttributes,
                ShortcutsConverter.ConvertToList(ArmoryTemporaryData.SkillsShortcuts),
                ArmoryTemporaryData.CharacterEntity);
        }
        private void SetDataSaveTime()
        {
            DataToSave.Date = DateTime.Now.ToString("yy.MM.dd H:mm:ss");
            DataToSave.DateShort = DateTime.Now.ToString("yy.MM.dd");
        }
        private void SaveData() => SaveService.Save(DataToSave, (bool)Parameter);
    }
}
