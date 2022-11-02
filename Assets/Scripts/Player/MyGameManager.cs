using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{

    public GameObject[] objectPrefabs;
    public GameObject scene;
    public GameObject player;
    public int zLocation = -20;
    public int numberOfColliders = 13;
    public int sceneCount = 1;
    public GameOverPanel gameOverPanel;
    public GameObject homePanel;
    public AudioSource background;
    public AudioSource pause;

    // Start is called before the first frame update
    void Start()
    {
        homePanel.SetActive(true);
        pause.Play();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PauseMenu.GameIsPaused);
        if (PauseMenu.GameIsPaused)
        {
            homePanel.SetActive(false);
            background.Play();
            pause.Pause();
        }
        else
        {
            homePanel.SetActive(true);
            pause.Play();
            background.Pause();

           
        }
        for (int i = 0; i < numberOfColliders; i++)
        {
            tiles(Random.Range(0, objectPrefabs.Length));
        }

        if (sceneCount == 1 && player.transform.position.z > -10)
        {
            Debug.Log("Hi1");
            Vector3 pos = new Vector3(0, 0, 60);
            Instantiate(scene, pos, scene.transform.rotation);
            sceneCount += 1;
        }

        else if (player.transform.position.z > 25 * sceneCount)
        {
            Debug.Log("Hi");
            Vector3 pos = new Vector3(0, 0, 60 * sceneCount);
            Instantiate(scene, pos, scene.transform.rotation);
            sceneCount += 1;
            for (int i = 0; i < numberOfColliders; i++)
            {
                tiles(Random.Range(0, 4));
            }
        }

    }
    public void tiles(int index)
    {
        Instantiate(objectPrefabs[index], new Vector3(0, 0, zLocation), transform.rotation);
        zLocation += 6;
    }
   
}
