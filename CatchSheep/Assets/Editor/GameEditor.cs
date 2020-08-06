using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]

public class GameEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameManager m_gameManager = (GameManager)target;
        //GridCellSpawn m_CellSpawn= (GridCellSpawn)target;

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("NewGrass"))
        {
            m_gameManager.NewGrass();
        }

        if (GUILayout.Button("deleteGrass"))
        {
            m_gameManager.RemoveGrass();
        }


        GUILayout.EndHorizontal();


        GUILayout.Label("树相关");

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("NewEnviroment"))
        {
            m_gameManager.GenerateSurroundEnviroment();
        }

        if (GUILayout.Button("DeleteEnviroment"))
        {
            m_gameManager.RemoveAllTree();
        }
        GUILayout.EndHorizontal();



    }
}
