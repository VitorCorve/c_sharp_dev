﻿using GameEngine.NPC.Interfaces;
using System.Collections.Generic;

namespace GameOfFrameworks.Models.GameEngine.NPC.Interfaces.Instruments
{
    public interface ICreateNPCList
    {
        List<INPC_Enemy> NPCList { get; }
        List<INPC_Enemy> CreateList();
    }
}
