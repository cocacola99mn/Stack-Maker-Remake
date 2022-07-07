using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject NextLevelBtn;
    public GameObject RestartBtn;
    public void PopNextLevelUI()
    {
        NextLevelBtn.SetActive(true);
        RestartBtn.SetActive(true);
    }
}
