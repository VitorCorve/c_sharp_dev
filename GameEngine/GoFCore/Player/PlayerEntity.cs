﻿using System;
using GameEngine.Player.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.EquipmentManagement;
using GameEngine.CombatEngine.Interfaces;
using GameEngine.CombatEngine.Actions;
using GameEngine.Player.ConditionResources;
using GameEngine.Player.PlayerConditions;

namespace GameEngine.CombatEngine
{
    public class PlayerEntity : IReceiveDamage, IReceiveHeal, IOutOfControl
    {
        public delegate void NotifyMaster(string message);
        public event NotifyMaster LogDotDamage;
        public Health HealthPoints { get; set; }
        public Mana ManaPoints { get; set; }
        public Energy EnergyPoints { get; set; }
        public int AttackPower { get; set; }
        public Armor ArmorPoints { get; set; }
        public double CriticalHitChance { get; set; }
        public double DodgeChance { get; set; }
        public double BlockChance { get; set; }
        public double ParryChange { get; set; }
        public double ResistChance { get; set; }
        public PlayerControl OutOfControl { get; set; } = new PlayerControl();
        public void ReceiveDamage(int incomingDamage)
        {
            HealthPoints.Value -= incomingDamage;
        }

        public void ReceiveHeal(int healAmount)
        {
            HealthPoints.Value += healAmount;
        }

        public void IncreaseValue(IValueType valueType, int value)
        {
            switch (valueType)
            {
                case Armor:
                    ArmorPoints.Value += value;
                    return;
                default:
                    break;
            }
        }

        public void DecreaseValue(IValueType valueType, int value)
        {
            switch (valueType)
            {
                case Armor:
                    ArmorPoints.Value -= value;
                    return;
                default:
                    break;
            }
        }

        public void ReduceResource(ISkill skill)
        {
            switch (skill.ResourceType)
            {
                case Mana:
                    ManaPoints.Value -= skill.Cost;
                    return;
                case Energy:
                    EnergyPoints.Value -= skill.Cost;
                    return;
                default:
                    break;
            }
        }

        public void LoseControl()
        {
            OutOfControl.Value = true;
        }

        public void ReturnControl()
        {
            OutOfControl.Value = false;
        }

        public void ReceiveDamgeOverTime(ISkill skill, int incomingDamage)
        {
            LogDotDamage($"{skill.SkillName} deals {incomingDamage} damage");
            HealthPoints.Value -= incomingDamage;
        }
    }
}
