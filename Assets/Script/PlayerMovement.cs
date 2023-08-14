using UnityEngine;

public interface PlayerMovement
{
    void Move(Vector2 move);
    PlayerStatus Status(string tag);
    void GameStart();
    void NextLevel(int maxLevel);
    void RePlay();
    void AddEnum(GameObject ob);
    int Marks();
    int Level();
}