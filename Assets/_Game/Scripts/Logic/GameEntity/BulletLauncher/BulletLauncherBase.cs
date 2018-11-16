using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletLauncherBase
{
    protected EBulletLauncherType m_launcherType;
    
    public EBulletLauncherType LauncherType
    {
        get { return m_launcherType; }
    }

    public BulletLauncherBase(EBulletLauncherType type)
    {
        m_launcherType = type;
    }
    
    public abstract void Fire();

    public static BulletLauncherBase CreateBulletLauncherBase(BulletLauncherDataBase data)
    {
        BulletLauncherBase launcher = null;
        switch (data.m_launcherType)
        {
                case EBulletLauncherType.SingleBullet:
                    launcher = new SingleBulletLauncher(data);
                    break;
                case EBulletLauncherType.Laser:
                    break;
        }

        if (launcher == null)
        {
            Debug.LogError("Launcher is null :   " + data.m_launcherType);
        }
        return null;
    }
}
