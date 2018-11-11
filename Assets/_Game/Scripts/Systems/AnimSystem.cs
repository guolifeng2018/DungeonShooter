using Unity.Entities;
using UnityEngine;

public class AnimSystem : ComponentSystem
{
    struct SpriteComponents
    {
        public SpriteComponent m_sprite;
        public Animator m_animator;
    }

    protected override void OnUpdate()
    {
        ComponentGroupArray<SpriteComponents> entities = GetEntities<SpriteComponents>();
        foreach (SpriteComponents e in entities)
        {
            if (e.m_sprite.m_switch)
            {
                e.m_animator.Play(e.m_sprite.m_animType.ToString());
            }
        }
    }
}
