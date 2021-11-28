using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Idol : MonoBehaviour
{
    public int idol = 0;
    public Image idole;
    public GameObject entranceLevel2;

    public Text pulseE;


   

    void Start()
    {
        pulseE.enabled = false;
        idole.enabled = false;

        if (idol == 1)
        {
            pulseE.enabled = false;
            idole.enabled = true;
            Destroy(this.gameObject);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Idol Encontrado");
            pulseE.enabled = true;
            //Texto en pantalla
            if (Input.GetKeyDown(KeyCode.E))//Input.GetButtonDown("Enable Debug Button 1"))
            {
                pulseE.enabled = false;
                idol = 1;
                Destroy(this.gameObject);
                idole.enabled = true;
                entranceLevel2.SetActive(true);

            }
        }
    }
  
}
