﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGunProps :MonoBehaviour
{
    /// <summary>
    /// 枪id
    /// </summary>
    public int m_gunId = 0;

    /// <summary>-
    /// 枪名称
    /// </summary>
    public string m_gunName = "初版0号";

    /// <summary>
    /// 枪描述
    /// </summary>
    public string m_gunDescription = "初版零号枪，虽然还有很多瑕疵，但是尚可使用。";

    /// <summary>
    /// 后坐力
    /// </summary>
    public float m_recoil = 5;
    
    /// <summary>
    /// 枪发射器属性
    /// </summary>
    public BulletLauncherDataBase m_bulletLauncherData;
    
    /// <summary>
    /// 枪械prefab名称
    /// </summary>
    public string m_gunResName = "gun_001";
}
