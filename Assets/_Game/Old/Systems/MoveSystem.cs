using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class MoveSystem : ComponentSystem
{
    struct MoveComponents
    {
        public DirectionComponent m_direction;
        public SpeedComponent m_speed;
        public Transform m_transform;
    }

    protected override void OnUpdate()
    {
        float deltaTime = Time.deltaTime;
        ComponentGroupArray<MoveComponents> moveComponents = GetEntities<MoveComponents>();
        foreach (MoveComponents e in moveComponents)
        {
            e.m_transform.position += e.m_direction.m_direction * e.m_speed.m_speed * deltaTime;
            e.m_transform.rotation = e.m_direction.m_faceToRight
                ? Quaternion.Euler(Vector3.zero)
                : Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
    }
}
