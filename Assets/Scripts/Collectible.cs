using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    
    //enum creates a dropdown menu selector - "ItemType" with caps is a reserved var type like boolean
    enum ItemType { Coin, Health, Ammo}
    [SerializeField] private ItemType itemType;
    //assign the class NewPlayer to the variable newPlayer, which is assigned in the Start() below...
    NewPlayer newPlayer;


    // Start is called before the first frame update
    void Start()
    {
        // Load inventory items and Player game object for updates and re-use
        
        if (itemType == ItemType.Coin)
        {
            Debug.Log("I'm a coin!");
        }
        else if(itemType == ItemType.Health)
        {
            Debug.Log("I'm health!");
        }
        else if (itemType == ItemType.Ammo)
        {
            Debug.Log("I'm ammo!");
        }
        else
        {
            Debug.Log("I'm an inventory item!");
        }
        //load the player game object component for reuse...
        newPlayer = GameObject.Find("Player").GetComponent<NewPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        //student coded this way to avoid getting Newplayer by searching string name, which slows down Unity/game play
        NewPlayer player = collision.GetComponent<NewPlayer>();

        if (player)
        // if (collision.gameObject.name == "Player") <--Thomas coded this way...
        {
            //drill down thru active game components: Player > NewPlayer > coinsCollected (variable attached under NewPlayer script)
            newPlayer.coinsCollected += 1;
            //drill down to UpdateUI function in NewPlayer that updates game canvas text component with num of coins collected
            newPlayer.UpdateUI();
            /*ALTERNATIVE: set the game obj collided with to inactive/invisible (includes it's children ie trails etc)
            gameObject.SetActive(false);*/
            //OR: destroy coin (while in play mode) ie delete it and it's children entirely
            Destroy(gameObject);
        }
    }
}
