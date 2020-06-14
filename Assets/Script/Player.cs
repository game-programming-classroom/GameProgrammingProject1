using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterObject
{
    private PlayerInputHandler inputHandler;

    void Start()
    {
        inputHandler = new PlayerInputHandler(
            new CommandMove(0,Definition.ONE_BLOCK_DIST),
            new CommandMove(-1 * Definition.ONE_BLOCK_DIST,0),
            new CommandMove(Definition.ONE_BLOCK_DIST,0),
            new CommandMove(0,-1 * Definition.ONE_BLOCK_DIST),
            new CommandUndo(),
            new CommandRedo(),
            new CommandReplay()
        );
    }

    void Update()
    {
        Command command = inputHandler.handleInput();
        if(command != null){
            if(isRelpaying) return;
            command.execute(this);
            if(command is CommandUndo == true || command is CommandRedo == true || command is CommandReplay == true )
                return;
            if(command.getNextCommand() != null) command.finalizeAll();
            // Undo,Redoでなければ一つ前と新しいもののnextとbeforeを更新させておく
            //inputHandlerでコマンドの生成時に双方向リストを作成しても良い
            lastCommand.setNextCommand(command);
            command.setBeforeCommand(lastCommand);
            lastCommand = command;
        }
    }

}
