using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Wolf : MonoBehaviour
{

    public GameManager m_Gamemanager;

    public float m_FullBlood;
    public float m_RestBlood;

    private void Start()
    {
        m_RestBlood = m_FullBlood;
        m_Gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();


    }

    public void HitByBullet(float damage,Vector2 position)
    {
        GetComponent<WolfBehaviourController>().ScaredByDog(position);
        m_RestBlood -= damage;
    }

    private void Update()
    {
        if(m_RestBlood <= 0)
        {
            m_ISDeath = true;
            GetComponent<SpriteRenderer>().flipY = true;
            gameObject.tag = "Untagged";
            if(m_WolfDeathBodyTime>= 0)
            {
                m_WolfDeathBodyTime -= Time.deltaTime;
            }
            else
            {
                m_Gamemanager.GetComponent<WolfManager>().NewWolfSheep();
                Destroy(gameObject);

            }

        }
    }

    public float m_WolfDeathBodyTime = 10f;

    public bool m_ISDeath = false;
}
