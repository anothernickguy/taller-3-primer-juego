using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstaKill : MonoBehaviour
{
    public GameObject sangre;
    public UnityEvent onContact;
    Transform transformPlayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            transformPlayer = collision.transform;
            onContact.Invoke();
            Vector3 pos = collision.transform.position + Vector3.one * 0.5f;
            Instantiate(sangre, pos , Quaternion.identity);
            transformPlayer.gameObject.SetActive(false);
            Invoke("Moveralplayer", 0.5f);
        }
    }

    void Moveralplayer()
    {
        transformPlayer.position = CheckPointSystem.instance.UltimaPos;
        transformPlayer.gameObject.SetActive(true);
    }
}
