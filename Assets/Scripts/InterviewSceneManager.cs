using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterviewSceneManager : MonoBehaviour
{
    [SerializeField]
    protected GameObject text;
    [SerializeField]
    protected GameObject audio;
    [SerializeField]
    public GameObject questionPanel;

    [SerializeField]
    protected List<ScriptCommand> commands = new List<ScriptCommand>();
    protected int commandPtr = 0;

    // [SerializeField]
    // protected GameObject dummyAccess;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, false, 60);

        QuestionData firstQuestion = new QuestionData(
            "あなたの名前は？",
            new List<string>() {
                "大鳥こはく",
                "山田たろう"
            },
            new List<int>() {
                0,
                100,
            }
        );

        commands.Add(new Message("本日は株式会社一般の面接にお越しいただきましてありがとうございます。"));
        // commands.Add(new Voice("test"));
        commands.Add(new Message("面接を担当いたします、人事の「大鳥こはく」と申します。"));
        commands.Add(new Message("でははじめに、自己紹介をお願いします。"));
        commands.Add(new Question(firstQuestion));
        commands.Add(new Lazy<Message>(() => {
            if(firstQuestion.userAnswer == 1)
                return new Message("はい、ありがとうございます。");
            else
                return new Message("名前もちゃんと言えないんですね。");
        }));
        commands.Add(new Message("では次の質問です。"));
        commands.Add(new Message("${you_have_dark_personality}"));
        commands.Add(Question.ByKey("you_have_dark_personality"));
        commands.Add(Face.ByKey("you_have_dark_personality"));
        commands.Add(new Message(""));

        StartCoroutine(Message());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Message()
    {
        while(true)
        {
            // Commandが全部終わったら終了
            if(commandPtr >= commands.Count)
            {
                Debug.Log("[Script End]");

                SceneManager.LoadScene("ResultScene");

                yield break;
            }

            ScriptCommand command = commands[commandPtr];
            Action action = command.action;
            string value = command.value;
            Debug.Log(value);

            yield return StartCoroutine(command.Execute(this));
            commandPtr++;

            // 二重に反応するのを防ぐため1フレーム待つ
            yield return new WaitForEndOfFrame();
        }
    }
}
