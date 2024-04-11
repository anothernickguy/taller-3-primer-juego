using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Sistemadecoliciones : MonoBehaviour
{
    public string Tag;
    public bool Destruirobj;
    public UnityEvent onTriggerEnter2D;
    public bool Usounico;

    int contador; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Usounico == true && contador > 0)
        {
            return;
        }

        if (collision.CompareTag(Tag))
        {
            print("FIRE IN DA HOLE");

            if(Destruirobj == true);
            {
                Destroy(collision.gameObject);
            }


            onTriggerEnter2D.Invoke();

        contador ++;
            
        }
    }
}
