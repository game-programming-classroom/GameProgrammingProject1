using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterObject : MonoBehaviour
{
    protected Command firstCommand = new CommandMove(0,0);
    protected Command lastCommand = new CommandMove(0,0);
    protected bool isRelpaying = false;
    
    public void setIsReplaying(bool boolIsplaying)
    {
        this.isRelpaying = boolIsplaying;
    }

    public Command getFirstCommand()
    {
        return this.firstCommand;
    }
    public void setFirstCommand(Command command)
    {
        this.firstCommand = command;
    }

    public Command getLastCommand()
    {
        return this.lastCommand;
    }
    public void setLastCommand(Command command)
    {
        this.lastCommand = command;
    }
}
