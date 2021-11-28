using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Entrancelvl2 : MonoBehaviour
{
    public PlayerStats health;
    public PlayerController mun;
    public Saved save;

   

    void Start()
    {
        save = FindObjectOfType<Saved>();
        health = FindObjectOfType<PlayerStats>();
        mun = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            SceneManager.LoadScene("Level2");

            save.LoadPosition();
            PlayerPrefs.SetString("Scene", "Level2");

            PlayerPrefs.SetFloat("life", health.pHealth);
            
            PlayerPrefs.SetInt("bullets", mun.munition);

            
        }
    }
   
}
