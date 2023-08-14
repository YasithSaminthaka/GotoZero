using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string collisionTag;
    public string CollisionTag
    {
        get => collisionTag;
        set
        {
            collisionTag = value;
        }
    }
    public void OnMove(Vector2 pos)
    {
        transform.localPosition += new Vector3(pos.x,pos.y , 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision Enter!");
        collisionTag = collision.gameObject.tag;
        GameObject.Find("GameController").SendMessage("Status", collision.gameObject.tag);
    }
}
