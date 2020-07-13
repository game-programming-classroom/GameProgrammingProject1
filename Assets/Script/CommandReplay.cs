using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class CommandReplay : Command
{
    public CommandReplay()
    {
    }

    public override Command deepCopy()
    {
        CommandReplay copyCommand = new CommandReplay();
        return copyCommand;
    }

    public override async void execute(CharacterObject character)
    {   
        character.setIsReplaying(true);
        Command lastCommand = character.getLastCommand();
        Command commandPointer = lastCommand;
        while(true)
        {
            await Task.Delay(20);
            commandPointer.undo(character);
            if(commandPointer.getBeforeCommand() != null){
                commandPointer = commandPointer.getBeforeCommand();
                character.setLastCommand(commandPointer);
            }else{
                break;
            }
        }

        await Task.Delay(200);

        while(true)
        {
            await Task.Delay(300);
            commandPointer.execute(character);
            commandPointer = commandPointer.getNextCommand();
            if(commandPointer != null){
                character.setLastCommand(commandPointer);
            }else{
                break;
            }
        }
        character.setIsReplaying(false);
    }

    public override void undo(CharacterObject character)
    {
    }
}
