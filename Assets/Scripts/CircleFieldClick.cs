using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CircleFieldClick : MonoBehaviour
{
    public Button btn_one;
    public Button btn_two;
    public Button btn_three;
    public Button btn_four;
    public Button btn_five;
    public Button btn_six;
    

    public void FirstClicked()
    {
        BtnClicked(DB.firstCircleID);
    }

    public void SecondClicked()
    {
        BtnClicked(DB.secondCircleID);
    }

    public void ThirdClicked()
    {
        BtnClicked(DB.thirdCircleID);
    }

    public void FourthClicked()
    {
        BtnClicked(DB.fourthCircleID);
    }

    public void FifthClicked()
    {
        BtnClicked(DB.fifthCircleID);
    }

    public void SixthClicked()
    {
        BtnClicked(DB.sixthCircleID);
    }



    private void BtnClicked(int clickedCircleId)
    {
        int innerCircleId = 0;
        int s = 0;
        int[] idFields = { DB.firstCircleID, DB.secondCircleID, DB.thirdCircleID, DB.fourthCircleID, DB.fifthCircleID, DB.sixthCircleID };
        string[] textFields = { DB.firstCircleText, DB.secondCircleText, DB.thirdCircleText, DB.fourthCircleText, DB.fifthCircleText, DB.sixthCircleText };

        string path = Application.dataPath + "/circlesjson.json";
        string jsonString = File.ReadAllText(path);
        JSONObject circleJson = (JSONObject)JSON.Parse(jsonString);
        
        for (int i = 0; i < circleJson["innerCircles"].Count;  i++)
        {
            if(circleJson["innerCircles"][i]["field_id"].AsInt == clickedCircleId)
            {
                innerCircleId = circleJson["innerCircles"][i]["id"].AsInt;
            }
        }

        if(innerCircleId != 0)
        {
            DB.innerCircleId = innerCircleId;
        }
        else
        {
            return;
        }

        for (int i = 0; i < circleJson["circleFields"].Count; i++)
        {
            if (circleJson["circleFields"][i]["innercircle_id"] == DB.innerCircleId)
            {
                idFields[s] = circleJson["circleFields"][i]["id"];
                textFields[s] = circleJson["circleFields"][i]["value"];
                s++;
            }
        }

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

        // Assign new values to DB
        DB.firstCircleID = idFields[0];
        DB.secondCircleID = idFields[1];
        DB.thirdCircleID = idFields[2];
        DB.fourthCircleID = idFields[3];
        DB.fifthCircleID = idFields[4];
        DB.sixthCircleID = idFields[5];

        DB.firstCircleText = textFields[0];
        DB.secondCircleText = textFields[1];
        DB.thirdCircleText = textFields[2];
        DB.fourthCircleText = textFields[3];
        DB.fifthCircleText = textFields[4];
        DB.sixthCircleText = textFields[5];
    }
}
