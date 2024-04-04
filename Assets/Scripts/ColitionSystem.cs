using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColitionSystem : MonoBehaviour
{
    public UnityEvent Onenter, Onstay, Onexit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Onenter.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Onstay.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Onexit.Invoke();
    }
}
