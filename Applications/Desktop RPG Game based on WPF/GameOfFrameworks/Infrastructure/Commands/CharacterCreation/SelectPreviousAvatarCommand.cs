﻿using GameOfFrameworks.Infrastructure.Commands.Base;

namespace GameOfFrameworks.Infrastructure.Commands.CharacterCreation
{
    public class SelectPreviousAvatarCommand : Command
    {
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter)
        {

        }
    }
}
