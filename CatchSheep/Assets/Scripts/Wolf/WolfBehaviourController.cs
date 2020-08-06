using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class WolfBehaviourController : MonoBehaviour
{


    public WolfEatSheep m_EatSheep;
    public WolfRunToNextTree m_RuntoNextTree;

    public SpriteRenderer m_Spriterenderer;

    private void Start()
    {
        m_EatSheep = GetComponent<WolfEatSheep>();
        m_RuntoNextTree = GetComponent<WolfRunToNextTree>();
        m_Spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!GetComponent<Wolf>().m_ISDeath)
        {

            if (m_ISScared)
            {
                Vector2 direction = (Vector2)transform.position - m_SoundSource;

                transform.Translate(direction.normalized * Time.deltaTime * m_EscapeSpeed);
                MoveAnimation(direction);
            }
            else
            {

                if (m_EatSheep.m_CurretnSheep)
                {
                    GetComponent<WolfEatSheep>().RuntoBiteSheep();

                }
                else
                {
                    GetComponent<WolfRunToNextTree>().MoveToNextTree();

                }

            }

            if (Time.time >= m_NextScaredTime)
            {
                m_ISScared = false;
            }
        }

    }


    public void ScaredByDog(Vector2 soundSourceLocation)
    {
        m_ISScared = true;
        m_SoundSource = soundSourceLocation;
        GetComponent<WolfEatSheep>().m_CurretnSheep = null;
        if(m_NextScaredTime >= Time.time)
        {
            m_NextScaredTime += m_ScaredTime;
        }
        else
        {
            m_NextScaredTime = Time.time + m_ScaredTime;

        }
    }


    public void MoveAnimation(Vector2 direction)
    {
        if (direction.x >= 0)
        {
            m_Spriterenderer.flipX = false;
        }
        else
        {
            m_Spriterenderer.flipX = true;

        }
    }


    public bool m_ISScared = false;
    public Vector2 m_SoundSource;
    public float m_EscapeSpeed = 6;

    public float m_ScaredTime;
    public float m_NextScaredTime;

}

