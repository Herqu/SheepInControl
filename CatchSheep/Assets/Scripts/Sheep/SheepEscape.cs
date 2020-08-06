using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepEscape : MonoBehaviour
{
    public float m_SafeRange;
    public float m_MoveSpeed;

    public SpriteRenderer m_SpritrRender;

    private void Start()
    {
        m_MoveSpeed = GetComponent<SheepEatGrass>().m_MoveSpeed * 2;
        m_SpritrRender = GetComponent<SpriteRenderer>();
        m_SafeRange = Random.Range(0.5f, m_SafeRange);
    }

    

    public void UpdateInBehaviourController()
    {
        Vector2 direction = GetComponent<SheepCondition>().m_Man.transform.position - transform.position;
        float distance = direction.magnitude;
        direction.Normalize();
        if (distance >= m_SafeRange)
        {
            transform.Translate(Time.deltaTime * m_MoveSpeed * direction);
            MoveAnimation(direction);

        }
        else
        {
            GetComponent<SheepBehaviourController>().m_SheepState = SheepState.EatGrass;
        }

    }

    public void MoveAnimation(Vector2 direction)
    {
        if(direction.x >= 0)
        {
            m_SpritrRender.flipX = false;
        }
        else
        {
            m_SpritrRender.flipX = true;

        }
    }


}
