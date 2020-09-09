using Mono.Data.Sqlite;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewCircle : MonoBehaviour
{
    public Button CreateNewCircleBtn;

    public void NewMain()
    {
        string path = Application.dataPath + "/circlesjson.json";
        string jsonString = File.ReadAllText(path);
        JSONObject circleJson = (JSONObject)JSON.Parse(jsonString);

        //Create new main circle
        int i = circleJson["mainCircles"].Count;
        i += 1;
        circleJson["mainCircles"][-1]["id"] = i;
        File.WriteAllText(path, circleJson.ToString());

        DB.mainCircleId = i;

        // Create circlefields for that main circle
        DB.firstCircleID = CreateCircleFields(i);
        DB.secondCircleID = CreateCircleFields(i);
        DB.thirdCircleID = CreateCircleFields(i);
        DB.fourthCircleID = CreateCircleFields(i);
        DB.fifthCircleID = CreateCircleFields(i);
        DB.sixthCircleID = CreateCircleFields(i);

        DB.firstCircleText = "";
        DB.secondCircleText = "";
        DB.thirdCircleText = "";
        DB.fourthCircleText = "";
        DB.fifthCircleText = "";
        DB.sixthCircleText = "";

        DB.innerCircleId = 0;
    }

    private int CreateCircleFields(int mainId)
    {
        string path = Application.dataPath + "/circlesjson.json";
        string jsonString = File.ReadAllText(path);
        JSONObject circleJson = (JSONObject)JSON.Parse(jsonString);

        int s = circleJson["circleFields"].Count;
        
        circleJson["circleFields"][s]["id"] = s + 1;
        circleJson["circleFields"][s]["value"] = "";
        circleJson["circleFields"][s]["innercircle_id"] = 0;
        circleJson["circleFields"][s]["main_id"] = mainId;
        
        File.WriteAllText(path, circleJson.ToString());
        int fieldId = s + 1;
        return fieldId;
    }
    
}
