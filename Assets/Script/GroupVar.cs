using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupVar : MonoBehaviour
{
    public static List<List<PlayerModel>> EveryGroups = new List<List<PlayerModel>>();
    public List<PlayerModel> TmpGroup = new List<PlayerModel>();
    public GameObject PrefabGroup;

    public static int groupIn = 0;
    public static int groupId = 0;

    //Group tmp
    public void ResetTmp()
    {
        TmpGroup = new List<PlayerModel>();
    }

    public void AddToTmp(PlayerModel newPlayer)
    {
        TmpGroup.Add(newPlayer);
    }

    //EveryGroup
    public void NewGroup(List<PlayerModel> Group)
    {
        EveryGroups.Add(Group);
    }

    public List<PlayerModel> GetThisGroup(int i)
    {
        if (EveryGroups.Count > 0)
        {
            Debug.Log("PLUS QUE 1");
        }
        return EveryGroups[i];
    }

    public void ResetEvery()
    {
        EveryGroups = new List<List<PlayerModel>>();
    }

    // Group Id
    public void PlusId()
    {
        groupId +=1;
    }

    public int GetGroupID()
    {
        return groupId;
    }

    // How many in group
    public void PlusGroup()
    {
        groupIn += 1;
    }

    public void LessGroup()
    {
        groupIn -= 1;
    }

    public void ResetGroup()
    {
        groupIn = 0;
    }

    public int GetGroupIn()
    {
        return groupIn;
    }
}
