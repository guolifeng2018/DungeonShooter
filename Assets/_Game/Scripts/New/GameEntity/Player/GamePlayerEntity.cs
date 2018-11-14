using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GamePlayerEntity : GameEntityBase
{

    #region Move

    public abstract void MoveTo(Vector2 point);
    public abstract void Move(Vector2 direction);

    #endregion

    #region Firing

    public abstract void Firing();

    #endregion

    #region SwitchGun
    
    public virtual void SwitchGun() { }

    #endregion

    #region ActionSkill

    public virtual void ActionSkill() { }

    #endregion

}
