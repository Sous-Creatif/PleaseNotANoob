using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int Id;
    public Sprite Icon;
    public string Race;
    public string Classe;
    public List<ItemModel> Stuffs;
    public string Name;
    public string Lvl;

    void Start()
    {
        ShowPlayer();
    }

    public void ShowPlayer()
    {
        Transform[] Objects = GetAllChildren();

        foreach (Transform Object in Objects)
        {
            if (Object.name == "Icon")
            {
                SpriteRenderer spriteRenderer = Object.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Icon;
            }

            if (Object.name == "Item")
            {
                Stuff_SetUp(Object, 0);
            }

            if (Object.name == "Item (1)")
            {
                Stuff_SetUp(Object, 1);
            }

            if (Object.name == "Item (2)")
            {
                Stuff_SetUp(Object, 2);
            }

            if (Object.name == "Item (3)")
            {
                Stuff_SetUp(Object, 3);
            }

            if (Object.name == "Canvas")
            {
                TextMeshProUGUI[] textMeshPro = Object.GetComponentsInChildren<TextMeshProUGUI>();
                textMeshPro[0].text = Name;
                textMeshPro[1].text = Lvl;
            } 

            if (Object.name == "Rank")
            {
                PlayerRankTab Tab = GameObject.FindGameObjectWithTag("Event").GetComponent<PlayerRankTab>();
                SpriteRenderer spriteRenderer = Object.GetComponent<SpriteRenderer>();
                var infos = Tab.GetPlayerInfo(Race, Classe);
                spriteRenderer.sprite = RankToSprite(infos.Rank);

            }

            if (Object.name == "Spe")
            {
                PlayerRankTab Tab = GameObject.FindGameObjectWithTag("Event").GetComponent<PlayerRankTab>();
                SpriteRenderer spriteRenderer = Object.GetComponent<SpriteRenderer>();
                var infos = Tab.GetPlayerInfo(Race, Classe);
                spriteRenderer.sprite = SpeToSprite(infos.Spe);
            }
        }
    }

    public Sprite SpeToSprite(string SpeName)
    {
        List<Sprite> SpeSprite = GameObject.FindGameObjectWithTag("Event").GetComponent<ItemsList>().Spes; 

        switch (SpeName) 
        {
        case "dps":
            return SpeSprite[0];
        case "tank":
            return SpeSprite[1];
        case "healer":
            return SpeSprite[2];
        }
        return SpeSprite[1];
    }


    public Sprite RankToSprite(string RankName)
    {
        List<Sprite> RankSprite = GameObject.FindGameObjectWithTag("Event").GetComponent<ItemsList>().Ranks; 

        switch (RankName) 
        {
        case "RankS":
            return RankSprite[0];
        case "RankA":
            return RankSprite[1];
        case "RankB":
            return RankSprite[2];
        case "RankC":
            return RankSprite[3];
        case "RankF":
            return RankSprite[4];
        }
        return RankSprite[1];
    }


    public void Stuff_SetUp(Transform Object ,int index)
    {
        GameObject ActualItem = Object.gameObject;
        Item newItemComponent = ActualItem.AddComponent<Item>();

        newItemComponent.Icon = Stuffs[index].Icon;
        newItemComponent.Rank = Stuffs[index].Rank;
        newItemComponent.Spe = Stuffs[index].Spe;
        newItemComponent.Name = Stuffs[index].Name;
        newItemComponent.Lvl = Stuffs[index].Lvl;
        newItemComponent.Detail = GameObject.FindGameObjectWithTag("Event").GetComponent<ItemsList>().PrefabDetail;;
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
