using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    public double coin = 0;
    public Text textScore;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
         if(collision.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
     void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player")){
            coin+= 1;
            textScore.text = "Score : "+coin;
            // textLife.text = "LIFE : "+life;
            Destroy(gameObject);
        }
    }
}