﻿using GameEngine.NPC.Interfaces.SpecializationArchetypes;
using GameEngine.Player;

namespace GameEngine.NPC.Specializations.Vampires
{
    public class EntityModel_Nightlord : IVampire
    {
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Intellect { get; set; }
        public int Agility { get; set; }
        public int Endurance { get; set; }
        public int WeaponDamageValue { get; set; }
        public int ArmorValue { get; set; }
        public SPECIALIZATION Specialization { get; private set; }
        public NPC_NAME Name { get; private set; }
        public EntityModel_Nightlord()
        {
            Specialization = SPECIALIZATION.Vampire;
            Name = NPC_NAME.Ghoul;

            Strength = 7;
            Stamina = 6;
            Intellect = 2;
            Agility = 3;
            Endurance = 3;
        }
    }
}
