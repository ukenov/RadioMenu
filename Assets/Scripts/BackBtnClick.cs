using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackBtnClick : MonoBehaviour
{
    public Button backBtn;

    public void GetBack()
    {
        if(DBForBack.firstCircleID != 0)
        {
            DB.firstCircleID = DBForBack.firstCircleID;
            DB.secondCircleID = DBForBack.secondCircleID;
            DB.thirdCircleID = DBForBack.thirdCircleID;
            DB.fourthCircleID = DBForBack.fourthCircleID;
            DB.fifthCircleID = DBForBack.fifthCircleID;
            DB.sixthCircleID = DBForBack.sixthCircleID;

            DB.firstCircleText = DBForBack.firstCircleText;
            DB.secondCircleText = DBForBack.secondCircleText;
            DB.thirdCircleText = DBForBack.thirdCircleText;
            DB.fourthCircleText = DBForBack.fourthCircleText;
            DB.fifthCircleText = DBForBack.fifthCircleText;
            DB.sixthCircleText = DBForBack.sixthCircleText;
        }
        
    }
}
