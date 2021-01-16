using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Question
{
    public string question;
    public List<string> answers;
    public int userAnswer;

    public Question(string question, List<string> answers)
    {
        this.question = question;
        this.answers = answers;
    }

    public select(int answer)
    {
        this.userAnswer = answer;
    }
}
