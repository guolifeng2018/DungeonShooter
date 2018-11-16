using UnityEngine;

public class SingleBulletLauncher : BulletLauncherBase
{
    protected SingleBulletLauncherData m_data;
    
    public SingleBulletLauncher(BulletLauncherDataBase data)
        : base(EBulletLauncherType.SingleBullet)
    {
        m_data = data as SingleBulletLauncherData;
        if (m_data == null)
        {
            Debug.LogError("SingleBulletLauncherData parse error!!");
        }
    }

    public override void Fire()
    {
        
    }
}