using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEntityBase : MonoBehaviour
{
    protected int m_entityID;
    protected string m_entityName;

    public int EntityID { get { return m_entityID;} }
    public string EntityName { get { return m_entityName;} }

    public abstract void Init();
    public abstract void Dispose();
}
