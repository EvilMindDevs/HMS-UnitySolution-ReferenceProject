using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToPop : MonoBehaviour, IPopper<GameObject>, IScore<GameObject>
{
    private short thisScoreOnClick;

    private int blackBalloonCount;
    private int blueBalloonCount;
    private int greenBalloonCount;

    public AudioSource popSound;
    public Camera myCamera;

    //encapsulation
    public short ThisScoreOnClick { get => thisScoreOnClick; }
    public int BlackBalloonCount { get => blackBalloonCount; }
    public int BlueBalloonCount { get => blueBalloonCount;  }
    public int GreenBalloonCount { get => greenBalloonCount;  }




    void Update()
    {
        OnClickBalloon();
    }

    public void OnClickBalloon()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Set up the raycast
            Vector2 mousePosition = Input.mousePosition;
            Ray ray = myCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            // Check if the raycast hits an object
            if (Physics.Raycast(ray, out hit))
            {
                OnRaycastHitSomething(hit);
            }
        }
    }

    private void OnRaycastHitSomething(RaycastHit hit)
    {
        if (hit.transform != null && hit.transform.CompareTag(Constants.balloonTag))
        {
            BalloonPopFunc(hit.transform.gameObject);
        }
    }

    public void BalloonPopFunc(GameObject go)
    {
        popSound.Play();
        go.SetActive(false);
        thisScoreOnClick = ScorePoint(go);
        GameObject.Find(Constants.gameControllerObject).GetComponent<TotalScore>().GetFinalScore(thisScoreOnClick);
        
    }

    public short ScorePoint(GameObject go)
    {
        var balloonColor = go.GetComponent<MeshRenderer>().material.color;

        var black = go.GetComponent<BalloonColor>().colorList[0];
        var blue = go.GetComponent<BalloonColor>().colorList[1];
        var green = go.GetComponent<BalloonColor>().colorList[2];

        if (balloonColor == black)
        {
            UIController uiController = FindObjectOfType<UIController>();
            uiController.EndTheGame();

            return 0;
        }
        else if (balloonColor == blue)
        {
            blueBalloonCount++;
            return Constants.blueBalloonScoreOnClick;
        }
        else if (balloonColor == green)
        {
            greenBalloonCount++;
            return Constants.greenBalloonScoreOnClick;
        }
        else
            return Constants.otherBalloonScoreOnClick;
    }

}

