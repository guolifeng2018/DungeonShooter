using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class InputMoveSystem : ComponentSystem
{
    struct InputComponents
    {
        public DirectionComponent m_direction;
        public InputComponent m_inputComponent;
        public SpriteComponent m_sprite;
    }

    protected override void OnUpdate()
    {
        ComponentGroupArray<InputComponents> entities = GetEntities<InputComponents>();
        Vector3 direction = Vector3.zero;
        EAnimType animType = EAnimType.fish_man_idle;
        foreach (InputComponents e in entities)
        {
            bool faceToRight = e.m_direction.m_faceToRight;
            HandleInput(out direction, ref faceToRight, out animType);
            if (e.m_inputComponent.m_isInputEnable)
            {
                e.m_direction.m_direction = direction;
                e.m_direction.m_faceToRight = faceToRight;
                e.m_sprite.SetAnimType(animType);
            }
        }
    }

    private void HandleInput(out Vector3 direction, ref bool faceToRight, out EAnimType animType)
    {
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += new Vector3(0f, 1f, 0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += new Vector3(0f, -1f, 0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += new Vector3(-1f, 0f, 0f);
            faceToRight = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += new Vector3(1f, 0f, 0f);
            faceToRight = true;
        }

        if (direction == Vector3.zero)
        {
            animType = EAnimType.fish_man_idle;
        }
        else
        {
            animType = EAnimType.fish_man_walk;
        }
    }
}
