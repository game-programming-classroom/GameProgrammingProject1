using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : InputHandler
{
    private Command commandUp = null;
    private Command commandLeft = null;
    private Command commandRight = null;
    private Command commandDown = null;
    private Command commandZ = null;
    private Command commandR = null;
    private Command commandSpace = null;

    public PlayerInputHandler(
        Command commandUp,
        Command commandLeft,
        Command commandRight,
        Command commandDown,
        Command commandZ,
        Command commandR,
        Command commandSpace
    ){
        this.commandUp = commandUp;
        this.commandLeft = commandLeft;
        this.commandRight = commandRight;
        this.commandDown = commandDown;
        this.commandZ = commandZ;
        this.commandR = commandR;
        this.commandSpace = commandSpace;
    }

    public override Command handleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            return commandUp.deepCopy();
        if(Input.GetKeyDown(KeyCode.LeftArrow))
            return commandLeft.deepCopy();
        if(Input.GetKeyDown(KeyCode.RightArrow))
            return commandRight.deepCopy();
        if(Input.GetKeyDown(KeyCode.DownArrow))
            return commandDown.deepCopy();
        if(Input.GetKeyDown(KeyCode.Z))
            return commandZ.deepCopy();
        if(Input.GetKeyDown(KeyCode.R))
            return commandR.deepCopy();
        if(Input.GetKeyDown(KeyCode.Space))
            return commandSpace.deepCopy();

        return null;
    }
}
