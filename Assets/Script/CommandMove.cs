using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandMove : Command
{
    private float moveDistX;
    private float moveDistY;

    public override void finalize()
    {
        this.moveDistX = 0;
        this.moveDistY = 0;
    }

    public CommandMove(float x, float y)
    {
        this.moveDistX = x;
        this.moveDistY = y;
    }
    
    public override Command deepCopy()
    {
        CommandMove copyCommand = new CommandMove(this.moveDistX , this.moveDistY);
        return copyCommand;
    }

    public override void execute(CharacterObject character)
    {   
        Vector3 offset = new Vector3(moveDistX,moveDistY,0);
        Vector3 movePosition = character.transform.position + offset;

        if(movePosition.x > Definition.MAX_FIELD_X || movePosition.x < Definition.MIN_FIELD_X) offset.x = 0;
        if(movePosition.y > Definition.MAX_FIELD_Y || movePosition.y < Definition.MIN_FIELD_Y) offset.y = 0;

        character.transform.Translate(offset);
    }
    public virtual float getMoveDistX()
    {
        return this.moveDistX;
    }
    
    public virtual float getMoveDistY()
    {
        return this.moveDistY;
    }
}
