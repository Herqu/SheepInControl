using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWoolCollect : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Wool")
        {
            GetComponent<Dog>().m_WoolNum++;
            Destroy(collision.gameObject);
        }
    }
}
