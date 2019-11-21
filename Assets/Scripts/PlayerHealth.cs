using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public bool hasDied;
    public float fullHealth;
    public GameObject deathFX;
    public AudioClip playerkill;

    AudioSource playerAS;

    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        hasDied = false;
        playerAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -7) {
            hasDied = true;     
        }
        if (hasDied == true){
            StartCoroutine ("Die");
        }
    }
    IEnumerator Die (){
        SceneManager.LoadScene ("scene 1");
        yield return null;
    }
    public void addDamage(float damage){
        if(damage<=0) return;
        currentHealth-=damage;

        playerAS.clip = playerkill;
        playerAS.Play();

        // playerAS.PlayOneShot(playerkill);

        if (currentHealth<=0){
            makeDead();
        }
    }
    public void makeDead(){
        Instantiate (deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
