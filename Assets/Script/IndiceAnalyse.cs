using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndiceAnalyse : MonoBehaviour
{
    public int AnalyseRank(string Rank)
    {
        switch(Rank)
        {
            case "RankS":
                return 5;
            case "RankA":
                return 4;
            case "RankB":
                return 3;
            case "RankC":
                return 2;
            case "RankF":
                return 1;
        }

        return 3;
    }

    public int AnalyseSpe(string PlayerSpe)
    {
        return 1;
    }

    public int AnalyseLvl(string Lvl)
    {
        return 1;
    }

    public int AnalyseStuffs(List<ItemModel> Stuffs)
    {
        return 1;
    }
}
