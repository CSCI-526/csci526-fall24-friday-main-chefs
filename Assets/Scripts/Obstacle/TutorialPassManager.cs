using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPassManager : MonoBehaviour
{
    private bool hasTouchedFork = false;
    private bool hasTouchedPoison = false;

    void Start()
    {

    }

    // check whether satisfy all the conditions
    public void CheckPassTutorial()
    {
        if(hasTouchedFork && hasTouchedPoison)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void TouchedFork()
    {
        hasTouchedFork = true;
        CheckPassTutorial();
    }

    public void TouchedPoison()
    {
        hasTouchedPoison = true;
        CheckPassTutorial();
    }
}