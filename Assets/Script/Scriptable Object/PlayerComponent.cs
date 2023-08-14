using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Component", menuName = "Objects/playerComponent", order = 2)]
public class PlayerComponent : ScriptableObject
{
    public Sprite[] boatModels;
    public Sprite[] doubleBoatModels;   
    public Sprite[] shipModels;   
    public Sprite[] largeShipModels;

    public Sprite selectedboatModels;
    public Sprite selecteddoubleBoatModels;
    public Sprite selectedshipModels;
    public Sprite selectedlargeShipModels;
}
