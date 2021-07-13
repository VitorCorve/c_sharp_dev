﻿using GameEngine.CombatEngine;
using GameEngine.CombatEngine.ActionTypes;
using GameEngine.CombatEngine.Interfaces;
using GameEngine.CombatEngine.Services;
using GameEngine.Player.ConditionResources;
using GameEngine.Player.DefenseResources;
using System.Timers;

namespace GameEngine.SpecializationMechanics.Rogue.Skills
{
    public class DissapearIntoTheShadows : IBuffSkill
    {
        public string SkillName { get; private set; }
        public int SkillLevel { get; private set; }
        public Timer CoolDownTimer { get; private set; }
        public int Duration { get; set; }
        public int CoolDownDuration { get; set; }
        public int CoolDown { get; set; }
        public bool ReadyToUse { get; private set; }
        public bool SkillAffectedOnEnemy { get; private set; }
        public double CriticalChance { get; private set; }
        public int Cost { get; private set; }
        public int SkillDamageValue { get; private set; }
        public int AmountOfValue { get; private set; }
        public IResourceType ResourceType { get; set; } = new Mana();
        public IAttackType Type { get; set; } = new Magic();
        public IResourceType ValueType { get; set; } = new Dodge();

        public void Use(int dealerAttackPower, PlayerEntity target)
        {
            AmountOfValue = 100;

            var buffService = new BuffsService(this, target);

            buffService.Activate();

            var coolDown = new CoolDownService(this);
            coolDown.Activate();
        }

        public int RandomizeDamageValue(int damageValue)
        {
            return damageValue;
        }

        public DissapearIntoTheShadows(int skillLevel)
        {
            SkillName = "Dissapear into the Shadows";
            SkillLevel = skillLevel;
            SkillDamageValue = SkillLevel * 5;
            Cost = SkillLevel * 3;
            Duration = 5;
            CoolDownDuration = 20;
        }
    }
}
