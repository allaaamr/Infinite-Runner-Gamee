using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 3;
    public float horizontalSpeed = 8;
    public int health_points = 5;
    public int ability_points = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player Moving Forward Automatically. Moving Left & Right With Key Press
        transform.Translate(new Vector3(0,0, Time.deltaTime * playerSpeed));

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > -2.5f) { 
                transform.Translate(new Vector3(Time.deltaTime * horizontalSpeed *-1, 0, 0));
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < 2.5f){
                transform.Translate(new Vector3(Time.deltaTime * horizontalSpeed , 0, 0));
            }
        }
    }
}
