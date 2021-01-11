using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterviewSceneManager : MonoBehaviour
{
    [SerializeField]
    protected GameObject text;

    [SerializeField]
    protected List<ScriptCommand> commands = new List<ScriptCommand>();
    protected int commandPtr = 0;

    [SerializeField]
    protected GameObject dummyAccess;

    // Start is called before the first frame update
    void Start()
    {
        commands.Add(new Message("本日は株式会社一般の面接にお越しいただきましてありがとうございます。"));
        commands.Add(new Message("面接を担当いたします、人事の「大鳥こはく」と申します。"));
        commands.Add(new Message("でははじめに、自己紹介をお願いします。"));

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
                yield break;
            }

            ScriptCommand command = commands[commandPtr];
            Action action = command.action;
            string value = command.value;
            Debug.Log(value);

            // CommandのActionの種類で判別してコルーチンを実行
            switch(action){
                case Action.Message:
                    yield return StartCoroutine(command.Execute(text));
                    break;
                case Action.Question:
                    yield return StartCoroutine(command.Execute(dummyAccess));
                    break;
                case Action.Input:
                    yield return StartCoroutine(command.Execute(dummyAccess));
                    break;
                default:
                    yield return StartCoroutine(command.Execute(dummyAccess));
                    break;
            }
            commandPtr++;

            // 何かのキーを待つ
            yield return new WaitUntil(() => Input.anyKeyDown);
            // 二重に反応するのを防ぐため1フレーム待つ
            yield return new WaitForEndOfFrame();
        }
    }
}
