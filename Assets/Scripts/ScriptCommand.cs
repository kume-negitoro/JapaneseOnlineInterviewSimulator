using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityChan;

public enum Action
{
    Lazy,
    Exec,
    Message,
    Question,
    Input,
    Audio,
    Voice,
    Face,
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

public class Lazy: ScriptCommand
{
    public System.Func<ScriptCommand> func;

    public Lazy(System.Func<ScriptCommand> func) : base(Action.Lazy, "Lazy")
    {
        this.func = func;
    }

    override public IEnumerator Execute(InterviewSceneManager manager)
    {
        yield return this.func().Execute(manager);
    }
}

public class Exec : ScriptCommand
{
    public ScriptCommand command;

    public Exec(ScriptCommand command) : base(Action.Exec, "Exec")
    {
        this.command = command;
    }

    override public IEnumerator Execute(InterviewSceneManager manager)
    {
        IEnumerator e = this.command.Execute(manager);
        while(e.MoveNext() && e.Current != null);
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

    override public IEnumerator Execute(InterviewSceneManager manager)
    {
        this.target = GameObject.Find("TextWindow");
        Text text = target.GetComponent<Text>();
        text.text = GameStatus.BindVars(message);
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
    public static Question ByKey(string key)
    {
        return new Question(GameStatus.questionDic[key]);
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

public class Face : ScriptCommand
{
    protected string face;
    
    public Face(string face) : base(Action.Face, face)
    {
        this.face = face;
    }

    override public IEnumerator Execute(InterviewSceneManager manager)
    {
        this.target = GameObject.Find("unitychan");
        FaceUpdate2 fu = target.GetComponent<FaceUpdate2>();
        fu.OnCallChangeFace(this.face);
        yield return null;
    }

    public static Lazy ByKey(string key)
    {
        return new Lazy(() => {
            int score = GameStatus.questionDic[key].GetScore();
            Debug.Log(score);
            if(score >= 50) return new Face("default@unitychan");
            return new Face("MTH_I");
        });
    }
}
