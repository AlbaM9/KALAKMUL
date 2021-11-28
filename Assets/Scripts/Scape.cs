using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scape : MonoBehaviour
{
    public GameObject winMenu;

    void Start()
    {
        winMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0;
            winMenu.SetActive(true);


        }
    }
}
