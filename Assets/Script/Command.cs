using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public virtual void finalize()
    {
    }

    public virtual void execute(CharacterObject character)
    {
    }

    public virtual void undo(CharacterObject character)
    {
    }
    
    public abstract Command deepCopy();
}
