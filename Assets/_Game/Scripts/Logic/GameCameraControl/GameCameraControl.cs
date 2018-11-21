using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraControl : MonoBehaviour
{
    public Camera m_cameraControl;
    
    private GamePlayerEntity m_followTarget;

    public void SetTarget(GamePlayerEntity setFollowEntity)
    {
        m_followTarget = setFollowEntity;
    }

    public void RemoveTarget()
    {
        m_followTarget = null;
    }
}
