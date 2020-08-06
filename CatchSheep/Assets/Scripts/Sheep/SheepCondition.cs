using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCondition : MonoBehaviour
{

    public float m_FullBlood;
    public float m_CurrentBlood;


    public float m_CurrentSatiety;
    public float m_FullSatiety;


    public GameObject m_GameManager;
    public GameObject m_Man;

    private void Start()
    {
        m_CurrentBlood = m_FullBlood;

        m_GameManager = GameObject.FindGameObjectWithTag("GameController");

        m_Man = m_GameManager.GetComponent<GameManager>().m_Man;

        m_GameManager.GetComponent<GameManager>().NewSheepRegist(gameObject);
    }


}
