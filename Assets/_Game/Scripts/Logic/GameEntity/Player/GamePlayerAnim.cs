using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerAnim
{
    private Animator m_animator;

    private Dictionary<byte, GamePlayerAnimData> m_gamePlayerAnimDataDic;

    private EPlayerAnimType m_curAnimType;

    public void Init(GameObject player)
    {
        InitAnimDic();

        InitAnimator(player);

        m_gamePlayerAnimDataDic.Add((byte)EPlayerAnimType.Idle, new GamePlayerAnimData(EPlayerAnimType.Idle, "fish_man_idle"));
        m_gamePlayerAnimDataDic.Add((byte)EPlayerAnimType.Move, new GamePlayerAnimData(EPlayerAnimType.Move, "fish_man_walk"));
        m_gamePlayerAnimDataDic.Add((byte)EPlayerAnimType.Hurt, new GamePlayerAnimData(EPlayerAnimType.Hurt, "fish_man_hurt"));
    }

    public void Init(GameObject player, string controllerName, List<GamePlayerAnimData> list)
    {
        InitAnimDic();

        InitAnimator(player);

        for (int i = 0; i < list.Count; i++)
        {
            m_gamePlayerAnimDataDic.Add((byte)list[i].AnimType, list[i]);
        }
    }

    private void InitAnimDic()
    {
        if (m_gamePlayerAnimDataDic == null)
        {
            m_gamePlayerAnimDataDic = new Dictionary<byte, GamePlayerAnimData>();
        }
        m_gamePlayerAnimDataDic.Clear();
    }

    private void InitAnimator(GameObject player)
    {
        m_animator = ObjectCommon.GetChildComponent<Animator>(player, "player");
        if (m_animator == null)
        {
            Debug.LogError("Animator cannot find!!");
        }
        //todo:Load Controller

        m_curAnimType = EPlayerAnimType.Idle;
    }

    private string GetAnimName(EPlayerAnimType animType)
    {
        GamePlayerAnimData data = null;
        m_gamePlayerAnimDataDic.TryGetValue((byte)animType, out data);
        if (data == null)
        {
            Debug.LogError("Anim data is null    :   " + animType);
            return string.Empty;
        }

        return data.AnimName;
    }

    public void PlayAnim(EPlayerAnimType animType)
    {
        if (m_curAnimType == animType) { return; }

        m_curAnimType = animType;

        if (m_animator != null)
        {
            m_animator.Play(GetAnimName(m_curAnimType));
        }
    }

    public bool IsPlaying(EPlayerAnimType animType)
    {
        AnimatorStateInfo info = m_animator.GetCurrentAnimatorStateInfo(0);
        return info.IsName(GetAnimName(animType));
    }
}
