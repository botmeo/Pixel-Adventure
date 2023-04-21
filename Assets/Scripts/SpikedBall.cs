using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float leftPushRange;
    [SerializeField] private float rightPushRange;
    [SerializeField] private float velocityThreshold;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.angularVelocity = velocityThreshold;
    }

    void Update()
    {
        Push();
    }

    private void Push()
    {
        if(transform.rotation.z > 0 && transform.rotation.z < rightPushRange && body.angularVelocity > 0 && body.angularVelocity < velocityThreshold)
        {
            body.angularVelocity = velocityThreshold;
        } else if (transform.rotation.z < 0 && transform.rotation.z > rightPushRange && body.angularVelocity < 0 && body.angularVelocity > velocityThreshold*-1)
        {
            body.angularVelocity = velocityThreshold * -1;
        }
    }
}
