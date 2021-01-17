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

    public Text ErrorText;

    void Start()
    {
        Screen.SetResolution(1280, 720, false, 60);

        LoadButton.onClick.AddListener(OnClickButton);
        List<string> motivationList = new List<string>(){ "", "実家に近いから", "福利厚生がしっかりしてるから" };
        List<string> appealList = new List<string>() { "", "粘り強さ", "真面目" };

        //DropDownの設定
        MotivationDD.ClearOptions();
        MotivationDD.AddOptions(motivationList);
        MotivationDD.value = 0;

        AppealDD.ClearOptions();
        AppealDD.AddOptions(appealList);
        AppealDD.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        if(MotivationDD.value == 0)
        {
            ErrorText.text = "志望動機が設定されていません！";
        }
        else if (AppealDD.value == 0)
        {
            ErrorText.text = "アピールポイントが設定されていません！";
        }
        else
        {
            GameStatus.playerName = NameInput.text;
            GameStatus.motivation = MotivationDD.options[MotivationDD.value].text;
            GameStatus.appeal = AppealDD.options[AppealDD.value].text;

            SceneManager.LoadScene("InterviewScene");
            Debug.Log(GameStatus.motivation);
            Debug.Log("面接シーンに移動");
        }
        
    }
}
