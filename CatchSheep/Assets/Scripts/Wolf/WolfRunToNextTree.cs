using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfRunToNextTree : MonoBehaviour
{
    public Transform m_NextTreeAnchor;
    public float m_GetTreeAnchorCheckDIstance;


    public float m_MoveSpeed;
    public GameManager m_GameManger;

    public SpriteRenderer m_SpriteRenderer;

    private void Start()
    {
        m_GameManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        NewTreeAnchor();
    }



    public void MoveToNextTree()
    {

        Vector2 direction = (Vector2)m_NextTreeAnchor.position - (Vector2)transform.position;

        float distance = direction.magnitude;

        if (distance <= m_GetTreeAnchorCheckDIstance)
        {
            NewTreeAnchor();
        }
        else
        {
            direction.Normalize();
            transform.Translate(direction * Time.deltaTime * m_MoveSpeed);
            MoveAnimation(direction);
        }

    }

    private void NewTreeAnchor()
    {
        m_NextTreeAnchor = m_GameManger.NewTreeTransfrom();
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
