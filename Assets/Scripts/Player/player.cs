using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public int healthPoints = 5;
    public static int abilityPoints = 10;
    public int score = 0;
    public float playerSpeed = 4;
    public float horizontalSpeed = 8;
    public float jumpAmount = 4;
    public GameOverPanel gameOverPanel;
    public Rigidbody rb;
    public AudioSource collect;
    public TMP_Text score_text;
    public TMP_Text health_text;
    public TMP_Text ability_text;
    public bool specialAbility = false;

    void Start()
    {
        score_text.text = "Score: " + score;
        health_text.text = "Health: " + healthPoints;
        ability_text.text = "Ability: " + abilityPoints;
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        Debug.Log(this.gameObject.transform.position.y);
        Debug.Log(this.gameObject.transform.position.y<1.1);
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

            if (healthPoints < 5) { healthPoints -= 3; }
            health_text.text = "Health: " + healthPoints;
            Destroy(collision.gameObject);
            //Debug.Log("Collide With One Lane Obstacle " + healthPoints);
        }
        else if (collision.gameObject.CompareTag("TwoLaneObstacle"))
        {
            if (healthPoints < 5) { healthPoints -= 2; }
            health_text.text = "Health: " + healthPoints;
            Destroy(collision.gameObject);
            //Debug.Log("Collide With Two Lane Obstacle " + healthPoints);
        }
        else if (collision.gameObject.CompareTag("ThreeLaneObstacle"))
        {
            if (healthPoints < 5){ healthPoints -= 1; }
            health_text.text = "Health: " + healthPoints;
            Destroy(collision.gameObject);
            //Debug.Log("Collide With Thre Lane Obstacle " + healthPoints);
        }
        else if (collision.gameObject.CompareTag("Jump1Lane"))
        {
            score += 3;
            score_text.text = "Score: " + score;
            Destroy(collision.gameObject);
            //Debug.Log("Jump 1 Lane Obstacle " );
        }
        else if (collision.gameObject.CompareTag("Jump2Lane"))
        {
            score += 2;
            score_text.text = "Score: " + score;
            Destroy(collision.gameObject);
            //Debug.Log("Jump 2 Lane Obstacle ");
        }
        else if (collision.gameObject.CompareTag("Jump3Lane"))
        {
            score += 1;
            score_text.text = "Score: " + score;
            Destroy(collision.gameObject);
            //Debug.Log("Jump 3 Lane Obstacle ");
        }
        else if (collision.gameObject.CompareTag("Health"))
        {

            if(healthPoints < 5) { healthPoints += 1; }
            collect.Play();
            health_text.text = "Health: " + healthPoints;
            //Debug.Log("Aloooo");
            Destroy(collision.gameObject);
            //Debug.Log("Collide With Health ");
        }
        else if (collision.gameObject.CompareTag("Ability"))
        {

            if (abilityPoints < 10) { abilityPoints += 1; }
            ability_text.text = "Ability: " + abilityPoints;
            //Debug.Log("Collide With Ability");
            Destroy(collision.gameObject);
            //Debug.Log(abilityPoints);
            collect.Play();
        }

    }

    public void GameOver()
    {
        playerSpeed = 0;
        horizontalSpeed = 0;
        gameOverPanel.Setup(score);
    }
}
