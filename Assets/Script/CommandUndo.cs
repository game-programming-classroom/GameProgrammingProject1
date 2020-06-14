using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandUndo : Command
{
    public CommandUndo()
    {

    }
    public override Command deepCopy()
    {
        CommandUndo copyCommand = new CommandUndo();
        return copyCommand;
    }

    public override void execute(CharacterObject character)
    {
        Command command = character.getLastCommand();
        if(command != null && command.getBeforeCommand() != null)
        {
            character.setLastCommand(command.getBeforeCommand());
            command.undo(character);
        }
    }
    
    public override void undo(CharacterObject character)
    {
    }
}
