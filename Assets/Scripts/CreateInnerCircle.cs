using Mono.Data.Sqlite;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CreateInnerCircle : MonoBehaviour
{
    public Button CreateInnerCircle_one;
    public Button CreateInnerCircle_two;
    public Button CreateInnerCircle_three;
    public Button CreateInnerCircle_four;
    public Button CreateInnerCircle_five;
    public Button CreateInnerCircle_six;

    public void FirstClicked()
    {
        NewInner(DB.firstCircleID);
    }

    public void SecondClicked()
    {
        NewInner(DB.secondCircleID);
    }

    public void ThirdClicked()
    {
        NewInner(DB.thirdCircleID);
    }

    public void FourthClicked()
    {
        NewInner(DB.fourthCircleID);
    }

    public void FifthClicked()
    {
        NewInner(DB.fifthCircleID);
    }

    public void SixthClicked()
    {
        NewInner(DB.sixthCircleID);
    }

        
    private void NewInner(int fieldId)
    {
        string path = Application.dataPath + "/circlesjson.json";
        string jsonString = File.ReadAllText(path);
        JSONObject circleJson = (JSONObject)JSON.Parse(jsonString);

        //Create new inner circle
        int i = circleJson["innerCircles"].Count;
        circleJson["innerCircles"][i]["id"] = i + 1;
        circleJson["innerCircles"][i]["main_id"] = DB.mainCircleId;
        circleJson["innerCircles"][i]["field_id"] = fieldId;
        File.WriteAllText(path, circleJson.ToString());

        // Save old value
        DBForBack.firstCircleID = DB.firstCircleID;
        DBForBack.secondCircleID = DB.secondCircleID;
        DBForBack.thirdCircleID = DB.thirdCircleID;
        DBForBack.fourthCircleID = DB.fourthCircleID;
        DBForBack.fifthCircleID = DB.fifthCircleID;
        DBForBack.sixthCircleID = DB.sixthCircleID;

        DBForBack.firstCircleText = DB.firstCircleText;
        DBForBack.secondCircleText = DB.secondCircleText;
        DBForBack.thirdCircleText = DB.thirdCircleText;
        DBForBack.fourthCircleText = DB.fourthCircleText;
        DBForBack.fifthCircleText = DB.fifthCircleText;
        DBForBack.sixthCircleText = DB.sixthCircleText;

        // Create circlefields for that inner circle
        DB.firstCircleID = CreateCircleFields(i + 1);
        DB.secondCircleID = CreateCircleFields(i + 1);
        DB.thirdCircleID = CreateCircleFields(i + 1);
        DB.fourthCircleID = CreateCircleFields(i + 1);
        DB.fifthCircleID = CreateCircleFields(i + 1);
        DB.sixthCircleID = CreateCircleFields(i + 1);

        DB.firstCircleText = "";
        DB.secondCircleText = "";
        DB.thirdCircleText = "";
        DB.fourthCircleText = "";
        DB.fifthCircleText = "";
        DB.sixthCircleText = "";

        DB.innerCircleId = i + 1;
    }

    private int CreateCircleFields(int innerId)
    {
        string path = Application.dataPath + "/circlesjson.json";
        string jsonString = File.ReadAllText(path);
        JSONObject circleJson = (JSONObject)JSON.Parse(jsonString);

        int s = circleJson["circleFields"].Count;

        circleJson["circleFields"][s]["id"] = s + 1;
        circleJson["circleFields"][s]["value"] = "";
        circleJson["circleFields"][s]["innercircle_id"] = innerId;
        circleJson["circleFields"][s]["main_id"] = DB.mainCircleId;

        File.WriteAllText(path, circleJson.ToString());
        int fieldId = s + 1;
        return fieldId;
    }

}
