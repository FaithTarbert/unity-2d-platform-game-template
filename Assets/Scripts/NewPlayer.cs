using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float jumpPower = 10;
    // [HideInInspector] public int coinsCollected; <-this is if you want to hide this field in the inspector to prevent clutter
    public int coinsCollected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //sets horizontal speed r/l (x axis), tied to input arrow keys
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);
        //sets jump velocity (y axis) and if we're on the ground, tied to jump button/spacbar
        if(Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpPower;
        }
    }
}
