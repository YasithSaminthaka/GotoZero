using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerTypes
{
    boat, 
    ship,
    double_boat,
    large_ship
}
[System.Serializable]
public class Position
{
    public settoArrayPos[] pos;
}
[System.Serializable]
public class settoArrayPos
{
    public int arrayNumber;
}
[CreateAssetMenu(fileName = "Player", menuName = "Objects/PlayerSetting", order = 1)]
public class PlayerScriptable : ScriptableObject
{
    public PlayerTypes types;
    public int gridWidgth;
    public int gridHeight;
    public Position[] positions;
}
