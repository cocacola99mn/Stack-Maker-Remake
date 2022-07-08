using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    int Score;
    
    public PlayerData(int Score)
    {
        this.Score = Score;
    }

    public override string ToString()
    {
        return $"{Score}";
    }
}
