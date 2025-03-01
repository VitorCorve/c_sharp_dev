﻿using GameEngine.CharacterCreationMaster.Services;
using GameEngine.CombatEngine.Interfaces;
using GameEngine.Player;
using GameOfFrameworks.Models.UISkillsCollection.Player.Interfaces;
using GameOfFrameworks.Models.UISkillsCollection.Player.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GameOfFrameworks.Models.UISkillsCollection.Player
{
    public class SkillViewBuilder : ISkillViewBuilder
    {
        public List<ISkillView> SkillCollection { get; private set; } = new ();
        public List<ISkill> PlayerSkillList { get; set; }
        public SPECIALIZATION PlayerSpecialization { get; private set; }
        public SkillViewBuilder(PlayerModelData playerModel)
        {
            var skillListBuilder = new CharacterCreationSkillListBuilder();
            PlayerSkillList = skillListBuilder.Build(playerModel);
            PlayerSpecialization = playerModel.Specialization;
            FillDefaultCollection();
        }
        public List<ISkillView> BuildList()
        {
            var skillList = new List<ISkillView>();
            foreach (var skillFromPlayerSkillList in PlayerSkillList)
            {
                foreach (var skillFromCollection in SkillCollection)
                    if (skillFromPlayerSkillList.GetType() == skillFromCollection.Skill.GetType())
                        skillList.Add(skillFromCollection);
            }
            return skillList;
        }
        public ObservableCollection<ISkillView> BuildObservableCollection()
        {
            var skillList = new ObservableCollection<ISkillView>();
            foreach (var skillFromPlayerSkillList in PlayerSkillList)
            {
                foreach (var skillFromCollection in SkillCollection)
                    if (skillFromPlayerSkillList.GetType() == skillFromCollection.Skill.GetType())
                    {
                        skillFromCollection.Skill.SkillLevel = skillFromPlayerSkillList.SkillLevel;
                        skillList.Add(skillFromCollection);
                    }
            }
            return skillList;
        }
        private void FillDefaultCollection()
        {
            switch (PlayerSpecialization)
            {
                case SPECIALIZATION.Rogue:
                    BuildDefaultRogueSkillViewList();
                    return;
                case SPECIALIZATION.Mage:
                    BuildDefaultMageSkillViewList();
                    return;
                default:
                    BuildDefaultWarriorSkillViewList();
                    return;
            }
        }
        private void BuildDefaultWarriorSkillViewList()
        {
            var warriorSkillViewListBuilder = new WarriorSkillViewListBuilder();
            SkillCollection = warriorSkillViewListBuilder.Get();
        }
        private void BuildDefaultRogueSkillViewList()
        {
            var rogueSkilllViewListBuilder = new RogueSkillViewListBuilder();
            SkillCollection = rogueSkilllViewListBuilder.Get();
        }
        private void BuildDefaultMageSkillViewList()
        {
            var mageSkilllViewListBuilder = new MageSkillViewListBuilder();
            SkillCollection = mageSkilllViewListBuilder.Get();
        }
        public void ValidateAvailableSkillList()
        {
            if (PlayerSkillList.Count == 0) return;

            foreach (var skill in PlayerSkillList)
            {
                foreach (var availableSkill in SkillCollection)
                {
                    if (availableSkill.Skill.SkillName == skill.SkillName)
                        availableSkill.Skill.SkillLevel = skill.SkillLevel;
                }
            }
        }
    }
}
