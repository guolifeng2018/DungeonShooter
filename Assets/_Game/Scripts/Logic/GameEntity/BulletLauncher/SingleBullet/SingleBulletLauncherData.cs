using System;
using UnityEngine;

public class SingleBulletLauncherData : BulletLauncherDataBase
{
    /// <summary>
    /// 子弹数
    /// </summary>
    public int m_bulletCount = 100;
    
    /// <summary>
    /// 射击速度
    /// </summary>
    public float m_fireRate = 50;

    /// <summary>
    /// 精准度
    /// </summary>
    public float m_precision = 0.4f;

    /// <summary>
    /// 精准范围
    /// </summary>
    public float m_precisionAngle = 60;

    public SingleBulletLauncherData()
        :base(EBulletLauncherType.SingleBullet)
    {
    }
}