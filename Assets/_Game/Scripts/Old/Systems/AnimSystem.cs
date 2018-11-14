using Unity.Entities;
using UnityEngine;

public class AnimSystem : ComponentSystem
{
    struct SpriteComponents
    {
        public SpriteComponent m_sprite;
    }

    protected override void OnUpdate()
    {
        ComponentGroupArray<SpriteComponents> entities = GetEntities<SpriteComponents>();
        foreach (SpriteComponents e in entities)
        {
            if (e.m_sprite.m_switch)
            {
                if (e.m_sprite.m_animator != null)
                {
                    e.m_sprite.m_animator.Play(e.m_sprite.m_animType.ToString());
                }
            }
        }
    }
}
