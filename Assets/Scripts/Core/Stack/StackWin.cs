using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackWin : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Normal")
        {
            PlayerController.Ins.PlayWinnerAnim();
            GameManager.Ins.ChangeGameState(GameState.Win);
        }
    }
}
