using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestionData
{
    public string question;
    public List<string> answers;
    public List<int> answerScores;
    public string answerFeedback;
    public int userAnswer;

    public QuestionData(string question, List<string> answers, List<int> answerScores, string answerFeedback)
    {
        this.question = question;
        this.answers = answers;
        this.answerScores = answerScores;
        this.answerFeedback = answerFeedback;
    }

    public string GetQuestion()
    {
        return this.question;
    }

    public string GetAnswer()
    {
        return this.answers[this.userAnswer];
    }

    public int GetScore()
    {
        return this.answerScores[this.userAnswer];
    }

    public void select(int answer)
    {
        this.userAnswer = answer;
    }
    public List<string> getAnswers()
    {
        return this.answers;
    }
    public string getAnswerFeedback()
    {
        return this.answerFeedback;
    }
}
