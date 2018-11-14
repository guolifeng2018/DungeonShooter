using UnityEngine;
using System.Collections;

namespace Common.Singleton
{
    public abstract class SingletonBase<T> : MgrBase
        where T : SingletonBase<T>, new()
    {
        private static T m_instance = null;

        public static T GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new T();
                m_instance.Init();
                m_instance.RegisterEvent();
            }
            return m_instance;
        }
    }
}

