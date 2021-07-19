﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.NPC.Interfaces.Services
{
    public interface INPC_Builder
    {
        INPC_Enemy Build(INPC_Enemy npcArchetype);
    }
}
