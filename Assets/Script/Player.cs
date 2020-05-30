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
            new CommandMove(0,-1 * Definition.ONE_BLOCK_DIST)
        );
    }

    void Update()
    {
        Command command = inputHandler.handleInput();
        if(command != null){
            command.execute(this);
        }
    }

}
