using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 1;
    [SerializeField] private bool dead;
    [SerializeField] private int health;
    [SerializeField] private string playerName;
    [SerializeField] private float recoveryCounter;

    // Start is called before the first frame update
    void Start()
    {
        //are we connecting with unity?
        Debug.Log("Connected!");
    }

    // Update is called once per frame
    void Update()
    {
        //player controller setup
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speedMultiplier * Time.deltaTime;

        //increase recoveryCounter by 1 per second
        recoveryCounter += Time.deltaTime;

        //set screen bounds
        //stop at r of screen 8.35
        if(transform.position.x > 8.35)
        {
            transform.position = new Vector3(8.35f, transform.position.y, transform.position.z);
            Hurt();
        }
        //stop at l of screen -8.35
        if(transform.position.x < -8.35)
        {
            transform.position = new Vector3(-8.35f, transform.position.y, transform.position.z);
            Hurt();
        }
        //stop at top of screen 4.5
        if(transform.position.y > 4.5)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, transform.position.z);
            Hurt();
        }
        //stop at btm of screen -4.5
        if(transform.position.y < -4.5)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, transform.position.z);
            Hurt();
        }
    }

    void Hurt()
    {
        if(recoveryCounter > 2)
        {
            //player gets hurt!
            health -= 1;
            Debug.Log("Ouch! Health: " + health);
        }
        
    }
}