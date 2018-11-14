using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerProps
{
    /// <summary>
    /// 移动速度
    /// </summary>
    public float m_speed = 1.5f;

    /// <summary>
    /// 允许携带枪个数
    /// </summary>
    public int m_remindGunCount = 2;

    /// <summary>
    /// 生命
    /// </summary>
    public int m_hp = 6;

    /// <summary>
    /// 生命槽位，当此槽位满时增加生命值
    /// </summary>
    public int m_cacheHp = 6;
}
