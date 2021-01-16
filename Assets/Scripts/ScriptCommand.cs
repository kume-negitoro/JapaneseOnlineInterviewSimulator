using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Action
{
    Lazy,
    Message,
    Question,
    Input,
    Audio,
    Voice,
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

    public virtual IEnumerator Execute(InterviewSceneManager manager)
    {
        yield return null;
    }
}

public class Lazy<CommandType> : ScriptCommand
    where CommandType : ScriptCommand
{
    public System.Func<CommandType> func;

    public Lazy(System.Func<CommandType> func) : base(Action.Lazy, "Lazy")
    {
        this.func = func;
    }

    override public IEnumerator Execute(InterviewSceneManager manager)
    {
        yield return this.func().Execute(manager);
    }
}

public class Message : ScriptCommand
{
    public string message;

    public Message(string message) : base(Action.Message, message)
    {
        this.message = message;
    }

    override public IEnumerator Execute(InterviewSceneManager manager)
    {
        this.target = GameObject.Find("TextWindow");
        Text text = target.GetComponent<Text>();
        text.text = message;
        // 何かのキーを待つ
        yield return new WaitUntil(() => Input.anyKeyDown);
        yield return null;
    }
}

public class Question : ScriptCommand
{
    protected QuestionData questionData;
    
    public Question(QuestionData data) : base(Action.Question, data.question)
    {
        this.questionData = data;
    }

    override public IEnumerator Execute(InterviewSceneManager manager)
    {
        this.target = manager.questionPanel;
        QuestionController question = target.GetComponent<QuestionController>();
        yield return question.CreateQuestion(this.questionData);
        Debug.Log(questionData.userAnswer);
        
        yield return null;
    }
}

public class Audio : ScriptCommand
{
    protected string source;
    
    public Audio(string source) : base(Action.Audio, source)
    {
        this.source = source;
    }

    override public IEnumerator Execute(InterviewSceneManager manager)
    {
        this.target = GameObject.Find("Main Camera");;
        SoundManager sm = target.GetComponent<SoundManager>();
        yield return sm.PlaySE(source);
    }
}

public class Voice : ScriptCommand
{
    protected string source;
    
    public Voice(string source) : base(Action.Voice, source)
    {
        this.source = source;
    }

    override public IEnumerator Execute(InterviewSceneManager manager)
    {
        this.target = GameObject.Find("Main Camera");
        SoundManager sm = target.GetComponent<SoundManager>();
        yield return sm.PlayVoice(source);
        // 何かのキーを待つ
        yield return new WaitUntil(() => Input.anyKeyDown);
        yield return null;
    }
}