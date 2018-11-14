using System.Collections.Generic;

namespace Common.Singleton
{
    public static class SingletonMgr
    {
        private static List<MgrBase> m_mgrList;

        public static void Init()
        {
            m_mgrList = new List<MgrBase>();
        }

        public static void Destroy()
        {
            if (m_mgrList.Count > 0)
            {
                for (int i = 0; i < m_mgrList.Count; i++)
                {
                    MgrBase mgr = m_mgrList[i];
                    mgr.UnRegisterEvent();
                    mgr.Destroy();
                }
                m_mgrList.Clear();
            }
        }
    }
}

