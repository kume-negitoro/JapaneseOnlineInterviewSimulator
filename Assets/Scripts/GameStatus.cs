using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public static class GameStatus
{
    // バーチャル背景のオン
    public static bool vBackEnabled = false;
    // SNS通知のオン
    public static bool snsNotifyEnabled = true;
    //名前
    public static string playerName = "名無し";
    //年齢
    public static int playerAge = 21;
    //会社名
    public static string companyName = "株式会社一般";
    //スコア
    public static int score = 0;
    //長所
    public static string pros = "";
    //短所
    public static string cons = "";
    //志望動機
    public static string motivation = "";
    //アピールポイント
    public static string appeal = "";
    //質問と回答
    public static Dictionary<string, QuestionData> questionDic = new Dictionary<string, QuestionData>();

    public static string BindVars(string text)
    {
        return Regex.Replace(text, @"(\${.+?})", new MatchEvaluator(
            match => {
                string target = Regex.Match(match.Value, @"\${(.+?)}").Groups[1].Value;
                Debug.Log(target);
                string[] attrs = target.Split('/');
                string qName = attrs[0];
                string pName = attrs.Length == 2 ? attrs[1] : "";

                switch(qName)
                {
                    case "playerName":
                        return GameStatus.playerName;
                    case "playerAge":
                        return "" + GameStatus.playerAge;
                    case "score":
                        return "" + GameStatus.score;
                    case "companyName":
                        return GameStatus.companyName;
                    case "pros":
                        return GameStatus.pros;
                    case "cons":
                        return GameStatus.cons;
                    case "motivation":
                        return GameStatus.motivation;
                    case "appeal":
                        return GameStatus.appeal;
                    default:
                        if(GameStatus.questionDic.ContainsKey(qName))
                            switch(pName)
                            {
                                case "question":
                                    return GameStatus.BindVars(
                                        GameStatus.questionDic[qName].GetQuestion()
                                    );
                                case "answer":
                                    return GameStatus.BindVars(
                                        GameStatus.questionDic[qName].GetAnswer()
                                    );
                                case "answerFeedback":
                                    return GameStatus.BindVars(
                                        GameStatus.questionDic[qName].getAnswerFeedback()
                                    );
                                // case "correct":
                                //     return GameStatus.BindVars(
                                //         GameStatus.questionDic[qName].GetCorrectAnswer()
                                //     );
                                default:
                                    return GameStatus.BindVars(
                                        GameStatus.questionDic[qName].GetQuestion()
                                    );
                            }
                        else
                            return match.Value;
                }
            }
        ));
    }
}
