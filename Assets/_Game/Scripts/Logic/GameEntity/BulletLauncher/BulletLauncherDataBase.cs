using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletLauncherDataBase
{
    public EBulletLauncherType m_launcherType;

    /// <summary>
    /// 子弹id
    /// </summary>
    public int m_bulletId = 0;

    public BulletLauncherDataBase(EBulletLauncherType type)
    {
        m_launcherType = type;
    }

    public static BulletLauncherDataBase CreateBulletLauncherData(EBulletLauncherType type)
    {
        BulletLauncherDataBase data = null;
        switch (type)
        {
            case EBulletLauncherType.SingleBullet:
                data = new SingleBulletLauncherData();
                break;
            case EBulletLauncherType.Laser:
                break;
        }

        return data;
    }
}
