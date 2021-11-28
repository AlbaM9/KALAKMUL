using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saved : MonoBehaviour
{
    public PlayerStats health;
    public Transform playerPos;

    public Idol idol;
    
    public PlayerController mun;

    public Text saved;
    public Text cemTot;

    void Start()
    {

        saved.enabled = false;
        cemTot.enabled = false;
        
        mun = FindObjectOfType<PlayerController>();
        health = FindObjectOfType<PlayerStats>();
        idol = FindObjectOfType<Idol>();
        

        health.pHealth = PlayerPrefs.GetFloat("life", 100f);
        idol.idol = PlayerPrefs.GetInt("idol");
        mun.munition = PlayerPrefs.GetInt("bullets", 10);
        
        LoadPosition();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("X", playerPos.position.x);
        PlayerPrefs.SetFloat("y", playerPos.position.y);
        PlayerPrefs.SetFloat("z", playerPos.position.z);
    }
    public void LoadPosition()
    {
        Vector3 position;
        position.x = PlayerPrefs.GetFloat("X", 0f);
        position.y = PlayerPrefs.GetFloat("y", 0f);
        position.z = PlayerPrefs.GetFloat("z", 0f);

        playerPos.position = new Vector3(position.x, position.y,position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Saved");
            saved.enabled = true;
            cemTot.enabled = true;

            SavePosition();
            PlayerPrefs.SetFloat("life", health.pHealth);
            PlayerPrefs.SetInt("idol", idol.idol);
            PlayerPrefs.SetInt("bullets", mun.munition);
           
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        saved.enabled = false;
        cemTot.enabled = false;
    }
}