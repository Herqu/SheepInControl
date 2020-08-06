using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public Vector2 m_direction;
    public float m_Speed;

    public SpriteRenderer m_SpriteRenderer;

    private void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        m_direction = Vector2.zero;

        float hdirection = Input.GetAxis("Horizontal");
        float vdirection = Input.GetAxis("Vertical");

        m_direction += Vector2.right * hdirection;
        m_direction += Vector2.up * vdirection;

        m_direction.Normalize();

        Move();


        if (Input.GetButtonDown("Fire1"))
        {

            GetComponent<DogBark>().Bark();
        }


        if (Input.GetButtonDown("Fire2"))
        {
            

            GetComponent<DogNewTowel>().NewTowel();

        }


        if (Input.GetButtonDown("Fire3"))
        {


            GetComponent<DogNewSheep>().NewSheep();


        }



        if (Input.GetButtonDown("Fire4"))
        {
            m_Anchor.transform.position = transform.position;
        }

        
    }

    public GameObject m_Anchor;
    

    public void Move()
    {
        transform.Translate(m_direction * Time.deltaTime * m_Speed);
        if (m_direction.magnitude > 0.001f)
        {
            MoveAnimation(m_direction);

        }
    }



    public void MoveAnimation(Vector2 direction)
    {
        if (direction.x >= 0)
        {
            m_SpriteRenderer.flipX = false;
        }
        else
        {
            m_SpriteRenderer.flipX = true;

        }
    }


}
