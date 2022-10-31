using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 3;
    public float horizontalSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player Moving Forward Automatically. Moving Left & Right With Key Press
        transform.Translate(new Vector3(0,0, Time.deltaTime * playerSpeed));

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(0, 0, Time.deltaTime * horizontalSpeed));
        }
    }
}
