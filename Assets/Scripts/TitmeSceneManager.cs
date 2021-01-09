using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitmeSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("あなたの名前は" + GameStatus.playerName + "です");
        Debug.Log("あなたの年齢は" + GameStatus.playerAge + "です");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
