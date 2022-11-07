using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public int healthPoints = 5;
    public int abilityPoints = 10;
    public int score = 0;
    public float playerSpeed = 4;
    public float horizontalSpeed = 50;
    public float android_horizontalSpeed = 50;
    public float jumpAmount = 4;
    public GameOverPanel gameOverPanel;
    public Rigidbody rb;
    public AudioSource collect;
    public AudioSource hit;
    public AudioSource jump;
    public TMP_Text score_text;
    public TMP_Text health_text;
    public TMP_Text ability_text ;

    void Start()
    {
        score_text.text = "Score: " + score;
        health_text.text = "Health: " + healthPoints;
        ability_text.text = "Ability: " + abilityPoints;
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (Input.GetKeyDown(KeyCode.Space) && abilityPoints > 0 && this.gameObject.transform.position.y <1.1)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode.Impulse);
            abilityPoints -= 1;
            ability_text.text = "Ability: " + abilityPoints;
        }

        if (healthPoints <= 0)
        {
            GameOver();
        }
        if (Input.GetKey(KeyCode.Q) && abilityPoints >= 5)
        {
            abilityPoints -= 5;
            ability_text.text = "Ability: " + abilityPoints;
            // Rest of logic is inside GM.
        }

        transform.Translate(new Vector3(0, 0, Time.deltaTime * playerSpeed));
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && this.gameObject.transform.position.x > -2.5f)
        {
            transform.Translate(new Vector3(Time.deltaTime * horizontalSpeed * -1, 0, 0));
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && this.gameObject.transform.position.x < 2.5f)
        {
            transform.Translate(new Vector3(Time.deltaTime * horizontalSpeed * 1, 0, 0));
        }



    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OneLaneObstacle"))
        {
            hit.Play();
            healthPoints -= 3; 
            health_text.text = "Health: " + healthPoints;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("TwoLaneObstacle"))
        {
            
            healthPoints -= 2; 
            hit.Play();
            health_text.text = "Health: " + healthPoints;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ThreeLaneObstacle"))
        {
            hit.Play();
            healthPoints -= 1;
            health_text.text = "Health: " + healthPoints;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Jump1Lane"))
        {
            jump.Play();
            score += 3;
            score_text.text = "Score: " + score;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Jump2Lane"))
        {
            jump.Play();
            score += 2;
            score_text.text = "Score: " + score;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Jump3Lane"))
        {
            jump.Play();
            score += 1;
            score_text.text = "Score: " + score;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Health"))
        {
            if(healthPoints < 5) { healthPoints += 1; collect.Play(); }
            health_text.text = "Health: " + healthPoints;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Ability"))
        {
            if (abilityPoints < 10) { abilityPoints += 1; collect.Play(); }
            ability_text.text = "Ability: " + abilityPoints;
            Destroy(collision.gameObject);
        }

    }

    public void GameOver()
    {
        playerSpeed = 0;
        horizontalSpeed = 0;
        gameOverPanel.Setup(score);
    }

    public void jumpButton()
    {
        if (abilityPoints > 0 && this.gameObject.transform.position.y < 0.7)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode.Impulse);
            abilityPoints -= 1;
            ability_text.text = "Ability: " + abilityPoints;
        }


        
    }

    public void rightButton()
    {
        if (this.gameObject.transform.position.x < 2.5f)
        {
            transform.Translate(new Vector3(Time.deltaTime * android_horizontalSpeed, 0, 0));
        }

    }

    public void leftButton()
    {
        if (this.gameObject.transform.position.x > -2.5f)
        {
            transform.Translate(new Vector3(Time.deltaTime * android_horizontalSpeed * -1, 0, 0));
        }
    }



}
