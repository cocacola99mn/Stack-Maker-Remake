using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackDestroy : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Normal")
        {
            PlayerController.Ins.DestroyStack();
            Destroy(gameObject);
        }
    }
}
