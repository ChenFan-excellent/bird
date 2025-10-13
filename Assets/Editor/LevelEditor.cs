using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Level))]//������� Level �ű����Զ��� Inspector�������
//���� Unity�������ڲ㼶/Project ��ѡ���˴� Level �Ķ����Ҳ� Inspector ����Ĭ�����ӣ�������� LevelEditor ������
public class LevelEditor : Editor//�̳� Editor��ר�Ÿɡ��� Inspector���Ļ
{
    Level Level;

    Vector2 scrollPos;
    public override void OnInspectorGUI()//ÿ�� Inspector �ػ涼�����
    {
        base.OnInspectorGUI();//�Ȼ�Ĭ�� Inspector
        Level = target as Level;// Unity ����ġ���ǰ��ѡ�е��Ǹ����󡱡�target as Level ���ǰ���ת�� Level ���ͷ������          
        OnRulesGUI(Level); // �����Լ��ġ�Rules����
    }

    void OnRulesGUI(Level level)
    {
        GUILayout.Label("Rules: ");
        //GUILayout.BeginScrollView(scrollPos);
        GUILayout.BeginVertical();
        for(int i = 0; i< level.Rules.Count; i++)
        {
            EditorGUILayout.ObjectField(level.Rules[i], typeof(unit));

        }
        GUILayout.EndVertical();

        if(GUILayout.Button("AddRule"))
        {
            level.Rules.Add(new SpawnRule());
        }
    }
}
