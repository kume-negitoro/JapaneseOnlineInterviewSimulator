using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterviewSceneManager : MonoBehaviour
{
    [SerializeField]
    protected Text text;

    [SerializeField]
    protected List<string> messages = new List<string>();
    protected int messagePtr = 0;

    // Start is called before the first frame update
    void Start()
    {
        messages.Add( "本日は株式会社一般の面接にお越しいただきましてありがとうございます。");
        messages.Add("面接を担当いたします、人事の「大鳥こはく」と申します。");

        StartCoroutine("Message");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown) Debug.Log(Input.anyKeyDown);
    }

    IEnumerator Message()
    {
        if(messagePtr >= messages.Count)
        {
            Debug.Log("coroutine break");
            yield break;
        }

        Debug.Log(messages[messagePtr]);
        text.text = messages[messagePtr];
        messagePtr++;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    }
}
