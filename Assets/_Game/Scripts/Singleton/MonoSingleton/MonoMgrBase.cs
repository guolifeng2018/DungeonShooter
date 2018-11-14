using UnityEngine;
using System.Collections;

public abstract class MonoMgrBase : MonoBehaviour
{
    protected Transform Root { get { return gameObject.transform; } }

    void Awake()
    {
        MonoAwake();
        RegisterEvent();
    }
       
	void Start () { MonoStart(); }

    void OnDestroy()
    {
        UnRegisterEvent();
        MonoOnDestroy();
    }

    protected abstract void MonoAwake();
    protected abstract void MonoStart();
    protected abstract void MonoOnDestroy();
    protected virtual void RegisterEvent() { }
    protected virtual void UnRegisterEvent() { }
}
