﻿using GameEngine.Abstract;
using GameEngine.Locations;

namespace GameEngine.Player
{
    public class PlayerModelData : IPlayerModelData
    {
        public string Name { get; private set; }
        public SPECIALIZATION Specialization { get; private set; }
        public GENDER Gender { get; set; }
        public int Level { get; set; }
        public LAND CurrentLand { get; set; }
        public TOWN CurrentTown { get; set; }
        public int Experience
        {
            get { return _Experience; }
            set { _Experience = ConvertValue(value); }
        }
        private int _Experience;
        public int MaxExperience { get; set; }
        public PLAYER_GRADE PlayerGrade
        {
            get { return SetPlayerGrade(Level); }
            set { _PlayerGrade = value; }
        }
        private PLAYER_GRADE _PlayerGrade;
        public PlayerConsumablesData PlayerConsumablesData { get; set; }
        public PlayerModelData(PlayerSpecialization player, GENDER gender, string name, int level, int money)
        {
            PlayerConsumablesData = new PlayerConsumablesData(money);
            PlayerGrade = PLAYER_GRADE.Novice;
            Name = name;
            Specialization = player.Specialization;
            Gender = gender;
            Level = level;
            MaxExperience = 36 + (Level * 6);
        }
        private PLAYER_GRADE SetPlayerGrade(int level)
        {
            switch (level)
            {
                case < 6:
                    return PLAYER_GRADE.Novice;
                case < 11:
                    return PLAYER_GRADE.Advanced;
                case < 16:
                    return PLAYER_GRADE.Adept;
                case < 21:
                    return PLAYER_GRADE.Expert;
                case < 26:
                    return PLAYER_GRADE.Master;
                case < 31:
                    return PLAYER_GRADE.Legend;
                default:
                    return PLAYER_GRADE.Legend;
            }
        }
        private int ConvertValue(int value)
        {
            if ((value + Experience) > MaxExperience)
                return (value + Experience) - MaxExperience;
            else
                return value;
        }
    }
}
