﻿using System.Collections.Generic;
using UnityEngine;

public class SingleBulletLauncher : BulletLauncherBase
{
    protected SingleBullet m_templateBullet;
    protected SingleBulletLauncherData m_data;
    protected Transform m_bulletNode;
    protected float m_fireTime;

    private List<SingleBullet> m_bullets;
    private List<SingleBullet> m_cacheBullets;
    
    public SingleBulletLauncher(BulletLauncherDataBase data, GameObject gameObject, BulletBase tempBullet)
        : base(EBulletLauncherType.SingleBullet)
    {
        m_data = data as SingleBulletLauncherData;
        m_bullets = new List<SingleBullet>();
        m_cacheBullets = new List<SingleBullet>();
        m_templateBullet = tempBullet as SingleBullet;
        m_templateBullet.gameObject.SetActive(false);
        m_bulletNode = ObjectCommon.GetChildComponent<Transform>(gameObject, "bullet_node");
        if (m_data == null)
        {
            Debug.LogError("SingleBulletLauncherData parse error!!");
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < m_cacheBullets.Count; i++)
        {
            m_cacheBullets[i].Dispose();
        }
        m_cacheBullets.Clear();

        for (int i = 0; i < m_bullets.Count; i++)
        {
            m_bullets[i].Dispose();
        }
        m_bullets.Clear();
    }

    public override void Fire(Vector3 direction)
    {
        m_fireTime = Time.time;
        SingleBullet bullet = GetSingleBullet();
        bullet.OnBulletDead = ActionOnBulletDead;
        bullet.BulletAwake(m_bulletNode.transform, direction, m_data);
    }

    public override bool IsFiring()
    {
        return (Time.time < m_fireTime + m_data.m_fireRate);
    }

    public override float FireRate()
    {
        return m_data.m_fireRate;
    }

    private SingleBullet GetSingleBullet()
    {
        SingleBullet bullet = null;
        if (m_cacheBullets.Count > 0)
        {
            bullet = m_cacheBullets[0];
            m_cacheBullets.RemoveAt(0);
        }
        else
        {
            bullet = GameObject.Instantiate(m_templateBullet);
            bullet.Init();
        }

        return bullet;
    }

    private void ActionOnBulletDead(BulletBase bullet)
    {
        SingleBullet singleBullet = bullet as SingleBullet;
        if (singleBullet != null)
        {
            singleBullet.gameObject.SetActive(false);
            m_bullets.Remove(singleBullet);
            m_cacheBullets.Add(singleBullet);
        }
    }
}