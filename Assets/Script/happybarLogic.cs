using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class happybarLogic : MonoBehaviour
{
    public float happyPoints;
    private Image image;

    void Start()
    {
        happyPoints = 0.5f;
        image = GetComponent<Image>();
    }

    void Update()
    {
        MoveFromRightToLeft();
    }

    public void PlusHappy()
    {
        happyPoints += 0.1f;
    }

    public void LessHappy()
    {
        happyPoints -= 0.1f;
    }

    void MoveFromRightToLeft()
    {
        image.fillAmount = happyPoints;
    }
}
