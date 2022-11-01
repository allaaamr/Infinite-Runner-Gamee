using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int healthPoints = 5;
    public int abilityPoints = 10;
    public int score = 0;
    public float playerSpeed = 3;
    public float horizontalSpeed = 8;
    public GameOverPanel gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(healthPoints <= 0)
        {
            GameOver();
        }
        // Player Moving Forward Automatically. Moving Left & Right With Key Press
        transform.Translate(new Vector3(0, 0, Time.deltaTime * playerSpeed));

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > -2.5f)
            {
                transform.Translate(new Vector3(Time.deltaTime * horizontalSpeed * -1, 0, 0));
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < 2.5f)
            {
                transform.Translate(new Vector3(Time.deltaTime * horizontalSpeed, 0, 0));
            }
        }
    
}
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OneLaneObstacle"))
        {
            healthPoints -= 3;
            Destroy(collision.gameObject);
            Debug.Log("Health " + healthPoints);
        }
        else if (collision.gameObject.CompareTag("TwoLaneObstacle"))
        {
            healthPoints -= 2;
            Destroy(collision.gameObject);
            Debug.Log("Health "+ healthPoints);
        }
        else if (collision.gameObject.CompareTag("ThreeLaneObstacle"))
        {
            healthPoints -= 1;
            Destroy(collision.gameObject);
            Debug.Log("Health " + healthPoints);
        }
        else if (collision.gameObject.CompareTag("Jump1Lane"))
        {
            score += 3;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Jump2Lane"))
        {
            score += 2;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Jump3Lane"))
        {
            score += 1;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Health"))
        {
            healthPoints += 1;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Ability"))
        {
            abilityPoints += 1;
            Destroy(collision.gameObject);
            Debug.Log(abilityPoints);
        }

    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        playerSpeed = 0;
        horizontalSpeed = 0;
        gameOverPanel.Setup(score);
    }
}
