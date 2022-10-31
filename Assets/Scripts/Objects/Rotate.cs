using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float coin_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().Rotate(new Vector3(0, 0, 1) * Time.deltaTime * coin_speed);
        transform.Rotate(0, 0, 1);
    }
}
