using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRedo : Command
{
    public CommandRedo()
    {

    }
    public override Command deepCopy()
    {
        CommandRedo copyCommand = new CommandRedo();
        return copyCommand;
    }

    public override void execute(CharacterObject character)
    {
        Command command = character.getLastCommand();
        if(command != null && command.getNextCommand() != null)
        {
            //ここにRedoのための処理を書く
        }
    }
    
    public override void undo(CharacterObject character)
    {
    }
}
