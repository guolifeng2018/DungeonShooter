using UnityEngine;
using System.Collections;

public abstract class MgrBase
{
    public abstract void Init();
    public abstract void Destroy();
    public virtual void RegisterEvent() { }
    public virtual void UnRegisterEvent() { }
}
