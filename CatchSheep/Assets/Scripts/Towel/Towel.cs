using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towel : MonoBehaviour
{

    public GameObject m_CurrentWolf;

    public GameObject m_BulletPrefab;

    public float m_AttackIntervalTime = 0.5f;
    public float m_NextAttacktIME;




    private void Update()
    {
        if (m_CurrentWolf )
        {

            Vector2 direction = m_CurrentWolf.transform.position - transform.position;

            if(Time.time>= m_NextAttacktIME)
            {
                Instantiate(m_BulletPrefab, transform.position, Quaternion.identity).GetComponent<BulletScript>().m_MoveDirection = direction.normalized;
                m_NextAttacktIME = Time.time + m_AttackIntervalTime;
            }
            
        }



        if(m_CurrentWolf&&m_CurrentWolf.tag != "Wolf")
        {
            m_CurrentWolf = null;
        }
    }





    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject  == m_CurrentWolf)
        {
            m_CurrentWolf = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Wolf")
        {
            if (m_CurrentWolf == null)
            {
                m_CurrentWolf = collision.gameObject;

            }
        }
    }
}
