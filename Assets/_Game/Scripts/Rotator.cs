using UnityEngine;
using Unity.Entities;
using Unity.Rendering;

public class Rotator : MonoBehaviour
{
    public float speed;
}

public class RotatorSystem : ComponentSystem
{
    struct Components
    {
        public Rotator rotator;
        public Transform transform;
    }

    protected override void OnUpdate()
    {
        float deltatime = Time.deltaTime;
        foreach(var e in GetEntities<Components>())
        {
            e.transform.Rotate(0f, e.rotator.speed * deltatime, 0f);
        }

        
    }
}
