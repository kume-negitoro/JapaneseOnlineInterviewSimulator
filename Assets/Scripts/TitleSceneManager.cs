using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button LoadButton;
    void Start()
    {
        Debug.Log("あなたの名前は" + GameStatus.playerName + "です");
        Debug.Log("あなたの年齢は" + GameStatus.playerAge + "です");
        LoadButton.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        SceneManager.LoadScene("ResumeScene");
        Debug.Log("入力シーンに移動");
    }
}
