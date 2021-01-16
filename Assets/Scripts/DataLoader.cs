using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void LoadData()
    {
        Object[] Texts = Resources.LoadAll("Questions", typeof(TextAsset));
        foreach (TextAsset text in Texts){
            string key = text.name;
            string value = text.ToString();
            QuestionData data = JsonUtility.FromJson<QuestionData>(value);
            GameStatus.questionDic.Add(key, data);
        }
    }
}