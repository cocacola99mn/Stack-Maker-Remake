using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "StackPlus")
        {
            PlayerController.instance.PickUpStack(other.gameObject);
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.AddComponent<StackController>();
            Destroy(this);
        }
    }
}
