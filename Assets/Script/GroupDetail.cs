using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupDetail : MonoBehaviour
{
    private float DonjonBar = 0;
    private Image image;
    private List<PlayerModel> MyGroup;

    public void IdoTheDonjon()
    {   
        image = GameObject.FindGameObjectWithTag("Img").GetComponent<Image>();
        InvokeRepeating("DonjonProgress", 0.0f, 1.0f); 
    }

    public void DonjonProgress()
    {
        DonjonBar += 0.1f;
        image.fillAmount = DonjonBar;
        if (DonjonBar >= 1.0f)
        {
            GroupManager GM = GameObject.FindGameObjectWithTag("Event").GetComponent<GroupManager>();
            bool isWin = GM.GroupWinDonjon(MyGroup, 20);
            if (isWin == true)
            {
                image.color = Color.green;
                CancelInvoke("DonjonProgress");
            }
            Destroy(gameObject);
        }
    }

    public void ConfigGroup(List<PlayerModel> ActualGroup)
    {
        MyGroup = ActualGroup;
        Transform[] Objects = GetAllChildren();

        foreach (Transform Object in Objects)
        {
            if (Object.name == "teammate1")
            {
                SpriteRenderer spriteRenderer = Object.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = ActualGroup[0].Icon;
            }

            if (Object.name == "teammate2")
            {
                SpriteRenderer spriteRenderer = Object.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = ActualGroup[1].Icon;
            }

            if (Object.name == "teammate3")
            {
                SpriteRenderer spriteRenderer = Object.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = ActualGroup[2].Icon;
            }
        }
        IdoTheDonjon();
    }

    Transform[] GetAllChildren()
    {
        int nombreEnfants = transform.childCount;
        Transform[] enfants = new Transform[nombreEnfants];

        for (int i = 0; i < nombreEnfants; i++)
        {
            enfants[i] = transform.GetChild(i);
        }

        return enfants;
    }
}
