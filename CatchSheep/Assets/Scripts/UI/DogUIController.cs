using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogUIController : MonoBehaviour
{

    public Text m_SheepNum;
    public Text m_WoolNum;
    public CanvasGroup m_TowelMask;
    public CanvasGroup m_SheepMask;


    public GameObject m_Dog;
    public GameManager m_Manager;


    private void Start()
    {
        m_Dog = GameObject.FindGameObjectWithTag("Player");
        m_Manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
        m_SheepNum.text = m_Manager.m_AllSheep.Count.ToString();
        m_WoolNum.text = m_Dog.GetComponent<Dog>().m_WoolNum.ToString();
        if(m_Dog.GetComponent<Dog>().m_WoolNum>= m_Dog.GetComponent<Dog>().m_TowelWoolCost)
        {
            m_TowelMask.alpha = 1;
            m_SheepMask.alpha = 1;
        }
        else
        {
            m_SheepMask.alpha = 0;
            m_TowelMask.alpha = 0;
        }



    }
}
