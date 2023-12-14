using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopResult : MonoBehaviour
{
    public GameObject Winlogo;
    public GameObject Loselogo;

    public void ShowResult(bool isWin)
    {
        happybarLogic BAR = GameObject.FindGameObjectWithTag("HappyBar").GetComponent<happybarLogic>();
        GameObject Pop;
        if (isWin == true)
        {
            Pop = Instantiate(Winlogo, new Vector3(0,0,0), Quaternion.identity);
            PopLogic PoL = Pop.AddComponent<PopLogic>();
            PoL.Anim();
            BAR.PlusHappy();
        }
        else if(isWin == false)
        {
            Pop = Instantiate(Loselogo, new Vector3(0,0,0), Quaternion.identity);
            PopLogic PoL = Pop.AddComponent<PopLogic>();
            PoL.Anim();
            BAR.LessHappy();
        }
    }
}
