using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string name;
    public int highScore;
    public int achievements;

    public UserData(string name, int highScore, int achievements)
    {
        this.name = name;
        this.highScore = highScore;
        this.achievements = achievements;
    }

}
