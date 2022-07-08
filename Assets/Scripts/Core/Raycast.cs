using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float range = 10;
    [SerializeField]
    private LayerMask wallLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootRay();
    }

    public void ShootRay()
    {
        Vector3 directionForward = Vector3.forward;
        Vector3 directionBack = -Vector3.forward;
        Vector3 directionRight = Vector3.right;
        Vector3 directionLeft = -Vector3.right;

        Ray forwardRay = new Ray(transform.position, transform.TransformDirection(directionForward * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(directionForward * range));

        Ray backRay = new Ray(transform.position, transform.TransformDirection(directionBack * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(directionBack * range));

        Ray rightRay = new Ray(transform.position, transform.TransformDirection(directionRight * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(directionRight * range));

        Ray leftRay = new Ray(transform.position, transform.TransformDirection(directionLeft * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(directionLeft * range));
        

        if (Physics.Raycast(forwardRay, out RaycastHit hitForward, range,wallLayer))
        {
            if(hitForward.collider.tag == "Wall")
            {
                if(hitForward.distance >= 0.55)
                {
                    PlayerController.Ins.raycastUp = true;
                }
                else
                {
                    PlayerController.Ins.raycastUp = false;
                    PlayerController.Ins.up = false;
                }
            }
        }

        if (Physics.Raycast(backRay, out RaycastHit hitBack, range, wallLayer))
        {
            if (hitBack.collider.tag == "Wall")
            {
                if (hitBack.distance >= 0.5)
                {
                    PlayerController.Ins.raycastDown = true;
                }
                else
                {
                    PlayerController.Ins.raycastDown = false;
                    PlayerController.Ins.down = false;
                }
            }
        }

        if (Physics.Raycast(rightRay, out RaycastHit hitRight, range, wallLayer))
        {
            if (hitRight.collider.tag == "Wall")
            {
                if (hitRight.distance >= 0.5)
                {
                    PlayerController.Ins.raycastRight = true;
                }
                else
                {
                    PlayerController.Ins.raycastRight = false;
                    PlayerController.Ins.right = false;
                }
            }
        }

        if (Physics.Raycast(leftRay, out RaycastHit hitLeft, range, wallLayer))
        {
            if (hitLeft.collider.tag == "Wall")
            {
                if (hitLeft.distance >= 0.5)
                {
                    PlayerController.Ins.raycastLeft = true;
                }
                else
                {
                    PlayerController.Ins.raycastLeft = false;
                    PlayerController.Ins.left = false;
                }
            }
        }
    }
}
