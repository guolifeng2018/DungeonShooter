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
    public float m_fireRate = 0.08f;

    /// <summary>
    /// 精准度
    /// </summary>
    public float m_precision = 0.4f;

    /// <summary>
    /// 精准范围
    /// </summary>
    public float m_precisionAngle = 60;

    /// <summary>
    /// 子弹生存时间
    /// </summary>
    public float m_lifeTime = 0.5f;

    /// <summary>
    /// 子弹速度
    /// </summary>
    public float m_bulletSpeed = 8f;

    /// <summary>
    /// 子弹发射动画
    /// </summary>
    public string m_fireAnimName = "bullet_001_fire";

    /// <summary>
    /// 子弹碰撞后发生动画
    /// </summary>
    public string m_fadeAnimName = "bullet_001_fade";
    
    /// <summary>
    /// 子弹死亡时间
    /// </summary>
    public float m_fadeBulletTime = 0.25f;

    public SingleBulletLauncherData()
        :base(EBulletLauncherType.SingleBullet)
    {
    }
}