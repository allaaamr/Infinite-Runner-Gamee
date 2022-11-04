using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private List<GameObject> activeScene;
    private List<GameObject> activePrefabs;
    public GameObject scene;
    public GameObject player_obj;
    public int zLocation = -35;
    public int numberOfColliders = 11;
    public int sceneCount = 1;
    public GameOverPanel gameOverPanel;
    public GameObject homePanel;
    private bool QPressed = false;
    public AudioSource backg;

    // Start is called before the first frame update
    void Start()
    {
        backg.Play();
        homePanel.SetActive(true);
        activePrefabs = new List<GameObject>();
        activeScene = new List<GameObject>();
        GameObject FirstScene = GameObject.FindGameObjectWithTag("firstScene");
        activeScene.Add(FirstScene);

        for (int i = 0; i < numberOfColliders; i++)
        {
            tiles(Random.Range(0, objectPrefabs.Length - 1));
        }

    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && player.abilityPoints >=5)
        {
            int length = activePrefabs.ToArray().Length;
            for ( int i = 0; i<length; i++)
            {
                DeletePrefab();
            }   
            QPressed = true;
            activePrefabs.Clear();
        }

        if (PauseMenu.GameIsPaused)
        {
            Debug.Log("I Am Paused");
            homePanel.SetActive(false);
        }
        else
        {
            Debug.Log("I Am Playing");
            homePanel.SetActive(true);


        }
        if (sceneCount == 1 && player_obj.transform.position.z > -28) 
        {
            GameObject sceneObject;
            Vector3 pos = new Vector3(0, 0, 62);
            sceneObject = Instantiate(scene);
            sceneObject.transform.position = pos;
            activeScene.Add(sceneObject);
            
            for (int i = 0; i < numberOfColliders; i++)
            {
                tiles(Random.Range(0, objectPrefabs.Length - 1));
            }
            sceneCount += 1;

        }
        if (sceneCount>1 && player_obj.transform.position.z > (60 * (sceneCount-1)-25))
        {
            GameObject sceneObject;
            Vector3 pos = new Vector3(0, 0, (60 * (sceneCount)));
            sceneObject = Instantiate(scene);
            sceneObject.transform.position = pos;
            activeScene.Add(sceneObject);
            sceneCount += 1;


            
                for (int i = 0; i < numberOfColliders; i++)
                {
                    tiles(Random.Range(0, objectPrefabs.Length - 1));
                if (!QPressed)
                {
                    DeletePrefab();
                }
                }
                DeleteScene();
                QPressed = true;
            
            

        }

    }

    public void tiles(int index)
    {
        GameObject tile;
        tile = Instantiate(objectPrefabs[index]) as GameObject;
        tile.transform.position = new Vector3(0, 0, zLocation);
        //Instantiate(objectPrefabs[index], new Vector3(0, 0, zLocation), transform.rotation);
        zLocation += 6;
        Debug.Log("Creating Prefab");
        activePrefabs.Add(tile);
    }

    //public void setVolume(float sliderValue)
    //{
    //    background.volume = sliderValue;
    //    Debug.Log(background.volume);
    //}

    private void DeletePrefab()
    {
        Debug.Log("Deleting Prefab");
        Destroy(activePrefabs[0]);
        activePrefabs.RemoveAt(0);
        
    }

    private void DeleteScene()
    {
        
        Destroy(activeScene[0]);
        activeScene.RemoveAt(0);
    }


}
