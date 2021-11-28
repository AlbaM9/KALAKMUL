using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MostroController : MonoBehaviour
{
  
    public Animator anim;
    private int mHealth;
    public int currentHealth;
    public Rigidbody rb;


    public PlayerController pl;
    public GameObject fathers;

   
    void Start()
    {
        pl = FindObjectOfType<PlayerController>();
        mHealth = 30;
        currentHealth = mHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
       /* if (pl.getDamaged == true)
        {
            currentHealth -= 10;
        }
        if (currentHealth <= 0)
        {
            Debug.Log("Muerto.Morío");
            rb.constraints = RigidbodyConstraints.FreezeAll;
            anim.SetBool("Death", true);
            Destroy(fathers , 3);
            
        }*/

    }
    public void GetDamaged() 
    {
        currentHealth -= 10;

        if (currentHealth <= 0)
        {
            Debug.Log("Muerto.Morío");
            rb.constraints = RigidbodyConstraints.FreezeAll;
            anim.SetBool("Death", true);
            Destroy(gameObject, 3);

        }
    }
   

   

       

    
}
