using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
    public Text ResultText;
    public float passAverageScore;
    float userAverageScore;

    public Text Feedback1;
    public Text Feedback2;

    public Button FeedbackButton;
    public Button UpButton;
    public Button DownButton;

    public int feedbackTotal;
    int pageNum;

    List<string> feedbackText = new List<string>() { "1", "2" };

    // Start is called before the first frame update
    void Start()
    {
        pageNum = 0;
        FeedbackButton.onClick.AddListener(OnClickFeedbackButton);
        UpButton.onClick.AddListener(OnClickUpButton);
        DownButton.onClick.AddListener(OnClickDownButton);
        UpButton.interactable = false;
        DownButton.interactable = false;

        userAverageScore = GameStatus.score / (GameStatus.questionDic.Count+1);
        if(GameStatus.score > passAverageScore)
        {
            ResultText.text = "合格です";
        }
        else
        {
            ResultText.text = "不合格です";
        }
        Debug.Log("あなたの平均スコアは" + userAverageScore + "でした");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickFeedbackButton()
    {
        Feedback1.GetComponent<FeedbackScroll>().startTrans(new Vector2(415.0f, -764.0f), new Vector2(415.0f, 259.5f));
        ResultText.GetComponent<FeedbackScroll>().startTrans(new Vector2(415.0f, 302.0f), new Vector2(1000.0f, 302.0f));
        FeedbackButton.GetComponent<FeedbackScroll>().startTrans(new Vector2(415.0f, 231.0f), new Vector2(1000.0f, 231.0f));
        pageNum = 1;
        DownButton.interactable = true;
    }
    public void OnClickUpButton()
    {
        if (pageNum > 1)
        {
            if (pageNum % 2 == 0)
            {
                Feedback1.GetComponent<FeedbackScroll>().startTrans(new Vector2(415.0f, 764.0f), new Vector2(415.0f, 259.5f));
                Feedback2.GetComponent<FeedbackScroll>().startTrans(new Vector2(415.0f, 259.5f), new Vector2(415.0f, -764.0f));
                DownButton.interactable = true;
                pageNum--;
            }
            else
            {
                Feedback1.GetComponent<FeedbackScroll>().startTrans(new Vector2(415.0f, 259.5f), new Vector2(415.0f, -764.0f));
                Feedback2.GetComponent<FeedbackScroll>().startTrans(new Vector2(415.0f, 764.0f), new Vector2(415.0f, 259.5f));
                DownButton.interactable = true;
                pageNum--;
            }
            
        }
        if (pageNum == 1)
        {
            UpButton.interactable = false;
        }
    }
    public void OnClickDownButton()
    {
        if (pageNum < feedbackTotal)
        {
            if (pageNum % 2 == 0)
            {

                Feedback1.GetComponent<FeedbackScroll>().startTrans(new Vector2(415.0f, -764.0f), new Vector2(415.0f, 259.5f));
                Feedback2.GetComponent<FeedbackScroll>().startTrans(new Vector2(415.0f, 259.5f), new Vector2(415.0f, 764.0f));
                UpButton.interactable = true;
                pageNum++;
            }
            else
            {
                Feedback1.GetComponent<FeedbackScroll>().startTrans(new Vector2(415.0f, 259.5f), new Vector2(415.0f, 764.0f));
                Feedback2.GetComponent<FeedbackScroll>().startTrans(new Vector2(415.0f, -764.0f), new Vector2(415.0f, 259.5f));
                UpButton.interactable = true;
                pageNum++;
            }
        }
        if(pageNum == feedbackTotal)
        {
            DownButton.interactable = false;
        }
    }
    
}
