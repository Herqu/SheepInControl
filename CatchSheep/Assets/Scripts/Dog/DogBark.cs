using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBark : MonoBehaviour
{
    public GameObject m_SoundPrefab;
    public GameObject m_LeftSoundPrefab;



    public void Bark()
    {
        if( !GetComponent<SpriteRenderer>().flipX )
        {

            Instantiate(m_SoundPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(m_LeftSoundPrefab, transform.position, Quaternion.identity);

        }






    }
}
