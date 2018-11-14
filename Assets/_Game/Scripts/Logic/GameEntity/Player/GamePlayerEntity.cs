using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerEntity : GameEntityBase
{
    protected GamePlayerProps m_props;
    protected GamePlayerAnim m_anim;

    protected Vector2 m_direction;
    protected bool m_beHurt;
    protected bool m_faceToRight = true;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        m_props = new GamePlayerProps();
        m_anim = new GamePlayerAnim();
        m_anim.Init(gameObject);

        KeyBoardInputManager.GetInstance().AddMoveAction(Move);
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
    }

    protected virtual bool CheckCanMove()
    {
        return !m_anim.IsPlaying(EPlayerAnimType.Hurt);
    }

    #endregion

    #region Firing

    public virtual void Firing() { }

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

}
