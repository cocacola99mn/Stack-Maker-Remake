using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float SmoothSpeed = 0.125f;

    public Vector3 offset ;

    private void LateUpdate()
    {
        Vector3 desirdPosition = target.position + offset;

        transform.position = desirdPosition;

        transform.LookAt(target);
    }
}
