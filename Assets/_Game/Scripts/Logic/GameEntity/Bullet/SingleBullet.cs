using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBullet : BulletBase
{
    private SingleBulletLauncherData m_launcherData;

    private bool m_isAwake;
    private float m_deadTime;

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
    }

    public override void BulletHide()
    {
        m_isAwake = false;
        m_animator.Play(m_launcherData.m_fadeAnimName);

    }

    //private float GetFadeAnimLength()
    //{
    //    if (m_animator != null)
    //    {
    //        AnimatorClipInfo[] clips = m_animator.GetCurrentAnimatorClipInfo(0);
    //        for (int i = 0; i < clips.Length; i++)
    //        {
    //            if()
    //        }
    //    }
    //}



    private void OnTriggerEnter()
    {
        BulletHide();
    }
}
