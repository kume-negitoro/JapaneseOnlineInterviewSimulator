using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResumeSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button LoadButton;
    public InputField NameInput;
    public Dropdown MotivationDD;
    public Dropdown AppealDD;
    void Start()
    {
        LoadButton.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        GameStatus.playerName = NameInput.text;
        GameStatus.motivation = MotivationDD.value;
        GameStatus.ap = AppealDD.value;

        SceneManager.LoadScene("InterviewScene");
        Debug.Log("面接シーンに移動");
    }
}
