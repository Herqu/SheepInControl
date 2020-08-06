using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public GameObject m_Man;


    public GameObject m_GrassPrefab;
    public float m_GrassGenerateRange = 10;
    public int m_GrassGenerateNum = 10;


    public Transform m_Enviroment;




    public List<GameObject> m_AllTree = new List<GameObject>();
    public List<GameObject> m_AllSheep = new List<GameObject>();

    private void Awake()
    {
        m_Man = GameObject.FindGameObjectWithTag("Man");

        m_AllTree.AddRange( GameObject.FindGameObjectsWithTag("Tree"));
    }





    public void NewGrass()
    {

        for (int i = 0; i < m_GrassGenerateNum; i++)
        {
            Vector2 location = (Vector2)transform.position + UnityEngine.Random.insideUnitCircle * m_GrassGenerateRange;
            Instantiate(m_GrassPrefab, location, Quaternion.identity, m_Enviroment);
        }
    }

    public void RemoveGrass()
    {

        GameObject[] allGrass = GameObject.FindGameObjectsWithTag("Grass");
        foreach(GameObject obj in allGrass)
        {
            DestroyImmediate(obj);
        }

    }

    public void NewOneGrass()
    {
        Vector2 location = (Vector2)transform.position + UnityEngine.Random.insideUnitCircle * m_GrassGenerateRange;
        Instantiate(m_GrassPrefab, location, Quaternion.identity, m_Enviroment);
    }

    public Transform NewTreeTransfrom()
    {
        int i = Random.Range(0,m_AllTree.Count-1);
        return m_AllTree[i].transform;
    }

    [Header("树")]
    public GameObject m_TreePrefab;
    public int m_TreeNum;
    public int m_TreeOutNum;
    public float m_TreeOutRange = 100;
    public float m_TreeInnerRange = 90;

    public  void GenerateSurroundEnviroment()
    {

        for (int i = 0; i < m_TreeNum; i++)
        {
            float treeRange = UnityEngine.Random.Range(0f, m_TreeInnerRange);
            Vector2 location = (Vector2)transform.position + UnityEngine.Random.insideUnitCircle.normalized * treeRange;
            float distanceRatio= treeRange / m_TreeInnerRange;
            float ratio = UnityEngine.Random.Range(0f, distanceRatio);

            if (UnityEngine.Random.Range(0f,1f) <= ratio*ratio*ratio){
                Instantiate(m_TreePrefab, location, Quaternion.identity, m_Enviroment);


            }
        }


        for (int i = 0; i < m_TreeOutNum; i++)
        {
            float treeRange = UnityEngine.Random.Range(m_TreeInnerRange,m_TreeOutRange);
            Vector2 location = (Vector2)transform.position + UnityEngine.Random.insideUnitCircle.normalized * treeRange;
            Instantiate(m_TreePrefab, location, Quaternion.identity, m_Enviroment);
        }
        //for (int i = 0; i < m_TreeNum; i++)
        //{
        //    float treeRange = Random.Range(m_TreeInnerRange, m_TreeOutRange);
        //    Vector2 location = (Vector2)transform.position + Random.insideUnitCircle * treeRange;
        //    float distanc = (location - (Vector2)transform.position).magnitude;

        //    if (distanc >= m_TreeInnerRange)
        //    {
        //        Instantiate(m_TreePrefab, location, Quaternion.identity);

        //    }
        //}


    }

    public void RemoveAllTree()
    {

        GameObject[] allGrass = GameObject.FindGameObjectsWithTag("Tree");
        foreach (GameObject obj in allGrass)
        {
            DestroyImmediate(obj);
        }

    }


    public void NewSheepRegist(GameObject obj)
    {
        m_AllSheep.Add(obj);
        GetComponent<WolfManager>().NewWolfSheep();
    }
}
