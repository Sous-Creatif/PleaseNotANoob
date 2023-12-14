using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDetail : MonoBehaviour
{

    public void Show_item_detail(Sprite Icon, Sprite Rank, Sprite Spe, string Name, string Lvl)
    {
        Transform[] Objects = GetAllChildren();

        foreach (Transform Object in Objects)
        {
            if (Object.name == "ItemIcon")
            {
                SpriteRenderer spriteRenderer = Object.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Icon;
            }

            if (Object.name == "ItemRank")
            {
                SpriteRenderer spriteRenderer = Object.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Rank;
            }

            if (Object.name == "ItemSpe")
            {
                SpriteRenderer spriteRenderer = Object.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Spe;
            }

            if (Object.name == "Canvas")
            {
                TextMeshProUGUI[] textMeshPro = Object.GetComponentsInChildren<TextMeshProUGUI>();
                textMeshPro[0].text = Name;
                textMeshPro[1].text = Lvl;
            } 
        }
    }

    //chatgpt
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
