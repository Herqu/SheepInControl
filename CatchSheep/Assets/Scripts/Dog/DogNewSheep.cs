using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogNewSheep : MonoBehaviour
{
    public GameObject m_SheepPrefab;



    public void NewSheep()
    {
        if (GetComponent<Dog>().m_TowelWoolCost <= GetComponent<Dog>().m_WoolNum)
        {
            Instantiate(m_SheepPrefab, transform.position, Quaternion.identity);
            GetComponent<Dog>().m_WoolNum -= GetComponent<Dog>().m_TowelWoolCost;
        }
    }
}
