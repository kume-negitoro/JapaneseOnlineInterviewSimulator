using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class QuestionData
{
    public string question;
    public List<string> answers;
    public int userAnswer;

    public QuestionData(string question, List<string> answers)
    {
        this.question = question;
        this.answers = answers;
    }

    public void select(int answer)
    {
        this.userAnswer = answer;
    }
}
