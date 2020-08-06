using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogNewTowel : MonoBehaviour
{
    public GameObject m_TowerPrefab;
    public void NewTowel()
        {
            if(GetComponent<Dog>().m_TowelWoolCost<= GetComponent<Dog>().m_WoolNum )
            {
                Instantiate(m_TowerPrefab, transform.position, Quaternion.identity);
                GetComponent<Dog>().m_WoolNum -= GetComponent<Dog>().m_TowelWoolCost;
            }
        }
}
