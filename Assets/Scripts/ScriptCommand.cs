using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Action
{
    Message,
    Question,
    Input,
}

public class ScriptCommand
{
    public GameObject target;
    public Action action;
    public string value;

    public ScriptCommand(Action action, string value)
    {
        this.action = action;
        this.value = value;
    }

    public virtual IEnumerator Execute(GameObject target)
    {
        yield return null;
    }
}

public class Message : ScriptCommand
{
    public string message;

    public Message(string message) : base(Action.Message, message)
    {
        this.message = message;
    }

    override public IEnumerator Execute(GameObject target)
    {
        this.target = target;
        Text text = target.GetComponent<Text>();
        text.text = message;
        yield return null;
    }
}

public class Question : ScriptCommand
{
    protected string question;
    protected List<string> options;
    
    public Question(string question, List<string> options) : base(Action.Question, question)
    {
        this.question = question;
        this.options = options;
    }

    public IEnumerator Execute(){
        yield return null;
    }
}