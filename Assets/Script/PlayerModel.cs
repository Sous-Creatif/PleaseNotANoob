using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : ScriptableObject
{
    public int Id;
    public Sprite Icon;
    public string Race;
    public string Classe;
    public List<ItemModel> Stuffs;
    public string Name;
    public string Lvl;

    public void Init(int id, Sprite icon, string race, string classe, List<ItemModel> stuffs, string name, string lvl)
    {
        Id = id;
        Icon = icon;
        Race = race;
        Classe = classe;
        Stuffs = stuffs;
        Name = name;
        Lvl = lvl;
    }
}
