using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AssetsManager : MonoBehaviour
{
    PlayerComponent playerComponent;

    public GameObject imageSet0;
    public GameObject imageSet1;
    public GameObject imageSet2;
    public GameObject imageSet3;

    public Button vehicleTypeButton;
    public Button soundButton;
    public Button TermsAndCondition;
    public Button enterButton;

    public GameObject vehicleTypeObj;
    public GameObject soundObj;
    public GameObject TermsObj;

    public Button acceptConditionSButton;
    public TextMeshProUGUI soundText; 

    bool soundSetup;
    public Button[] buttons;
    public string[] buttonIds;

    private AsyncOperation loadingOperation;
    [SerializeField] private Slider tmpLoading;
    [SerializeField] private GameObject tmpLoadingObj;
    // Start is called before the first frame update
    void Start()
    {
        //gameSetup = new GameSetup();
        if ( PlayerPrefs.GetInt(KEYS.sound)>0)
        {
            soundText.text = "OFF";
        } else
        {
            soundText.text = "ON";
            PlayerPrefs.SetInt(KEYS.sound, 0);
            PlayerPrefs.Save();

        }
        int vals = PlayerPrefs.GetInt(KEYS.termsAndCondition);
        if (vals==0)
        {
            terms();
        }
        else
        {
            VehicleTypes();
        }
        playerComponent = Resources.Load<PlayerComponent>("Component");

        int index = 0;

       // buttonIds = new string[buttons.Length];
        for (int i = 0; i < playerComponent.boatModels.Length; i++)
        {
            imageSet0.transform.GetChild(i).GetComponent<RawImage>().texture = playerComponent.boatModels[i].texture;
            VehicleSelect vc = imageSet0.transform.GetChild(i).gameObject.AddComponent<VehicleSelect>();
            vc.number = i;
            imageSet0.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(() => ButtonAction(vc.number , PlayerTypes.boat, playerComponent.boatModels[vc.number].texture));

            imageSet1.transform.GetChild(i).GetComponent<RawImage>().texture = playerComponent.doubleBoatModels[i].texture;
            VehicleSelect vc1 = imageSet1.transform.GetChild(i).gameObject.AddComponent<VehicleSelect>();
            vc1.number = i;
            imageSet1.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(() => ButtonAction(vc1.number, PlayerTypes.double_boat, playerComponent.boatModels[vc1.number].texture));
 
            imageSet2.transform.GetChild(i).GetComponent<RawImage>().texture = playerComponent.shipModels[i].texture;
            VehicleSelect vc2 = imageSet2.transform.GetChild(i).gameObject.AddComponent<VehicleSelect>();
            vc2.number = i;
            imageSet2.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(() => ButtonAction(vc2.number,PlayerTypes.double_boat, playerComponent.boatModels[vc2.number].texture));
            
            imageSet3.transform.GetChild(i).GetComponent<RawImage>().texture = playerComponent.largeShipModels[i].texture;
            VehicleSelect vc3 = imageSet3.transform.GetChild(i).gameObject.AddComponent<VehicleSelect>();
            vc3.number = i;
            imageSet3.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(() => ButtonAction(vc3.number,PlayerTypes.large_ship, playerComponent.boatModels[vc3.number].texture));
            // imageSet0.AddComponent<VehicleSelect>().number = i;
        }

        vehicleTypeButton.onClick.AddListener(VehicleTypes);
        soundButton.onClick.AddListener(sound);
        TermsAndCondition.onClick.AddListener(terms);
        acceptConditionSButton.onClick.AddListener(termsAccepted);
        enterButton.onClick.AddListener(EnterToGame);
        
        
        SetButtonId();
    }

    private void EnterToGame()
    {
        if(PlayerPrefs.GetInt(KEYS.termsAndCondition)>0)
        {
            StartCoroutine(LoadSceneAsync());
        }
    }

    private void termsAccepted()
    {
        print("Accepted");
        PlayerPrefs.SetInt(KEYS.termsAndCondition, 1);
        PlayerPrefs.Save();
    }

    void SetButtonId()
    {
        
        if(!PlayerPrefs.HasKey(KEYS.VehicleType))
        {
            PlayerPrefs.SetString(KEYS.VehicleType, PlayerTypes.boat.ToString());
            PlayerPrefs.Save();
        } 
        string value = PlayerPrefs.GetString(KEYS.VehicleType);
        switch (value)
        {
            case "boat":
                print("boat");
                for (int i = 0; i < imageSet0.transform.childCount; i++)
                {
                    imageSet0.transform.GetChild(i).GetComponent<Button>().interactable = true;
                    imageSet1.transform.GetChild(i).GetComponent<Button>().interactable = false;
                    imageSet2.transform.GetChild(i).GetComponent<Button>().interactable = false;
                    imageSet3.transform.GetChild(i).GetComponent<Button>().interactable = false;
                }
                break;
            case "double_boat":
                print("double_boat");
                for (int i = 0; i < imageSet0.transform.childCount; i++)
                {
                    imageSet0.transform.GetChild(i).GetComponent<Button>().interactable = false;
                    imageSet1.transform.GetChild(i).GetComponent<Button>().interactable = true;
                    imageSet2.transform.GetChild(i).GetComponent<Button>().interactable = false;
                    imageSet3.transform.GetChild(i).GetComponent<Button>().interactable = false;
                }
                break;
            case "ship":
                print("ship");
                for (int i = 0; i < imageSet0.transform.childCount; i++)
                {
                    imageSet0.transform.GetChild(i).GetComponent<Button>().interactable = false;
                    imageSet1.transform.GetChild(i).GetComponent<Button>().interactable = false;
                    imageSet2.transform.GetChild(i).GetComponent<Button>().interactable = true;
                    imageSet3.transform.GetChild(i).GetComponent<Button>().interactable = false;
                }
                break;
            case "large_ship":
                print("large_ship");
                for (int i = 0; i < imageSet0.transform.childCount; i++)
                {
                    imageSet0.transform.GetChild(i).GetComponent<Button>().interactable = false;
                    imageSet1.transform.GetChild(i).GetComponent<Button>().interactable = false;
                    imageSet2.transform.GetChild(i).GetComponent<Button>().interactable = false;
                    imageSet3.transform.GetChild(i).GetComponent<Button>().interactable = true;
                }
                break;

        } 
    }

    private void ButtonAction(int i , PlayerTypes types , Texture txt)
    {
        print("Event "+i+" "+txt.name);

        PlayerPrefs.SetInt(KEYS.playerModel, i);
        PlayerPrefs.Save();
        //GameController.enemySprite = txt;
    }

    private void terms()
    {
        vehicleTypeObj.SetActive(false);
        soundObj.SetActive(false);
        TermsObj.SetActive(true);
        vehicleTypeButton.GetComponent<TextMeshProUGUI>().color = Color.gray;
        soundButton.GetComponent<TextMeshProUGUI>().color = Color.gray;
        TermsAndCondition.GetComponent<TextMeshProUGUI>().color = Color.white;

    }

    private void sound()
    {
        vehicleTypeObj.SetActive(false);
        soundObj.SetActive(true);
        TermsObj.SetActive(false);
        vehicleTypeButton.GetComponent<TextMeshProUGUI>().color = Color.gray;
        soundButton.GetComponent<TextMeshProUGUI>().color = Color.white;
        TermsAndCondition.GetComponent<TextMeshProUGUI>().color = Color.gray;
    }

    private void VehicleTypes()
    {
        vehicleTypeObj.SetActive(true);
        soundObj.SetActive(false);
        TermsObj.SetActive(false);
        vehicleTypeButton.GetComponent<TextMeshProUGUI>().color = Color.white;
        soundButton.GetComponent<TextMeshProUGUI>().color = Color.gray;
        TermsAndCondition.GetComponent<TextMeshProUGUI>().color = Color.gray;
    }

    public void setSoundOn()
    {
        soundText.text = "ON";
        PlayerPrefs.SetInt(KEYS.sound, 0);
        PlayerPrefs.Save();
    } 
    public void setSoundOff()
    {
        soundText.text = "OFF";
        PlayerPrefs.SetInt(KEYS.sound, 1);
        PlayerPrefs.Save();
    }
    IEnumerator LoadSceneAsync()
    {
        tmpLoadingObj.SetActive(true);
        // Load the main scene asynchronously
        loadingOperation = SceneManager.LoadSceneAsync("Game");
        //loadingOperation.allowSceneActivation = false;

        // Wait until the scene is loaded
        while (!loadingOperation.isDone)
        {
            // Update your loading progress UI here
            float progress = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            tmpLoading.value = progress;
            yield return null;
        }

        // Once loading is complete, activate the loaded scene
        loadingOperation.allowSceneActivation = true;
    }
}
