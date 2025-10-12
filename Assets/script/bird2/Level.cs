using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int LevelID;
    public string Name;
    public class SpawnRule
    {
        public int ID;
        public string Name;
        public unit Monster;
        public float Period;
        public int MaxNum;
    }

    public List<SpawnRule> Rules = new List<SpawnRule>();

    public unit Monster1;
    public float Period1;
    public int MaxNum1;

    public unit Monster2;
    public float Period2;
    public int MaxNum2;

    public unit Monster3;
    public float Period3;
    public int MaxNum3;

    public unit Monster4;
    public float Period4;
    public int MaxNum4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
