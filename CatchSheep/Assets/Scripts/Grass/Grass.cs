using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{

    public float m_LeftGrassAmout;



    public GameManager m_GameManager;
    
    private void Start()
    {
        m_GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }


    public void BeEat(float amount)
    {
        m_LeftGrassAmout -= amount;
        if(m_LeftGrassAmout <= 0)
        {
            
            m_GameManager.NewOneGrass();
            
            Destroy(gameObject);
            
        }
    }
}
