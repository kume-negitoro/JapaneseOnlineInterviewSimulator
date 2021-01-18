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

    public Image Panel1;
    public Image Panel2;
    public Text FeedbackText1_1;
    public Text FeedbackText1_2;
    public Text FeedbackText2_1;
    public Text FeedbackText2_2;
    public Text PageNum;

    public Button FeedbackButton;
    public Button UpButton;
    public Button DownButton;

    public GameObject success;
    public GameObject faile;

    int feedbackTotal;
    int pageNum;
    float centerX = 640.0f, centerY = 360.0f, outsideY = 1123;

    List<string> questionList = new List<string>();
    List<string> userAnswerList = new List<string>();
    List<string> feedbackList = new List<string>();

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

        userAverageScore = GameStatus.score / GameStatus.questionDic.Count;
        if(userAverageScore > passAverageScore)
        {
            ResultText.text = "合格です";
            faile.SetActive(false);
        }
        else
        {
            ResultText.text = "不合格です";
            success.SetActive(false);
        }

        feedbackTotal = GameStatus.questionDic.Count;

        foreach (QuestionData data in GameStatus.questionDic.Values)
        {
            questionList.Add(GameStatus.BindVars(data.GetQuestion()));
            userAnswerList.Add(GameStatus.BindVars(data.GetAnswer()));
            feedbackList.Add(GameStatus.BindVars(data.getAnswerFeedback()));
        }

        Debug.Log("あなたの平均スコアは" + userAverageScore + "でした");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickFeedbackButton()
    {
        Panel1.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, -outsideY), new Vector2(centerX, centerY));
        ResultText.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, 406), new Vector2(2000.0f, 406));
        FeedbackButton.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, 356), new Vector2(2000.0f, 356));
        pageNum = 0;
        PageNum.text = (pageNum/2+1).ToString();
        FeedbackText1_1.text = "質問："+questionList[pageNum]+"\nあなたの回答："+userAnswerList[pageNum]+"\n\nフィードバック\n"+feedbackList[pageNum];
        FeedbackText1_2.text = "質問：" + questionList[pageNum + 1] + "\nあなたの回答：" + userAnswerList[pageNum + 1] + "\n\nフィードバック\n" + feedbackList[pageNum + 1];
        DownButton.interactable = true;
    }
    public void OnClickUpButton()
    {
        if (pageNum > 0)
        {
            pageNum -= 2;
            if (pageNum % 2 == 0)
            {
                Panel1.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, outsideY), new Vector2(centerX, centerY));
                Panel2.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, centerY), new Vector2(centerX, -outsideY));
                FeedbackText1_1.text = "質問：" + questionList[pageNum] + "\nあなたの回答：" + userAnswerList[pageNum] + "\n\nフィードバック\n" + feedbackList[pageNum];
                FeedbackText1_2.text = "質問：" + questionList[pageNum + 1] + "\nあなたの回答：" + userAnswerList[pageNum + 1] + "\n\nフィードバック\n" + feedbackList[pageNum + 1];
            }
            else
            {
                Panel1.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, centerY), new Vector2(centerX, -outsideY));
                Panel2.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, outsideY), new Vector2(centerX, centerY));
                FeedbackText2_1.text = "質問：" + questionList[pageNum] + "\nあなたの回答：" + userAnswerList[pageNum] + "\n\nフィードバック\n" + feedbackList[pageNum];
                FeedbackText2_2.text = "質問：" + questionList[pageNum + 1] + "\nあなたの回答：" + userAnswerList[pageNum + 1] + "\n\nフィードバック\n" + feedbackList[pageNum + 1];
            }
            DownButton.interactable = true;
            PageNum.text = (pageNum/2+1).ToString();

        }
        if (pageNum == 0)
        {
            UpButton.interactable = false;
        }
    }
    public void OnClickDownButton()
    {
        if (pageNum < feedbackTotal)
        {
            pageNum += 2;
            if (pageNum % 2 == 0)
            {

                Panel1.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, -outsideY), new Vector2(centerX, centerY));
                Panel2.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, centerY), new Vector2(centerX, outsideY));
                FeedbackText1_1.text = "質問：" + questionList[pageNum] + "\nあなたの回答：" + userAnswerList[pageNum] + "\n\nフィードバック\n" + feedbackList[pageNum];
                FeedbackText1_2.text = "質問：" + questionList[pageNum + 1] + "\nあなたの回答：" + userAnswerList[pageNum + 1] + "\n\nフィードバック\n" + feedbackList[pageNum + 1];
            }
            else
            {
                Panel1.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, centerY), new Vector2(centerX, outsideY));
                Panel2.GetComponent<FeedbackScroll>().startTrans(new Vector2(centerX, -outsideY), new Vector2(centerX, centerY));
                FeedbackText2_1.text = "質問：" + questionList[pageNum] + "\nあなたの回答：" + userAnswerList[pageNum] + "\n\nフィードバック\n" + feedbackList[pageNum];
                FeedbackText2_2.text = "質問：" + questionList[pageNum + 1] + "\nあなたの回答：" + userAnswerList[pageNum + 1] + "\n\nフィードバック\n" + feedbackList[pageNum + 1];
            }
            UpButton.interactable = true;
            PageNum.text = (pageNum/2+1).ToString();
        }
        if(pageNum <= feedbackTotal-1)
        {
            DownButton.interactable = false;
        }
    }
    
}
