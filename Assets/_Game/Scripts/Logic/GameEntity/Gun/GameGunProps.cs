using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGunProps :MonoBehaviour
{
    /// <summary>
    /// 枪id
    /// </summary>
    public int m_gunId = 0;

    /// <summary>
    /// 枪名称
    /// </summary>
    public string m_gunName = "初版0号";

    /// <summary>
    /// 枪描述
    /// </summary>
    public string m_gunDescription = "初版零号枪，虽然还有很多瑕疵，但是尚可使用。";

    /// <summary>
    /// 子弹数
    /// </summary>
    public int m_bulletCount = 100;
    
    /// <summary>
    /// 射击速度
    /// </summary>
    public float m_fireRate = 50;

    /// <summary>
    /// 后坐力
    /// </summary>
    public float m_recoil = 5;

    /// <summary>
    /// 精准度
    /// </summary>
    public float m_precision = 0.4f;

    /// <summary>
    /// 精准范围
    /// </summary>
    public float m_precisionAngle = 60;

    /// <summary>
    /// 枪械prefab名称
    /// </summary>
    public string m_gunResName = "gun_001";

    /// <summary>
    /// 子弹名称
    /// </summary>
    public int m_bulletId = 0;
}
