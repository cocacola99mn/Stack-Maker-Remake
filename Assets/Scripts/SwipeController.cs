using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public GameObject Player;
    public float PlayerSpeed;

    public float mousePosX1, mousePosX2, mousePosY1, mousePosY2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosX1 = Input.mousePosition.x;
            mousePosY1 = Input.mousePosition.y;
        }
            

        if (Input.GetMouseButtonUp(0))
        {
            mousePosX2 = Input.mousePosition.x;
            mousePosY2 = Input.mousePosition.y;

            if (mousePosX1 > mousePosX2)
            {
                Player.transform.Translate(Vector3.left * PlayerSpeed * Time.deltaTime);
            }
            else if(mousePosX1 < mousePosX2)
            {
                Player.transform.Translate(Vector3.right * PlayerSpeed * Time.deltaTime);
            }

            if (mousePosY1 > mousePosY2)
            {
                Player.transform.Translate(Vector3.forward * PlayerSpeed * Time.deltaTime);
            }
            else if (mousePosY1 < mousePosY2)
            {
                Player.transform.Translate(Vector3.back * PlayerSpeed * Time.deltaTime);
            }
        }
    }
}
