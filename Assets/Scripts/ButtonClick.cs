using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Button mbutton;
    private float secondsCount;
    private bool conditionForTime;

    //[SerializeField] Image CircleImage;

    
    void Update()
    {
        UpdateTimer();
    }

    void Awake()
    {
        mbutton = transform.GetComponent<Button>();
    }

    //when pointer click, set the cube color to random color
    public void OnPointerClick(PointerEventData eventData)
    {
        //mbutton.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    //when pointer hover, set the cube color to green
    public void OnPointerEnter(PointerEventData eventData)
    {
        conditionForTime = true;
        StartCoroutine(ExecuteAfterTime(2));
        
    }

    //when pointer exit hover, set the cube color to white
    public void OnPointerExit(PointerEventData eventData)
    {
        secondsCount = 0;
        conditionForTime = false;
    }

    public void UpdateTimer()
    {
        if(conditionForTime)
        {
            secondsCount += Time.deltaTime;
            //CircleImage.fillAmount = secondsCount / 2;
            //Debug.Log(secondsCount);
        }
    }

    //delay
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        if (secondsCount > 2)
        {
            mbutton.onClick.Invoke();
        }
    }
}
