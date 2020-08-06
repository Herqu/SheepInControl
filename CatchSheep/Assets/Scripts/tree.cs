using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0f,1f) >= 0.5f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }


}
