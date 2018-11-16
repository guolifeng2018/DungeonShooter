using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGunEntity : GameEntityBase
{
    #region Construction

    protected GameGunProps m_props;

    protected BulletLauncherBase m_bulletLauncher;

    #endregion

    protected Vector3 m_direction;
    
    public override void Init()
    {
        //初始化属性
        m_props = new GameGunProps();

        m_bulletLauncher = BulletLauncherBase.CreateBulletLauncherBase(m_props.m_bulletLauncherData);
    }

    public override void Dispose()
    {
        
    }

    #region UpdateDirection

    public void UpdateGunDirection(Vector2 direction, bool playerFaceToRight)
    {
        Vector2 xDirPositive = Vector2.right;
        if (!playerFaceToRight)
        {
            xDirPositive *= -1f;
        }
        float angle = Vector2.Angle(xDirPositive, direction);
        float positiveFlag = direction.y < 0 ? -1f : 1f;
        m_direction = new Vector3(0f, 0f, angle * positiveFlag);
        transform.localRotation = Quaternion.Euler(m_direction);
    }

    #endregion

    #region Fire

    public void Fire()
    {
        if (m_bulletLauncher != null)
        {
            m_bulletLauncher.Fire();
        }
        
        //todo:显示枪口喷火
        
        //todo:枪开始播放后坐力
    }

    #endregion
}
