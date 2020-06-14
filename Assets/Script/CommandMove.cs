using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandMove : Command
{
    private float moveDistX;
    private float moveDistY;
    private Vector3 offsetBefore;

    public override void finalize()
    {
        this.moveDistX = 0;
        this.moveDistY = 0;
        this.offsetBefore = Vector3.zero;
    }

    public CommandMove(float x, float y)
    {
        this.moveDistX = x;
        this.moveDistY = y;
    }
    
    public CommandMove(CommandMove cm)
    {
        this.moveDistX = cm.getMoveDistX();
        this.moveDistY = cm.getMoveDistY();
        this.offsetBefore = cm.getOffsetBefore();
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

        offsetBefore = offset;
        character.transform.Translate(offset);
    }
    
    public override void undo(CharacterObject character)
    {
        character.transform.Translate((-1) * offsetBefore);
    }

    public virtual float getMoveDistX()
    {
        return this.moveDistX;
    }
    
    public virtual float getMoveDistY()
    {
        return this.moveDistY;
    }
    
    public virtual Vector3 getOffsetBefore()
    {
        return this.offsetBefore;
    }
}
