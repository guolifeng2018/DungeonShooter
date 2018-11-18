using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerEntity : GameEntityBase
{
#if UNITY_EDITOR || UNITY_EDITOR_64 || UNITY_EDITOR_WIN
    public GameGunEntity m_testGunEntity;
#endif

    #region Construction

    /// <summary>
    /// 属性
    /// </summary>
    protected GamePlayerProps m_props;
    
    /// <summary>
    /// 动画
    /// </summary>
    protected GamePlayerAnim m_anim;
    
    /// <summary>
    /// 枪械背包
    /// </summary>
    protected GameGunEntity[] m_gun;
    protected int m_curGunIndex;

    /// <summary>
    /// 攻击对象检测
    /// </summary>
    protected GameEnemyDetector m_enemyDetector;

    #endregion
    
    protected Vector2 m_direction;
    protected bool m_beHurt;
    protected bool m_faceToRight = true;

    protected GameGunEntity CurrentGun
    {
        get { return m_gun[m_curGunIndex]; }
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        //初始化属性
        m_props = new GamePlayerProps();
        
        //初始化动画
        m_anim = new GamePlayerAnim();
        m_anim.Init(gameObject);
        
        //初始化枪
        m_gun = new GameGunEntity[m_props.m_remindGunCount];
        m_curGunIndex = 0;
        
        //初始化攻击对象检测
        m_enemyDetector = new GameEnemyDetector();

        //玩家输入系统
        KeyBoardInputManager.GetInstance().AddMoveAction(Move);
        KeyBoardInputManager.GetInstance().AddFireAction(Fire);


#if UNITY_EDITOR || UNITY_EDITOR_64 || UNITY_EDITOR_WIN
        //test
        m_testGunEntity.Init();
        PicUpTheGun(m_testGunEntity);
#endif
    }

    public override void Dispose()
    {
        
    }

    private void Update()
    {
        UpdateDirection();
    }

    #region Move

    public virtual void MoveTo(Vector2 point)
    {

    }

    public virtual void Move(Vector2 direction)
    {
        if (CheckCanMove())
        {
            m_direction = direction.normalized;

            transform.position += new Vector3(direction.x, direction.y, 0f) * m_props.m_speed * Time.deltaTime;

            if (m_direction == Vector2.zero)
            {
                m_anim.PlayAnim(EPlayerAnimType.Idle);
            }
            else
            {
                m_anim.PlayAnim(EPlayerAnimType.Move);
            }
        }
    }

    private void UpdateDirection()
    {
        if(m_direction.x < 0) { m_faceToRight = false; }
        else if(m_direction.x > 0) { m_faceToRight = true; }
        transform.rotation = m_faceToRight
            ? Quaternion.Euler(Vector3.zero)
            : Quaternion.Euler(new Vector3(0f, 180f, 0f));

        if (CurrentGun != null)
        {
            CurrentGun.UpdateGunDirection(GetGunDirection(), m_faceToRight);
        }
    }

    private Vector2 GetGunDirection()
    {
        Vector2 dir = m_direction;
        GameEntityBase entity = m_enemyDetector.GetCloestTarget();
        if (entity != null)
        {
            dir = new Vector2(entity.transform.position.x - transform.position.x,
                entity.transform.position.y - transform.position.y);
        }

        return dir;
    }

    protected virtual bool CheckCanMove()
    {
        return !m_anim.IsPlaying(EPlayerAnimType.Hurt);
    }

    #endregion

    #region Fire

    public virtual void Fire()
    {
        GameGunEntity gun = CurrentGun;
        if (gun != null)
        {
            gun.Fire();
        }
    }

    #endregion

    #region BeHurt

    public virtual void Hurt() { }

    #endregion

    #region SwitchGun

    public virtual void SwitchGun() { }

    #endregion

    #region ActionSkill

    public virtual void ActionSkill() { }

    #endregion

    #region PickUpTheGun

    public void PicUpTheGun(GameGunEntity gun)
    {
        int curGunCount = GetCurGunCount();
        if (curGunCount == m_gun.Length)
        {
            m_gun[m_curGunIndex] = gun;
        }
        else
        {
            PutGunIntoBag(gun);
        }
    }

    private int GetCurGunCount()
    {
        int count = 0;
        for (int i = 0; i < m_gun.Length; i++)
        {
            if (m_gun != null)
            {
                count++;
            }
        }

        return count;
    }

    private void PutGunIntoBag(GameGunEntity gun)
    {
        for (int i = 0; i < m_gun.Length; i++)
        {
            if (m_gun[i] == null)
            {
                m_gun[i] = gun;
                m_curGunIndex = i;
                return;
            }
        }
    }

    #endregion
}
