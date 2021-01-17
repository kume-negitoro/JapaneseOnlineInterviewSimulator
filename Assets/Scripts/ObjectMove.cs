using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float elapsedTime = 0.0f;
    public float totalTime;
    Vector2 init, fin;
    // Start is called before the first frame update
    void Start()
    {
        init = new Vector2(Random.Range(-9, 9), Random.Range(-6, 6));
        fin = new Vector2(Random.Range(-9, 9), Random.Range(-6, 6));
        this.GetComponent<FeedbackScroll>().startTrans(init, fin);
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            init = fin;
            fin = new Vector2(Random.Range(-9, 9), Random.Range(-6, 6));
            this.GetComponent<FeedbackScroll>().startTrans(init, fin);
            elapsedTime = 0;
        }
    }
}
