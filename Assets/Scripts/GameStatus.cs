using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatus
{
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
}
