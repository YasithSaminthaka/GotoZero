using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private  Vector2  playerMove;
    public Vector2  PlayerMove
    {
        get => playerMove;
        set
        {
            playerMove = value+ new Vector2(0f,0f);
        }
    }
    public void OnMove(InputValue value)
    {
        if(value!=null) 
            playerMove = value.Get<Vector2>();
    }
    
}
