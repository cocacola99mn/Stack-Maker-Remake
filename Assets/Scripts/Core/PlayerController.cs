using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{ 
    public GameObject Stack;
    public GameObject StackHolder;
    public GameObject StackVanish;
    public GameObject Model;
    public float PlayerSpeed;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movement.normalized * PlayerSpeed * Time.deltaTime);

    }

    public void PickUpStack(GameObject StackPiece)
    {       
        StackPiece.transform.SetParent(StackHolder.transform);

        Vector3 pos = Stack.transform.localPosition;
        pos.y -= 0.2f;
        StackPiece.transform.localPosition = pos;

        Vector3 CharacterPos = transform.localPosition;
        CharacterPos.y += 0.2f;
        transform.localPosition = CharacterPos;

        Stack = StackPiece;
    }

    public void DestroyStack()
    {
        transform.localPosition -= new Vector3(0f,0.2f,0f);

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
