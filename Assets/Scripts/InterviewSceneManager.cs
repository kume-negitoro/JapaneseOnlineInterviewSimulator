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
        
        commands.Add(new Exec(new Message("本日は株式会社一般の面接にお越しいただきましてありがとうございます。")));
        commands.Add(new Voice("honjitsu"));
        commands.Add(new Exec(new Message("面接を担当いたします、人事の「大鳥こはく」と申します。")));
        commands.Add(new Voice("kohakudesu"));

        commands.Add(new Exec(new Message("でははじめに、自己紹介をお願いします。")));
        commands.Add(new Voice("jikosyoukai"));
        commands.Add(Question.ByKey("what_is_your_name"));
        commands.Add(Face.ByKey("what_is_your_name"));
        commands.Add(new Lazy(() => {
            int score = GameStatus.questionDic["what_is_your_name"].GetScore();
            if(score >= 50)
            {
                StartCoroutine(new Message("はい、ありがとうございます。").Execute(this));
                return new Voice("arigatou");
            }
            else
            {
                StartCoroutine(new Message("えっと、あなたの名前を聞いているんですが...").Execute(this));
                return new Voice("anatanonamaedesu");
            }
        }));

        commands.Add(new Exec(new Message("${did_you_sleep_well}")));
        commands.Add(new Voice("did_you_sleep_well"));
        commands.Add(Question.ByKey("did_you_sleep_well"));
        commands.Add(new Exec(new Message("なるほどですね")));
        commands.Add(new Voice("naruhodo"));

        commands.Add(new Exec(new Message("では次の質問です。")));
        commands.Add(new Voice("tuginositumon"));

        commands.Add(new Exec(new Message("${you_have_dark_personality}")));
        commands.Add(new Voice("you_have_dark_personality"));
        commands.Add(Question.ByKey("you_have_dark_personality"));
        commands.Add(Face.ByKey("you_have_dark_personality"));
        commands.Add(new Exec(new Message("なるほど、ありがとうございます。")));
        commands.Add(new Voice("naruhodoarigatou"));

        commands.Add(new Exec(new Message("では面接は以上になります。本日はありがとうございました。")));
        commands.Add(new Voice("mensetuhaijoudesu"));

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
