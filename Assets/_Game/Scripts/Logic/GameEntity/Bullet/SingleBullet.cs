using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBullet : BulletBase
{
    private SingleBulletLauncherData m_launcherData;

    private bool m_isAwake;
    private float m_deadTime;
    
    private static WaitForSeconds m_waitForSeconds;

    public override void Init()
    {
        m_isAwake = false;
        m_animator = GetComponent<Animator>();
    }

    public override void Dispose()
    {
        GameObject.Destroy(gameObject);
    }

    private void Update()
    {
        if (m_isAwake && m_launcherData != null)
        {
            transform.position += m_direction.normalized * Time.deltaTime * m_launcherData.m_bulletSpeed;
            Debug.LogError("Direction : "  + m_direction);
            if (Time.time >= m_deadTime)
            {
                BulletHide();
            }
        }
    }

    public override void BulletAwake(Transform transform, Vector3 direction, BulletLauncherDataBase data)
    {
        m_launcherData = data as SingleBulletLauncherData;
        if (m_launcherData == null)
        {
            Debug.LogError("SingleBulletLauncher is null !!!");
            return;
        }
        m_direction = direction;
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;
        m_deadTime = Time.time + m_launcherData.m_lifeTime;
        gameObject.SetActive(true);
        m_animator.Play(m_launcherData.m_fireAnimName);
        m_isAwake = true;

        if (m_waitForSeconds == null)
        {
            float time = GetFadeAnimLength(m_launcherData.m_fadeAnimName);
            m_waitForSeconds = new WaitForSeconds(time);
        }
    }

    public override void BulletHide()
    {
        m_isAwake = false;
        m_animator.Play(m_launcherData.m_fadeAnimName);

        float time = GetFadeAnimLength(m_launcherData.m_fadeAnimName);
        if (time > 0)
        {
            StartCoroutine(WaitToDestory());
        }
        else
        {
            OnBulletDeadAction();
        }
    }

    private void OnBulletDeadAction()
    {
        if (OnBulletDead != null)
        {
            OnBulletDead(this);
        }
    }

    private IEnumerator WaitToDestory()
    {
        yield return m_waitForSeconds;
        OnBulletDeadAction();
    }

    private float GetFadeAnimLength(string name)
    {
        if(m_animator == null) { return 0f; }
        RuntimeAnimatorController animControl = m_animator.runtimeAnimatorController;
        if (animControl == null) { return 0f; }
        AnimationClip[] clips = animControl.animationClips;
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i] != null && clips[i].name.Equals(name))
            {
                return clips[i].length;
            }
        }

        return 0f;
    }

    private void OnTriggerEnter()
    {
        BulletHide();
    }
}
