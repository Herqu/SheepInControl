using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfEatSheep : MonoBehaviour
{

    public SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<WolfBehaviourController>().m_ISScared)
           DetectSheep();

    }








    public GameObject m_CurretnSheep;
    public float m_DetectRange = 10;

    public void DetectSheep()
    {

        if (!m_CurretnSheep)
        {

            LayerMask mask = 1 << LayerMask.NameToLayer("Sheep");

            RaycastHit2D rh = Physics2D.CircleCast(transform.position, m_DetectRange, Vector2.zero, 0, mask);

            if (rh &&rh.transform.tag == "Sheep")
            {
                m_CurretnSheep = rh.collider.gameObject;

            }
        }
    }

    public float m_RunSpeed = 7;
    public float m_BiteDistance = 0.5f;
    public float M_BiteTime = 0.3f;
    public float M_nextWalkTime  = 0;

    public float m_WoldAttackNUM = 10f;

    public void RuntoBiteSheep()
    {
        if (m_CurretnSheep)
        {
            Vector2 direction = m_CurretnSheep.transform.position - transform.position;
            float distance = direction.magnitude;
            if( distance >= m_BiteDistance && M_nextWalkTime <= Time.time)
            {
                transform.Translate(direction.normalized * Time.deltaTime * m_RunSpeed);
            }
            else if (distance <= m_BiteDistance && M_nextWalkTime <= Time.time)
            {

                if (m_CurretnSheep.GetComponent<SheepHurt>().GetHurt(m_WoldAttackNUM))
                {
                    m_CurretnSheep = null;
                }
                
                M_nextWalkTime = Time.time + M_BiteTime;
            }
            else if(distance <= m_BiteDistance&& M_nextWalkTime >= Time.time)
            {

            }

            MoveAnimation(direction);

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
