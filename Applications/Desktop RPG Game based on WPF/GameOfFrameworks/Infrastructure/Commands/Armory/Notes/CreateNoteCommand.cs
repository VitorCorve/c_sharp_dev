﻿using GameOfFrameworks.Infrastructure.Commands.Base;

namespace GameOfFrameworks.Infrastructure.Commands.Armory.Notes
{
    public class CreateNoteCommand : Command
    {
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter)
        {
            // application logic
        }
    }
}
