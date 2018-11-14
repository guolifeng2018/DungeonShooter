using UnityEngine;

public abstract class MonoSingletonBase<T> : MonoMgrBase
    where T : MonoMgrBase
{
    private static T m_instance;

    public static T GetInstance()
    {
        if (m_instance == null)
        {
            GameObject gameObject = new GameObject(typeof(T).ToString());
            DontDestroyOnLoad(gameObject);
            gameObject.transform.parent = MonoSingletonManager.GetInstance().Root;
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = Vector3.one;
            m_instance = gameObject.AddComponent(typeof (T)) as T;
        }
        return m_instance;
    }
}
