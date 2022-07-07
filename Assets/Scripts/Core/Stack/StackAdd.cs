using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackAdd : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("StackAdd"))
        {
            other.gameObject.tag = "Normal";
            PlayerController.Ins.PickUpStack(other.gameObject);
            
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.AddComponent<StackAdd>();

            Destroy(this);

        }
    }
}
