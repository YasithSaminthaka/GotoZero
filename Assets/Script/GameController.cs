using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private int maxLevel;
    [SerializeField] Player player;
    [SerializeField] PlayerController pController;

    [Header("UI")]
    [SerializeField] private GameObject winObject;
    [SerializeField] private GameObject replayObject;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button startButton;
    [SerializeField] private TextMeshProUGUI marksText;
    [SerializeField] private TextMeshProUGUI LevelText;
    PlayerMovement playerMovement;

    [Header("Enumy")]
    [SerializeField] private EnumController enumController;
    [SerializeField] private GameObject enumy;

    PlayerComponent playerComponent;
    [SerializeField] private AudioSource source;
    SoundController soundController;
    void Start()
    {      
        playerMovement = new PlayerMover(player, enumController);
        startButton.onClick.AddListener(GameStart);
        //playerMovement.AddEnum(enumy);

        playerComponent = Resources.Load<PlayerComponent>("Component");
        string v = PlayerPrefs.GetString(KEYS.VehicleType);
        switch (v)
        {
            case "boat":
                print("boat selected for enumy " + playerComponent.boatModels[PlayerPrefs.GetInt(KEYS.playerModel)].name);
                player.gameObject.GetComponent<SpriteRenderer>().sprite = playerComponent.boatModels[PlayerPrefs.GetInt(KEYS.playerModel)];
                break;
            case "double_boat":
                player.gameObject.GetComponent<SpriteRenderer>().sprite = playerComponent.boatModels[PlayerPrefs.GetInt(KEYS.playerModel)];
                break;
            case "ship":
                player.gameObject.GetComponent<SpriteRenderer>().sprite = playerComponent.boatModels[PlayerPrefs.GetInt(KEYS.playerModel)];
                break;
            case "large_ship":
                player.gameObject.GetComponent<SpriteRenderer>().sprite = playerComponent.boatModels[PlayerPrefs.GetInt(KEYS.playerModel)];
                break;
        }
        soundController = new SoundController(source);
        soundController.Background();
        //enumy.GetComponent<SpriteRenderer>()
        //enumy.GetComponent<SpriteRenderer>().material.mainTexture = enemySprite;

        
    }

     void GameStart()
    {
        playerMovement.GameStart();
        startButton.gameObject.SetActive(false);
        LevelText.text = playerMovement.Level().ToString();
    }
    void NextLevel()
    {
        playerMovement.NextLevel(maxLevel);
        winObject.SetActive(false);
        LevelText.text = playerMovement.Level().ToString();
    }
    void Replay()
    {
        playerMovement.RePlay();
        replayObject.SetActive(false);
        LevelText.text = playerMovement.Level().ToString();
    }

    void Update()
    {
            playerMovement.Move(pController.PlayerMove);
        marksText.text = playerMovement.Marks().ToString()+" Times";
    }
    public void Status(string value)
    {
        PlayerStatus state =  playerMovement.Status(value);
        if(state==PlayerStatus.Pass)
        {
            winObject.SetActive(true);
            nextButton.onClick.AddListener(NextLevel);
        } else if(state == PlayerStatus.Fail)
        {
            replayObject.SetActive(true);
            replayButton.onClick.AddListener(Replay);
        }
    }
}
public enum PlayerStatus
{
    Default,
    Pause,
    Pass,
    Fail,
    Wrong
    
}
