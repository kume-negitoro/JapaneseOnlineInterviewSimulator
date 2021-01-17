using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskBarController : MonoBehaviour
{
    [SerializeField]
    GameObject vBackToggle;
    [SerializeField]
    GameObject notifyToggle;
    [SerializeField]
    GameObject backGround;

    [SerializeField]
    Sprite badBackGround;
    [SerializeField]
    Sprite goodBackGround;

    // Start is called before the first frame update
    void Start()
    {
        vBackToggle.GetComponent<Button>().onClick.AddListener(ToggleVBack);
        notifyToggle.GetComponent<Button>().onClick.AddListener(ToggleNotify);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToggleVBack()
    {
        GameStatus.vBackEnabled = !GameStatus.vBackEnabled;

        if(GameStatus.vBackEnabled)
        {
            vBackToggle.GetComponentInChildren<Text>().text = "バーチャル背景：オン";
            backGround.GetComponent<Image>().sprite = goodBackGround;
        }
        else{
            vBackToggle.GetComponentInChildren<Text>().text = "バーチャル背景：オフ";
            backGround.GetComponent<Image>().sprite = badBackGround;
        }
    }

    void ToggleNotify()
    {
        GameStatus.snsNotifyEnabled = !GameStatus.snsNotifyEnabled;
        if(GameStatus.snsNotifyEnabled)
        {
            notifyToggle.GetComponentInChildren<Text>().text = "SNS通知：オン";
        }
        else
        {
            notifyToggle.GetComponentInChildren<Text>().text = "SNS通知：オフ";
        }
    }
}
