using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHurt : MonoBehaviour
{
     
    public ParticleSystem m_ParticleSysterm;

    public float m_HurtTime;
    public float m_NextHurtTime;


    private void Start()
    {
        m_ParticleSysterm = GetComponent<ParticleSystem>();

    }


    private void Update()
    {
        if(m_NextHurtTime <= Time.time)
        {
            m_ParticleSysterm.Stop();

        }


        CheckISDestroy();
    }


    public bool GetHurt(float num)
    {
        GetComponent<SheepCondition>().m_CurrentBlood -= num;
        m_NextHurtTime = Time.time + m_HurtTime;
        m_ParticleSysterm.Play();
        GetComponent<SheepBehaviourController>().GetScared();
        if(GetComponent<SheepCondition>().m_CurrentBlood <= 0)
        {
            tag = "Untagged";
            GetComponent<SheepBehaviourController>().m_SheepState = SheepState.Dead;
            GetComponent<SpriteRenderer>().flipY = true;
            GetComponent<SheepCondition>().m_GameManager.GetComponent<GameManager>().m_AllSheep.Remove(gameObject);
            return true;
        }

        return false;
    }


    public void CheckISDestroy()
    {
        if(GetComponent<SheepBehaviourController>().m_SheepState == SheepState.Dead&& m_ParticleSysterm.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
