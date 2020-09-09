using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
using System.IO;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;
    public Button submitBtn;

    private string JsonUserName;
    private string JsonPassword;

    public void CallRegister()
    {
        StartCoroutine(RegisterUser());
    }

    public void CallLogin()
    {
        StartCoroutine(LoginUser());
    }

    IEnumerator RegisterUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User created successfully");
            SaveJson();
        }
        else
        {
            Debug.Log("Use creation failed. Error #" + www.text);
        }
    }

    IEnumerator LoginUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        LoadJson();
        try
        {
            if (www.text[0] == '0')
            {
                DB.username = nameField.text;
                string useridstring = www.text;
                string trimmedID = useridstring.TrimStart('0', ' ');
                DB.userid = Convert.ToInt32(trimmedID);
                Debug.Log("Login works");
                LoadMain();
                SceneManager.LoadScene(1);
            }
        }
        catch
        {
           Debug.Log("User login failed. Error #" + www.text);
        }
        finally
        {
            if (JsonUserName == nameField.text && JsonPassword == passwordField.text)
            {
                DB.userid = 1;
                DB.username = nameField.text;
                Debug.Log("Login from JSON working");
                LoadMain();
                SceneManager.LoadScene(1);
            }
        }
    }

    private void SaveJson()
    {
        JSONObject userJson = new JSONObject();
        userJson.Add("Username", nameField.text);
        userJson.Add("Password", passwordField.text);

        string path = Application.dataPath + "/user.json";
        File.WriteAllText(path, userJson.ToString());
    }

    private void LoadJson()
    {
        string path = Application.dataPath + "/user.json";
        string jsonString = File.ReadAllText(path);
        JSONObject userJson = (JSONObject)JSON.Parse(jsonString);
        JsonUserName = userJson["Username"];
        JsonPassword = userJson["Password"];
    }

    private void LoadMain()
    {
        string path = Application.dataPath + "/circlesjson.json";
        string jsonString = File.ReadAllText(path);
        JSONObject circleJson = (JSONObject)JSON.Parse(jsonString);
        
        DB.mainCircleId = 1;

        DB.firstCircleID = 1;
        DB.secondCircleID = 2;
        DB.thirdCircleID = 3;
        DB.fourthCircleID = 4;
        DB.fifthCircleID = 5;
        DB.sixthCircleID = 6;

        DB.firstCircleText = circleJson["circleFields"][0]["value"];
        DB.secondCircleText = circleJson["circleFields"][1]["value"];
        DB.thirdCircleText = circleJson["circleFields"][2]["value"];
        DB.fourthCircleText = circleJson["circleFields"][3]["value"];
        DB.fifthCircleText = circleJson["circleFields"][4]["value"];
        DB.sixthCircleText = circleJson["circleFields"][5]["value"];
    }
}