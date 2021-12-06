using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float jumpPower = 10;
    // [HideInInspector] public int coinsCollected; <-this is if you want to hide this field in the inspector to prevent clutter
    public int coinsCollected;

    //references a game component
    public Text coinsText;
    public Image healthBar;
    private Vector2 healthBarOriginalSize;

    // Start is called before the first frame update
    void Start()
    {
        // coinsText = GameObject.Find("Coins").GetComponent<Text>(); <--- replaced by dragging the >heirarchy >canvas >"coins" object onto the >inspector >new player (script) >"coins text" field, inside the unity editor

        // coinsCollected = 0;
        // UpdateUI();

        //grab original size of healthbar image as a place to start scaling it, as needed
        healthBarOriginalSize = healthBar.rectTransform.sizeDelta;
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

    //UPdate UI elements
    public void UpdateUI()
    {
        //grab the text field of the canvas UI component and insert the num of coins as a string (same variable type, string to string)
        coinsText.text = coinsCollected.ToString();
        //to do: scale healthbar according to player health
        //set healthbar image component width to 100
        healthBar.rectTransform.sizeDelta = new Vector2(100, healthBar.rectTransform.sizeDelta.y);
    }
}
