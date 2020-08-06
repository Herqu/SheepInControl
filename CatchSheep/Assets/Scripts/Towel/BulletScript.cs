using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float m_LastTime;

    public float m_MoveSpeed;
    public Vector2 m_MoveDirection;


    public float m_BulletDamage = 5;

    private void Start()
    {
        m_LastTime += Time.time;
    }

    private void Update()
    {
        if(Time.time >= m_LastTime)
        {
            Destroy(gameObject);
        }


        transform.Translate(m_MoveDirection * Time.deltaTime * m_MoveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wolf")
        {
            collision.GetComponent<Wolf>().HitByBullet(m_BulletDamage,transform.position);
            Destroy(gameObject);
        }
    }
}
