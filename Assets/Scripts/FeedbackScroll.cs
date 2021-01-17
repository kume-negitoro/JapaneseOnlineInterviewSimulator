using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FeedbackScroll : MonoBehaviour
{
    public float elapsedTime = 0.0f;
    public float totalTime;
    public Vector2 initPosition;
    public Vector2 finPosition;
    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = this.transform as RectTransform;
    }
    // Update is called once per frame
    void Update()
    {
        if (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            Vector2 pos = easeOutQuart(elapsedTime, totalTime, initPosition, finPosition);
            rect.anchoredPosition = pos;
        }
    }
    public void startTrans(Vector2 init, Vector2 fin)
    {
        initPosition = init;
        finPosition = fin;
        elapsedTime = 0.0f;
    }
    public static Vector2 easeOutQuart(float t, float totaltime, Vector2 min, Vector2 max)
    {
        max -= min;
        t = t / totaltime - 1;
        return -max * (t * t * t * t - 1) + min;
    }
}
