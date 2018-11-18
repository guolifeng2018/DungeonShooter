using System;
using UnityEngine;
using System.Collections.Generic;

public interface IPoolItem
{
    void Init();
    void Reset();
    void Destroy();
}

public class Pool<T>
    where T : IPoolItem
{
    const int CACHEMAXCOUNT = 10;

    private List<T> m_activeItemList = new List<T>();
    private List<T> m_cacheItemList = new List<T>();
    private List<T> m_getItemsList;
    
    private int m_cacheMaxCount;    //允许存在最大个数

    void Awake() { }

    #region 初始化

    public void Init()
    {
        Init(CACHEMAXCOUNT);
    }

    public void Init(int cacheMaxCount)
    {
        m_cacheMaxCount = cacheMaxCount;
    }
    #endregion

    #region 取一个实例

    public T GetAnItem()
    {
        if (m_cacheItemList.Count > 0)
        {
            T item = m_cacheItemList[0];
            m_cacheItemList.RemoveAt(0);
            m_activeItemList.Add(item);
            item.Init();
            return item;
        }
        else
        {
            T item = Activator.CreateInstance<T>();
            if (item != null)
            {
                item.Init();
            }
            return item;
        }
    }
    #endregion

    #region 取几个实例

    public List<T> GetActiveItems(int count)
    {
        if (count <= 0) { return null; }
        if (m_getItemsList == null)
        {
            m_getItemsList = new List<T>();
        }
        for (int i = 0; i < count; i++)
        {
            T item = GetAnItem();
            m_getItemsList.Add(item);
        }
        return m_getItemsList;
    }
    #endregion

    #region 删除一个实例

    public void DestroyAnItem(T item)
    {
        if (item == null) { return; }
        if (m_activeItemList.Contains(item))
        {
            item.Reset();
            m_activeItemList.Remove(item);
            m_cacheItemList.Add(item);
        }
        LimitCacheListCount();
    }
    #endregion

    #region 清空池到CacheList
    public void ClearPool()
    {
        if (m_activeItemList.Count > 0)
        {
            for (int i = 0; i < m_activeItemList.Count; i++)
            {
                T item = m_activeItemList[m_activeItemList.Count - 1];
                item.Reset();
                m_cacheItemList.Add(item);
            }
        }
        LimitCacheListCount();
    }
    #endregion

    #region 删除池

    public void DestroyPool()
    {
        for (int i = 0; i < m_activeItemList.Count; i++)
        {
            m_activeItemList[i] = default(T);
        }
        m_activeItemList.Clear();

        for (int i = 0; i < m_cacheItemList.Count; i++)
        {
            m_cacheItemList[i] = default(T);
        }
        m_cacheItemList.Clear();
    }
    #endregion

    private void LimitCacheListCount()
    {
        T item = default(T);
        if (m_cacheItemList.Count > m_cacheMaxCount)
        {
            int needDestroyCount = m_cacheItemList.Count - m_cacheMaxCount;
            for (int i = 0; i < needDestroyCount; i++)
            {
                item = m_cacheItemList[m_cacheItemList.Count - 1];
                item.Destroy();
                m_cacheItemList.Remove(item);
            }
        }
    }
}
