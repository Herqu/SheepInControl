using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Sheep")
        {
            collision.GetComponent<SheepBehaviourController>().GetScared();
        }

        if(collision.tag == "Wolf")
        {
            collision.GetComponent<WolfBehaviourController>().ScaredByDog(transform.position);
        }
    }

    public float m_SoundLasttime = 1f;


    private void Start()
    {
        m_SoundLasttime += Time.time;
    }
    private void Update()
    {
        if(m_SoundLasttime <= Time.time)
        {
            Destroy(gameObject);
        }
    }
}
