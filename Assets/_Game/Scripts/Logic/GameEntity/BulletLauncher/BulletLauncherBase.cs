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

    public abstract bool IsFiring();

    public abstract float FireRate();
    
    public abstract void Fire(Vector3 direction);

    public static BulletLauncherBase CreateBulletLauncherBase(BulletLauncherDataBase data, GameObject gameObject, BulletBase tempBullet)
    {
        BulletLauncherBase launcher = null;
        switch (data.m_launcherType)
        {
                case EBulletLauncherType.SingleBullet:
                    launcher = new SingleBulletLauncher(data, gameObject, tempBullet);
                    break;
                case EBulletLauncherType.Laser:
                    break;
        }

        if (launcher == null)
        {
            Debug.LogError("Launcher is null :   " + data.m_launcherType);
        }
        return launcher;
    }
}
