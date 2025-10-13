using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Level))]//这个类是 Level 脚本的自定义 Inspector属性面版
//告诉 Unity：当你在层级/Project 里选中了带 Level 的对象，右侧 Inspector 不用默认样子，用我这个 LevelEditor 来画。
public class LevelEditor : Editor//继承 Editor，专门干“画 Inspector”的活。
{
    Level Level;

    Vector2 scrollPos;
    public override void OnInspectorGUI()//每次 Inspector 重绘都会调用
    {
        base.OnInspectorGUI();//先画默认 Inspector
        Level = target as Level;// Unity 给你的“当前被选中的那个对象”。target as Level 就是把它转成 Level 类型方便访问          
        OnRulesGUI(Level); // 画你自己的“Rules”块
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
