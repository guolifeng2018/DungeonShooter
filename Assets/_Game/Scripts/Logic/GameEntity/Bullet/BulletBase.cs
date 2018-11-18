using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : GameEntityBase
{
    public static Action<BulletBase> OnBulletDead;

    protected Animator m_animator;

    protected Vector3 m_direction;

    public abstract void BulletAwake(Transform transform, Vector3 direction, BulletLauncherDataBase data);

    public abstract void BulletHide();
}
