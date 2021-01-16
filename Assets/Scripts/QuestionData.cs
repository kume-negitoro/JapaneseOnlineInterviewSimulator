using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionData
{
    public string question;
    public List<string> answers;
    public List<int> answerScores;
    public int userAnswer;

    public QuestionData(string question, List<string> answers, List<int> answerScores)
    {
        this.question = question;
        this.answers = answers;
        this.answerScores = answerScores;
    }

    public void select(int answer)
    {
        this.userAnswer = answer;
    }

    public List<string> getAnswers()
    {
        return this.answers;
    }
}
