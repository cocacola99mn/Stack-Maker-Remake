using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{ 
    public GameObject Stack;
    public GameObject StackHolder;
    public GameObject StackVanish;
    public GameObject Model;
    public GameObject Raycast;
    
    public float PlayerSpeed;
    public bool left, right, up, down, raycastRight,raycastUp,raycastDown;
    public bool raycastLeft = false;
    void Update()
    {
        /*float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movement.normalized * PlayerSpeed * Time.deltaTime);*/
        
    }

    private void FixedUpdate()
    {
        PlayerInput();
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        if(up == true && raycastUp == true)
        {
            transform.Translate(-Vector3.forward * PlayerSpeed * Time.fixedDeltaTime, Space.World);
        }

        if (down == true && raycastDown == true)
        {
            transform.Translate(Vector3.forward * PlayerSpeed * Time.fixedDeltaTime, Space.World);
        }

        if (right == true && raycastRight == true)
        {
            transform.Translate(-Vector3.right * PlayerSpeed * Time.fixedDeltaTime, Space.World);
        }

        if (left == true && raycastLeft == true)
        {
            transform.Translate(Vector3.right * PlayerSpeed * Time.fixedDeltaTime, Space.World);
        }
    }

    public void PlayerInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if(down != true && left != true && right != true)
                up = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (up != true && left != true && right != true)
                down = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (down != true && up != true && right != true)
                left = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (down != true && left != true && up != true)
                right = true;
        }
    }

    public void PickUpStack(GameObject StackPiece)
    {       
        StackPiece.transform.SetParent(StackHolder.transform);

        Vector3 pos = Stack.transform.localPosition;
        pos.y -= 0.2f;
        StackPiece.transform.localPosition = pos;

        Vector3 RayPos = Raycast.transform.localPosition;
        RayPos.y -= 0.2f;
        Raycast.transform.localPosition = RayPos;

        Vector3 CharacterPos = transform.localPosition;
        CharacterPos.y += 0.2f;
        transform.localPosition = CharacterPos;

        Stack = StackPiece;
    }

    public void DestroyStack()
    {
        transform.localPosition -= new Vector3(0f,0.2f,0f);
        Raycast.transform.localPosition += new Vector3(0f, 0.2f, 0f);
        
        int lastChildIndex = StackHolder.transform.childCount - 1;
        GameObject StackGone = StackHolder.transform.GetChild(lastChildIndex).gameObject;
        StackGone.SetActive(false);
        
        int secondLastChildIndex = StackHolder.transform.childCount - 2;
        GameObject SecondLastStack = StackHolder.transform.GetChild(secondLastChildIndex).gameObject;
        
        Stack= SecondLastStack ;
                
        StackGone.transform.SetParent(StackVanish.transform);
        
    }

    public void PlayWinnerAnim()
    {
        Debug.Log("PlayAnim");
        Model.gameObject.GetComponent<Animation>().Stop("Idle");
        Model.gameObject.GetComponent<Animation>().Play("LevelComplete");
        PlayerSpeed = 0f;
    }
}
