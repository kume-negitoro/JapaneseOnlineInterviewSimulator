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
    public Text PageNum;

    public Button FeedbackButton;
    public Button UpButton;
    public Button DownButton;

    public int feedbackTotal;
    int pageNum;
    float centerX = 640.0f, centerY = 370.71f, outsideY = 1123;

    List<string> feedbackText = new List<string>() { "1", "2" };

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, false, 60);

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
        Feedback1.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, -outsideY), new Vector2(centerX, centerY));
        ResultText.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, 406), new Vector2(2000.0f, 406));
        FeedbackButton.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, 356), new Vector2(2000.0f, 356));
        pageNum = 1;
        PageNum.text = pageNum.ToString();
        DownButton.interactable = true;
    }
    public void OnClickUpButton()
    {
        if (pageNum > 1)
        {
            if (pageNum % 2 == 0)
            {
                Feedback1.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, outsideY), new Vector2(centerX, centerY));
                Feedback2.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, centerY), new Vector2(centerX, -outsideY));
            }
            else
            {
                Feedback1.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, centerY), new Vector2(centerX, -outsideY));
                Feedback2.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, outsideY), new Vector2(centerX, centerY));
            }
            DownButton.interactable = true;
            pageNum--;
            PageNum.text = pageNum.ToString();

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

                Feedback1.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, -outsideY), new Vector2(centerX, centerY));
                Feedback2.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, centerY), new Vector2(centerX, outsideY));
            }
            else
            {
                Feedback1.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, centerY), new Vector2(centerX, outsideY));
                Feedback2.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, -outsideY), new Vector2(centerX, centerY));
            }
            UpButton.interactable = true;
            pageNum++;
            PageNum.text = pageNum.ToString();
        }
        if(pageNum == feedbackTotal)
        {
            DownButton.interactable = false;
        }
    }
    
}
