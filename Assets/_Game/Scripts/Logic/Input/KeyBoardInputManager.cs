using System;
using UnityEngine;

public class KeyBoardInputManager : MonoSingletonBase<KeyBoardInputManager>
{
    private Action<Vector2> MoveAction;
    private Action FireAction;

    protected override void MonoAwake()
    {
    }

    protected override void MonoStart()
    {
    }

    protected override void MonoOnDestroy()
    {
    }

    public void AddMoveAction(Action<Vector2> action)
    {
        MoveAction += action;
    }

    public void RemoveMoveAction(Action<Vector2> action)
    {
        MoveAction -= action;
    }

    public void AddFireAction(Action action)
    {
        FireAction += action;
    }

    public void RemoveFireAction(Action action)
    {
        FireAction -= action;
    }

    private void Update()
    {
        HandleMoveAction();

        HandleFireAction();
    }

    private void HandleMoveAction()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += new Vector2(0f, 1f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += new Vector2(0f, -1f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += new Vector2(-1f, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += new Vector2(1f, 0f);
        }

        direction = direction.normalized;
        MoveAction?.Invoke(direction);
    }

    private void HandleFireAction()
    {
        if (Input.GetMouseButton(0))
        {
            FireAction?.Invoke();
        }
    }
}
