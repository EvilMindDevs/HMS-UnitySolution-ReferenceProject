using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopOnTop : MonoBehaviour, IPopper<GameObject>, IScore<GameObject>
{
    [HideInInspector]
    public short thisScoreOnTopPop;

    [HideInInspector]
    public int finalScoreOnTopPop;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.balloonTag))
        {
            BalloonPopFunc(other.gameObject);
        }
    }
    public void BalloonPopFunc(GameObject go)
    {
        go.SetActive(false);
        thisScoreOnTopPop = ScorePoint(go);
        GameObject.Find(Constants.gameControllerObject).GetComponent<TotalScore>().GetFinalScore(thisScoreOnTopPop);
                
    }
    public short ScorePoint(GameObject go)
    {
        var balloonColor = go.GetComponent<MeshRenderer>().material.color;
        var black = go.GetComponent<BalloonColor>().colorList[0];

        if (balloonColor == black)
        {
            return Constants.blackBalloonScoreOnTop;
        }
        else
            return Constants.otherBalloonScoreOnTop;
    }

}
