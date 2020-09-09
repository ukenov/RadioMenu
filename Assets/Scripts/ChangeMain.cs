using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMain : MonoBehaviour
{
    public Button ForwardBtn;
    public Button BackBtn;

    public void MoveForward()
    {
        int s = 0;
        int[] idFields = { DB.firstCircleID, DB.secondCircleID, DB.thirdCircleID, DB.fourthCircleID, DB.fifthCircleID, DB.sixthCircleID };
        string[] textFields = { DB.firstCircleText, DB.secondCircleText, DB.thirdCircleText, DB.fourthCircleText, DB.fifthCircleText, DB.sixthCircleText };

        string path = Application.dataPath + "/circlesjson.json";
        string jsonString = File.ReadAllText(path);
        JSONObject circleJson = (JSONObject)JSON.Parse(jsonString);

        int i = circleJson["mainCircles"].Count;
        if (i > DB.mainCircleId)
        {
            DB.mainCircleId += 1;
            DB.innerCircleId = 0;

            for (int k = 0; k < circleJson["circleFields"].Count; k++)
            {
                if (circleJson["circleFields"][k]["main_id"] == DB.mainCircleId && circleJson["circleFields"][k]["innercircle_id"] == 0)
                {
                    idFields[s] = circleJson["circleFields"][k]["id"];
                    textFields[s] = circleJson["circleFields"][k]["value"];
                    s++;
                }
            }

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

    public void MoveBackwards()
    {
        int s = 0;
        int[] idFields = { DB.firstCircleID, DB.secondCircleID, DB.thirdCircleID, DB.fourthCircleID, DB.fifthCircleID, DB.sixthCircleID };
        string[] textFields = { DB.firstCircleText, DB.secondCircleText, DB.thirdCircleText, DB.fourthCircleText, DB.fifthCircleText, DB.sixthCircleText };

        string path = Application.dataPath + "/circlesjson.json";
        string jsonString = File.ReadAllText(path);
        JSONObject circleJson = (JSONObject)JSON.Parse(jsonString);

        int i = circleJson["mainCircles"].Count;
        if (DB.mainCircleId <= i && DB.mainCircleId != 1)
        {
            DB.mainCircleId -= 1;
            DB.innerCircleId = 0;

            for (int k = 0; k < circleJson["circleFields"].Count; k++)
            {
                if (circleJson["circleFields"][k]["main_id"] == DB.mainCircleId && circleJson["circleFields"][k]["innercircle_id"] == 0)
                {
                    idFields[s] = circleJson["circleFields"][k]["id"];
                    textFields[s] = circleJson["circleFields"][k]["value"];
                    s++;
                }
            }

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
}
