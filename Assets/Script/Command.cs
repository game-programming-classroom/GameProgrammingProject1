using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    private Command nextCommand = null;
    private Command beforeCommand = null;

    public virtual void finalize()
    {
        nextCommand = null;
        beforeCommand = null;
    }

    public virtual void execute(CharacterObject character)
    {
    }

    public virtual void undo(CharacterObject character)
    {
    }
    
    public abstract Command deepCopy();

    public virtual void setNextCommand(Command command)
    {
        this.nextCommand = command;
    }
    
    public virtual Command getNextCommand()
    {
        return this.nextCommand;
    }
    
    public virtual void setBeforeCommand(Command command)
    {
        this.beforeCommand = command;
    }
    
    public virtual Command getBeforeCommand()
    {
        return this.beforeCommand;
    }
    public virtual void finalizeAll()
    {
        finalize();
        if(nextCommand!=null) nextCommand.finalizeAll();
    }
}
