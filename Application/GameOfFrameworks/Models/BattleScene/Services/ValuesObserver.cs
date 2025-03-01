﻿using GameOfFrameworks.Models.BattleScene.Interfaces;
using GameOfFrameworks.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GameOfFrameworks.Models.BattleScene.Services
{
    public class ValuesObserver : IValuesObserver
    {
        public ICharacterBarModel PlayerBar { get; private set; }

        public ICharacterBarModel NPCBar { get; private set; }

        public Timer Timer { get; private set; }
        public ValuesObserver(ICharacterBarModel playerBarView, ICharacterBarModel npcBarView)
        {
            PlayerBar = playerBarView;
            NPCBar = npcBarView;
            Timer = new Timer(10);
            Timer.Elapsed += Update;
            Start();
        }
        public void Update(object sender, ElapsedEventArgs e)
        {
            PlayerBar.UpdateValues();
            NPCBar.UpdateValues();
        }
        public void Start() => Timer.Start();
        public void Stop() => Timer.Stop();
    }
}
