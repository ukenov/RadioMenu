using Mono.Data.Sqlite;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextFields : MonoBehaviour
{
    public TextMeshProUGUI field_one;
    public TextMeshProUGUI field_two;
    public TextMeshProUGUI field_three;
    public TextMeshProUGUI field_four;
    public TextMeshProUGUI field_five;
    public TextMeshProUGUI field_six;

    public Button EditBtn;
    public GameObject Input_one;
    public GameObject Input_two;
    public GameObject Input_three;
    public GameObject Input_four;
    public GameObject Input_five;
    public GameObject Input_six;

    void Update()
    {
        field_one.text = DB.firstCircleText;
        field_two.text = DB.secondCircleText;
        field_three.text = DB.thirdCircleText;
        field_four.text = DB.fourthCircleText;
        field_five.text = DB.fifthCircleText;
        field_six.text = DB.sixthCircleText;
    }


    public void UpdateFields()
    {
        EditField(Input_one, DB.firstCircleID, field_one);
        EditField(Input_two, DB.secondCircleID, field_two);
        EditField(Input_three, DB.thirdCircleID, field_three);
        EditField(Input_four, DB.fourthCircleID, field_four);
        EditField(Input_five, DB.fifthCircleID, field_five);
        EditField(Input_six, DB.sixthCircleID, field_six);
    }

    public void EditField(GameObject someInput, int circleFieldId, TextMeshProUGUI field)
    {
        if (someInput.GetComponent<TMP_InputField>().text != "")
        {
            string newText = someInput.GetComponent<TMP_InputField>().text;
            if(circleFieldId == DB.firstCircleID)
            {
                DB.firstCircleText = newText;
            }
            else if(circleFieldId == DB.secondCircleID)
            {
                DB.secondCircleText = newText;
            }
            else if (circleFieldId == DB.thirdCircleID)
            {
                DB.thirdCircleText = newText;
            }
            else if (circleFieldId == DB.fourthCircleID)
            {
                DB.fourthCircleText = newText;
            }
            else if (circleFieldId == DB.fifthCircleID)
            {
                DB.fifthCircleText = newText;
            }
            else if (circleFieldId == DB.sixthCircleID)
            {
                DB.sixthCircleText = newText;
            }

            
            string path = Application.dataPath + "/circlesjson.json";
            string jsonString = File.ReadAllText(path);
            JSONObject circleJson = (JSONObject)JSON.Parse(jsonString);
            
            for (int i = 0; i < circleJson["circleFields"].Count; i++)
            {
                if (circleJson["circleFields"][i]["id"] == circleFieldId)
                {
                    circleJson["circleFields"][i]["value"] = newText;
                    File.WriteAllText(path, circleJson.ToString());
                }
            }
            File.WriteAllText(path, circleJson.ToString());

            someInput.GetComponent<TMP_InputField>().text = "";
        }

        
        bool boolvalue = someInput.activeSelf;
        switch (boolvalue)
        {
            case true:
                someInput.SetActive(false);
                
                break;
            case false:
                
                someInput.SetActive(true);
                //someInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TMP_Text>().text = field.text;
                break;
        }
        
    }
}
