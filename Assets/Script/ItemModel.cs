using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel : ScriptableObject
{
    public int Id;
    public Sprite Icon;
    public Sprite Rank;
    public Sprite Spe;
    public string Name;
    public string Lvl;

    public void Init(int id, Sprite icon, Sprite rank, Sprite spe, string name, string lvl)
    {
        Id = id;
        Icon = icon;
        Rank = rank;
        Spe = spe;
        Name = name;
        Lvl = lvl;
    }
}
