using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumController : MonoBehaviour
{
    private int level;
    public int enumyListLength;
    JSonManager jsonManager;
    public int Level
    {
        get => level;
        set
        {
            level = value;
        }
    }
    public List<Vector2[]> grid = new List<Vector2[]>();
    public GameObject[] enumLIst;

    public void AddEnum()
    {
        if(level>1)
        {
            Destroy(GameObject.Find("Level "+level));
        }
       Instantiate( Resources.Load("Level "+level));

        /*TextAsset value = Resources.Load<TextAsset>("gamelevel");
        if (value != null)
        {
            // Deserialize the JSON content into PlayerData object
            jsonManager = JsonUtility.FromJson<JSonManager>(value.text);
            print(jsonManager.matrices.Capacity);
            // Access the deserialized data
           // Debug.Log("Player Name: " + jsonManager.matrices[0].matrix[0][1]);
        }
        else
        {
            Debug.LogError("Failed to load JSON file");
        }

        PlayerScriptable playerScriptable = Resources.Load<PlayerScriptable>("Level" + level);
        // Convert screen width to 2D position unit
        int screenWidth = (int)(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x * 2f);

        // Convert screen height to 2D position unit
        int screenHeight = (int)(Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y * 2f);

        // Calculate the starting position of the grid
        float enumStartPosX = transform.position.x - screenWidth / 2;
        float enumStartPosY = transform.position.y + screenHeight / 2;

        // Create a Vector2 with the starting position of the grid
        Vector2 enumStartGrid = new Vector2(enumStartPosX, enumStartPosY);
        float Ypos=0;

        

        for(int i=0;i<15;i++)
        {
            Vector2[] aList = new Vector2[15];
            Ypos = enumStartPosY + 4 * i;
            for (int j=0;j<15;j++)
            {
                aList[j] = new Vector2(enumStartPosX+ screenWidth/ 15*j, Ypos);
            }
            grid.Add(aList);          
        }
        */
       // AddEnums();

    }
     void AddEnums()
    {
        int numberOfObject=0;
        float endYPos = 0;
        for (int i=0; i< 15;i++)
        {
            List<int> val = jsonManager.matrices[0].matrix[i];

            for (int k=0;k< 15;k++)
            {
                int v = val[k];
                if(v==0)
                {
                    continue;
                }else if(v==1)
                {
                    Vector2[] aLists = grid[i];
                    Vector2 position = aLists[k];
                    GameObject obs = enumLIst[numberOfObject];
                    ++numberOfObject;
                    //GameObject obs = Instantiate(enums);
                    obs.SetActive(true);
                    obs.transform.position = position;
                    endYPos = position.y;
                }
                
                
                
            }
        }
        GameObject endObject = GameObject.Find("End");
        endObject.transform.position = new Vector2(0f, endYPos+10f);
        endObject.transform.rotation = Quaternion.Euler(0, 0, 0);

    }
    public void EnumInstantiate(GameObject ob)
    {
        enumLIst = new GameObject[enumyListLength];
        for (int k = 0; k < enumyListLength; k++)
        {
            GameObject st = Instantiate(ob);
            enumLIst[k] = st;
            st.SetActive(false);
        }
    }

}
