using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    
    //enum creates a dropdown menu selector - "ItemType" with caps is a reserved var type like boolean
    enum ItemType { Coin, Health, Ammo}
    [SerializeField] private ItemType itemType;


    // Start is called before the first frame update
    void Start()
    {
        //If I'm a coin, print to the console "I'm a coin"
        
        // if (itemType == ItemType.Coin)
        // {
        //     Debug.Log("I'm a coin!");
        // }
        // else if(itemType == ItemType.Health)
        // {
        //     Debug.Log("I'm health!");
        // }
        // else if (itemType == ItemType.Ammo)
        // {
        //     Debug.Log("I'm ammo!");
        // }
        // else
        // {
        //     Debug.Log("I'm an inventory item!");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.name == "Player")
        {
            //drill down thru active game components: Player > NewPlayer > coinsCollected (variable attached under NewPlayer script)
            GameObject.Find("Player").GetComponent<NewPlayer>().coinsCollected += 1;
            /*ALTERNATIVE: set the game obj collided with to inactive/invisible (includes it's children ie trails etc)
            gameObject.SetActive(false);*/
            //OR: destroy coin (while in play mode) ie delete it and it's children entirely
            Destroy(gameObject);
        }
    }
}
