using System.Collections.Generic;
using UnityEngine;
using Common.Singleton;

public class MonoSingletonManager : SingletonBase<MonoSingletonManager>
{
    private GameObject m_monoMgrRoot;

    public Transform Root
    {
        get
        {
            if (m_monoMgrRoot != null)
            {
                return m_monoMgrRoot.transform;
            }
            return null;
        }
    }

    private List<MonoMgrBase> m_monoList; 

    public override void Destroy()
    {
        if (m_monoMgrRoot != null)
        {
            int childCount = m_monoMgrRoot.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                GameObject child = m_monoMgrRoot.transform.GetChild(i).gameObject;
                GameObject.Destroy(child);
            }
            GameObject.Destroy(m_monoMgrRoot);
        }
        m_monoList.Clear();
        m_monoList = null;
    }

    public override void Init()
    {
        if (m_monoMgrRoot == null)
        {
            m_monoMgrRoot = new GameObject("MonoSingletonRoot");
            m_monoMgrRoot.transform.position = Vector3.zero;
            m_monoMgrRoot.transform.rotation = Quaternion.identity;
            m_monoMgrRoot.transform.localScale = Vector3.one;
        }
        m_monoList = new List<MonoMgrBase>();
    }
}
