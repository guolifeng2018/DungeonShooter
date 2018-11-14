using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EAnimType
{
    fish_man_hurt = 1,
    fish_man_idle = 2,
    fish_man_walk = 3,
}

public class SpriteComponent : MonoBehaviour
{
    public EAnimType m_animType = EAnimType.fish_man_idle;
    public Animator m_animator;
    public bool m_switch = false; 

    public void SetAnimType(EAnimType animType)
    {
        m_switch = (animType != m_animType);
        m_animType = animType;
    }
}
