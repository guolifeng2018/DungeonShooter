using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletLauncherDataBase
{
    public EBulletLauncherType m_launcherType;

    public BulletLauncherDataBase(EBulletLauncherType type)
    {
        m_launcherType = type;
    }
}
