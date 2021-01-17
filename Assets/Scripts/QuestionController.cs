using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    [SerializeField]
    List<Button> options;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CreateQuestion(QuestionData question)
    {
        gameObject.SetActive(true);

        //ボタンに質問のテキストをセットする
        //質問が4個に満たなかったら非表示にする
        for(int i = 0; i < options.Count; i++)
        {
            if(i < question.answers.Count)
            {
                Text text = options[i].GetComponentInChildren<Text>();
                text.text = GameStatus.BindVars(question.answers[i]);
            }
            else
            {
                options[i].gameObject.SetActive(false);
            }
        }

        //リスナーをセットする
        int answer = -1;
        for(int i = 0; i < options.Count; i++)
        {
            int j = i;
            options[i].onClick.AddListener(() => { answer = j; });
        }

        // answerが変化するまで待つ
        yield return new WaitWhile(() => answer == -1);
        
        gameObject.SetActive(false);

        // リスナーを削除する
        // Inactiveにした選択肢をActiveにしておく
        for(int i = 0; i < options.Count; i++)
        {
            options[i].onClick.RemoveAllListeners();
            options[i].gameObject.SetActive(true);
        }

        question.select(answer);
        GameStatus.score += question.GetScore();

        yield return null;
    }
}
