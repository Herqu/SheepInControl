using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfManager : MonoBehaviour
{

    public GameManager m_Gamemanager;


    private void Awake()
    {
        m_Gamemanager = GetComponent<GameManager>();

    }

    public int WolfToSheepRatio = 2;
    public GameObject m_wolFPrefab;
    

    public void NewWolfSheep()
    {
        Vector2 direction = Random.insideUnitCircle.normalized;
        Vector2 location = (Vector2)m_Gamemanager.m_Man.transform.position + direction * m_Gamemanager.m_TreeOutRange;
        
        for(int i = 0; i< 2; i++)
        {
            Instantiate(m_wolFPrefab, location, Quaternion.identity);
        }
    }
}
