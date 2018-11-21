using UnityEngine;

public class GameGunEntity : GameEntityBase
{
    public BulletBase m_tempBullet;
    
    #region Construction

    protected GameGunProps m_props;

    protected BulletLauncherBase m_bulletLauncher;

    protected GameObject m_gunNode;

    protected GameObject m_bulletNode;

    #endregion

    protected Vector3 m_direction;
    protected Vector3 m_recordSpritePosition;
    
    public override void Init()
    {
        //初始化属性
        m_props = new GameGunProps();
        m_props.m_bulletLauncherData =
            BulletLauncherDataBase.CreateBulletLauncherData(EBulletLauncherType.SingleBullet);

        m_bulletLauncher = BulletLauncherBase.CreateBulletLauncherBase(m_props.m_bulletLauncherData, gameObject, m_tempBullet);

        m_gunNode = ObjectCommon.GetChild(gameObject, "gun_sprite");
        m_recordSpritePosition = m_gunNode.transform.localPosition;

        m_bulletNode = ObjectCommon.GetChild(gameObject, "bullet_node");
    }

    public override void Dispose()
    {
        
    }

    #region UpdateDirection

    public void UpdateGunDirection(Vector2 direction, bool playerFaceToRight)
    {
        if(direction == Vector2.zero){return;}
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

    public virtual void Fire()
    {
        if(m_bulletLauncher == null) { return; }
        if (m_bulletLauncher.IsFiring()) { return;}

        Debug.Log("Fire !!!!");

        m_bulletLauncher.Fire(transform.right);

        //todo:显示枪口喷火

        //枪开始播放后坐力
        float recoilX = m_recordSpritePosition.x - m_props.m_recoil * 0.02f;
        float recoilTime = (m_bulletLauncher.FireRate() - 0.1f) *0.1f; 
        LeanTween.moveLocalX(m_gunNode, recoilX, recoilTime)
            .setEaseOutQuad().setOnComplete(() =>
            {
                float recoverTime = (m_bulletLauncher.FireRate()) * 0.8f;
                LeanTween.moveLocalX(m_gunNode, m_recordSpritePosition.x, recoverTime)
                    .setEaseLinear();
            });
    }

    #endregion
}
