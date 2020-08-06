using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepEatGrass : MonoBehaviour
{
    public GameObject m_CurretGrass;
    //public List<RaycastHit2D> m_GrassInRange = new List<GameObject>();

    [Range(1f, 10f)]
    public float m_GrassDetectedRange;


    public float m_EatGrassSpeed;
    public float m_EatGrassStopRange;
    public float m_MoveSpeed;


    public GameObject m_WoolPrefab;



    public SpriteRenderer m_SpritrRender;

    private void Start()
    {
        m_SpritrRender = GetComponent<SpriteRenderer>();
        m_WanderTarget = transform.position;
        CheckWanderTarget();
    }


    private void Update()
    {
        if(m_CurretGrass== null&& GetComponent<SheepBehaviourController>().m_SheepState != SheepState.Escape)
        {
            CheckGrass();
        }


    }


    public void UpdateInBehaviourController()
    {
        if (m_CurretGrass)
        {
            MoveToAndEatGrass();
        }
        else
        {
            CheckWanderTarget();
            MoveAndWander();
        }
    }

    private void MoveToAndEatGrass()
    {


        Vector2 direction = m_CurretGrass.transform.position - transform.position;
        float distance = direction.magnitude;
        direction.Normalize();
        if(distance >= m_EatGrassStopRange)
        {
            transform.Translate(Time.deltaTime * m_MoveSpeed* direction );

            MoveAnimation(direction);
        }
        else
        {
            EatGrass(m_CurretGrass);

        }
    }

    public Vector2 m_WanderTarget;

    private void MoveAndWander()
    {

        Vector2 direction = m_WanderTarget - (Vector2)transform.position;


        direction.Normalize();

        transform.Translate(Time.deltaTime * m_MoveSpeed * direction);

        MoveAnimation(direction);
    }

    public float m_wanderStopDistance;
    public float m_wanderRange;


    private void CheckGrass()
    {
        //m_GrassInRange.Clear();
        RaycastHit2D[] rh;
        LayerMask mask = 1 << LayerMask.NameToLayer("Grass");
        rh = Physics2D.CircleCastAll(transform.position, m_GrassDetectedRange, Vector2.zero, 0, mask);
        m_CurretGrass = null;
        if(rh.Length > 0)
        {
            float mindistance = m_GrassDetectedRange+1;
            //m_GrassInRange.AddRange(rh);
            foreach(RaycastHit2D r in rh)
            {
                if(r.distance <= mindistance)
                {
                    mindistance = r.distance;
                    m_CurretGrass = r.transform.gameObject;
                }


            }
        }

    }

    private void CheckWanderTarget()
    {
        float distance = (m_WanderTarget - (Vector2)transform.position).magnitude;

        if(distance <= m_wanderStopDistance)
        {
            m_WanderTarget = (Vector2)transform.position + Random.insideUnitCircle*m_wanderRange;

        }
    }



    public void EatGrass(GameObject grass)
    {
        GetComponent<SheepCondition>().m_CurrentSatiety += Time.deltaTime* m_EatGrassSpeed;
        if(GetComponent<SheepCondition>().m_CurrentSatiety >= GetComponent<SheepCondition>().m_FullSatiety)
        {
            Instantiate(m_WoolPrefab, transform.position, Quaternion.identity);
            GetComponent<SheepCondition>().m_CurrentSatiety = 0;
        }
        grass.GetComponent<Grass>().BeEat(Time.deltaTime * m_EatGrassSpeed);
    }




    public void MoveAnimation(Vector2 direction)
    {
        if (direction.x >= 0)
        {
            m_SpritrRender.flipX = false;
        }
        else
        {
            m_SpritrRender.flipX = true;

        }
    }

}
