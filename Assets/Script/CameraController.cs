using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;

    [Range(0, 1)]
    public float smoothTime;

    public Vector3 positionOffset;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Cube").transform;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, 0, 0) + positionOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
