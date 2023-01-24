using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonColor : MonoBehaviour
{
    [SerializeField]
    private GameObject thisBaloon;

    private int randomInt;
    private int loadedNumber;
    

    public List<Color> colorList;

    void Start()
    {
        loadedNumber = PlayerPrefs.GetInt("availableColors", 3);
        randomInt = UnityEngine.Random.Range(0, loadedNumber);
        thisBaloon.GetComponent<MeshRenderer>().material.color = colorList[randomInt];
    }

    public void AddColorToList(Color newColor)
    {
        colorList.Add(newColor);
    }

    public void UnlockColor()
    {
        PlayerPrefs.SetInt("availableColors", 4);
    }
}

/*
 // Find the BalloonColor game object and get the script component
BalloonColor balloonColor = GameObject.Find("BalloonColor").GetComponent<BalloonColor>();

// Add a new color to the list
balloonColor.AddColorToList(Color.purple);

*/