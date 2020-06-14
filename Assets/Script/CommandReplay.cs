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
            //ここにスタート位置に戻るための処理を書く
            if(commandPointer.getBeforeCommand() != null){
            
            }else{
                break;
            }
        }

        await Task.Delay(200);

        while(true)
        {
            await Task.Delay(300);
            //ここにリプレイを再生するための処理を書く
            if(commandPointer != null){

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
