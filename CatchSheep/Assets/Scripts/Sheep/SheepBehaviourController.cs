using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBehaviourController : MonoBehaviour
{
    public SheepState m_SheepState = SheepState.EatGrass;

    private void Update()
    {
        if(m_SheepState == SheepState.EatGrass)
        {
            GetComponent<SheepEatGrass>().UpdateInBehaviourController();
        }else if(m_SheepState == SheepState.Escape){
            GetComponent<SheepEscape>().UpdateInBehaviourController();

        }
    }

    public void GetScared()
    {
        m_SheepState = SheepState.Escape;
        GetComponent<SheepEatGrass>().m_CurretGrass = null;
    }

}



public enum SheepState
{
    Escape,
    EatGrass,
    Dead,
}