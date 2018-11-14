using UnityEngine;

public enum EPlayerAnimType : byte
{
    Idle = 0,
    Move = 1,
    Hurt = 2,
    Die = 3,

    Skill = 4,

    Other = 5,
}

public class GamePlayerAnimData
{
    private EPlayerAnimType m_animType;
    private string m_animName;

    public EPlayerAnimType AnimType
    {
        get { return m_animType; }
    }

    public string AnimName
    {
        get { return m_animName; }
    }

    public GamePlayerAnimData(EPlayerAnimType animType, string animName)
    {
        m_animName = animName;
        m_animType = animType;
    }
}
