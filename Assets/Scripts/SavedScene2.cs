using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavedScene2 : MonoBehaviour
{
    public PlayerStats health;
    public Transform playerPos;

    public Idol idol;
    public PlayerController mun;
    
    void Start()
    {

        
        health.pHealth = PlayerPrefs.GetFloat("life", 100f);
        mun.munition = PlayerPrefs.GetInt("bullets");
        LoadPosition();
       
        mun = FindObjectOfType<PlayerController>();
        health = FindObjectOfType<PlayerStats>();
        idol = FindObjectOfType<Idol>();


        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("X2", playerPos.position.x);
        PlayerPrefs.SetFloat("y2", playerPos.position.y);
        PlayerPrefs.SetFloat("z2", playerPos.position.z);
    }
    public void LoadPosition()
    {
        Vector3 position;
        position.x = PlayerPrefs.GetFloat("X2", 0f);
        position.y = PlayerPrefs.GetFloat("y2", 0f);
        position.z = PlayerPrefs.GetFloat("z2", 0f);

        playerPos.position = new Vector3(position.x, position.y, position.z);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Saved");
            SavePosition();
            PlayerPrefs.SetFloat("life", health.pHealth);       
            PlayerPrefs.SetInt("bullets", mun.munition);
            

        }
    }
}
