using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    [Header("List : ")]
    public List<Sprite> Icons;
    public List<Sprite> Ranks;
    public List<Sprite> Spes;
    public List<string> Names;
    public List<string> Lvls;

    public List<ItemModel> AllItems;

    public GameObject PrefabIcon;
    public GameObject PrefabDetail;

    public static int toX = 0;

    void Start()
    {
        Items_Generator(20);
    }

    public void Show_item(int x, int y, int z)
    {
        GameObject Obj = Instantiate(PrefabIcon, new Vector3(x, y, z), Quaternion.identity);

        ItemModel NewItem = AllItems[Random.Range(0, AllItems.Count)];
        Item newItemComponent = Obj.AddComponent<Item>();

        newItemComponent.Id = NewItem.Id;
        newItemComponent.Icon = NewItem.Icon;
        newItemComponent.Rank = NewItem.Rank;
        newItemComponent.Spe = NewItem.Spe;
        newItemComponent.Name = NewItem.Name;
        newItemComponent.Lvl = NewItem.Lvl;
        newItemComponent.Detail = PrefabDetail;
    }

    public void Show_stuff()
    {
        for (int i = 0; i < 4; i++)
        {
            Show_item(i,0,0);
        }
    }

    public void Items_Generator(int x)
    {
        while (x > toX)
        {
            ItemModel newItem = ScriptableObject.CreateInstance<ItemModel>();
            newItem.Init(toX, GetASprite(Icons), GetASprite(Ranks), GetASprite(Spes), GetAName(), GetALvl());
            AllItems.Add(newItem);
            toX += 1;
        }
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
