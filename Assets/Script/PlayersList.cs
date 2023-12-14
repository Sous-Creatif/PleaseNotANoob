using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersList : MonoBehaviour
{
    [Header("List : ")]
    public List<Sprite> Icons;
    public List<string> Races;
    public List<string> Classes;
    public List<ItemModel> Stuffs;
    public List<string> Names;
    public List<string> Lvls;

    public List<PlayerModel> AllPlayers;

    public static int toX = 0;

    public GameObject PrefabDetails;
    public GameObject PrefabScroll;

    public RectTransform contentRectTransform;
    public Transform contentTransform;

    void Start()
    {
        PlayersGenerator(10);
    }

    public void PlayersGenerator(int x)
    {
        Stuffs = GetComponent<ItemsList>().AllItems;

        while (x > toX)
        {
            PlayerModel newPlayer = ScriptableObject.CreateInstance<PlayerModel>();
            newPlayer.Init(toX, GetASprite(Icons), GetARace(), GetAClasses(), GetItems(), GetAName(), GetALvl());
            AllPlayers.Add(newPlayer);
            toX += 1;
        }
    }

    public void Display_Scroll_Players()
    {
        if (GameObject.FindGameObjectWithTag("Scroll") == null)
        {
            GameObject scrollViewObject = Instantiate(PrefabScroll, new Vector3(10,0,0), Quaternion.identity);
            Canvas canvas = scrollViewObject.GetComponentInChildren<Canvas>();
            ScrollRect childScrollView = canvas.GetComponentInChildren<ScrollRect>();

            RectTransform scrollViewRectTransform = childScrollView.GetComponent<RectTransform>();
            contentTransform = childScrollView.content.transform;
            contentRectTransform = childScrollView.content.GetComponent<RectTransform>();

            Vector3 startPosition = new Vector3(0, -200, 0);
            contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, (AllPlayers.Count - 1) * 70); 

            foreach (PlayerModel playerModel in AllPlayers)
            {
                GameObject playerGameObject = Create_Object_Player(playerModel);
                Vector3 playerPosition = scrollViewRectTransform.TransformPoint(startPosition);
                playerGameObject.transform.position = playerPosition;
                playerGameObject.transform.SetParent(contentTransform, true);
                startPosition.y -= 70; 
            }
        }
    }

    public GameObject Create_Object_Player(PlayerModel WhatAPlayer)
    {
        Vector3 PlayerObjectPos = new Vector3(0,0,0);
        GameObject Object_Player = Instantiate(PrefabDetails, PlayerObjectPos, Quaternion.identity);

        PlayerModel newPlayer = WhatAPlayer;
        Player newPlayerComponent = Object_Player.AddComponent<Player>();
        Object_Player.AddComponent<GroupManager>();

        newPlayerComponent.Id = newPlayer.Id;
        newPlayerComponent.Icon = newPlayer.Icon;
        newPlayerComponent.Race = newPlayer.Race;
        newPlayerComponent.Classe = newPlayer.Classe;
        newPlayerComponent.Stuffs = newPlayer.Stuffs;
        newPlayerComponent.Name = newPlayer.Name;
        newPlayerComponent.Lvl = newPlayer.Lvl;

        Object_Player.SetActive(false);
        return Object_Player;
    }

    public void Show_Player_Detail(int x,int y,int z, PlayerModel WhatAPlayer)
    {
        GameObject Pla = Instantiate(PrefabDetails, new Vector3(x, y, z), Quaternion.identity);

        PlayerModel newPlayer = WhatAPlayer;
        Player newPlayerComponent = Pla.AddComponent<Player>();

        newPlayerComponent.Id = newPlayer.Id;
        newPlayerComponent.Icon = newPlayer.Icon;
        newPlayerComponent.Race = newPlayer.Race;
        newPlayerComponent.Classe = newPlayer.Classe;
        newPlayerComponent.Stuffs = newPlayer.Stuffs;
        newPlayerComponent.Name = newPlayer.Name;
        newPlayerComponent.Lvl = newPlayer.Lvl;
    }


    public List<ItemModel> GetItems()
    {
        List<ItemModel> tmpStuff = new List<ItemModel>();
        if (Stuffs.Count >= 4)
        {
            for (int i = 0; i < 4; i++)
            {
                tmpStuff.Add(Stuffs[Random.Range(0, Stuffs.Count)]);
            }
        }
        return tmpStuff;
    }

    public string GetAClasses()
    {
        return Classes[Random.Range(0, Classes.Count)];
    }


    public string GetARace()
    {
        return Races[Random.Range(0, Races.Count)];
    }

    public Sprite GetASprite(List<Sprite> TmpList)
    {
        return TmpList[Random.Range(0, TmpList.Count)];
    }

    public string GetAName()
    {
        return Names[Random.Range(0, Names.Count)];
    }

    public string GetALvl()
    {
        return Lvls[Random.Range(0, Lvls.Count)];
    }
}
