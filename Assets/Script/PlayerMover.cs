using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : PlayerMovement
{
    private Player player;
    private EnumController enumController;
    private bool isMove = false;
    private int levelIndex;
    private PlayerStatus status = PlayerStatus.Default;
    private static int marks = 0;
    float _interval = 1f;
    float _time;
    public int LevelIndex
    {
        get => levelIndex;       
    }
    public int Mark
    {
        get => marks;
    }

    public PlayerMover(Player player, EnumController enumController)
    {
        this.player = player;
        this.enumController = enumController;
    }

    public void Move(Vector2 move)
    {
        if(isMove)
        {
            player.OnMove(move * 5 * Time.deltaTime);
            if(move.y>0 )
            {
               
            }
            _time += Time.deltaTime;

            while (_time >= _interval)
            {
                marks++;
                _time -= _interval;
            }

        }
            
    }

    public PlayerStatus Status(string tag)
    {
        
        if(tag.Equals(KEYS.Enum))
        {
            isMove = false;
            status = PlayerStatus.Fail;
 
        }
        else if(tag.Equals(KEYS.End))
        {
            status = PlayerStatus.Pass;
        }
        return status;

    }

    public void GameStart()
    {
        marks = 0;
        levelIndex = 1;
        isMove = true;
        enumController.Level = levelIndex;
        enumController.AddEnum();
    }

    public void NextLevel(int maxLevel)
    {
        if(status==PlayerStatus.Pass & maxLevel>levelIndex)
        {
            ++levelIndex;
            enumController.Level = levelIndex;
            enumController.AddEnum();
            player.transform.position = new Vector3(0, 0);
            isMove = true;
            marks = 0;
        } else
        {
            Debug.Log("Level Finished!");
        }
    }

    public void RePlay()
    {
        marks = 0;
        player.transform.position = new Vector3(0, 0);
        isMove = true; 
    }

    public void AddEnum(GameObject ob)
    {
        enumController.EnumInstantiate(ob);
    }

    public int Marks()
    {
        return Mark;
    }
     
    public int Level()
    {
        return LevelIndex;
    }
}

