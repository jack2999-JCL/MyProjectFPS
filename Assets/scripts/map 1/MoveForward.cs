using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public Transform Player;
    public float speed = 3f;
    

    // Start is called before the first frame update
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed *Time.deltaTime);
    }
}
