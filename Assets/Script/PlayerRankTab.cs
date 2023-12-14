using UnityEngine;
using System.Collections.Generic;

public class PlayerRankTab : MonoBehaviour
{
    private Dictionary<string, Dictionary<string, (string Rank, string Spe)>> rankTable = new Dictionary<string, Dictionary<string, (string Rank, string Spe)>>();

    void Start()
    {
        PlayersList PL = GetComponent<PlayersList>();

        foreach (string Race in PL.Races)
        {
            foreach (string Classe in PL.Classes)
            {
                string Rank = RandomRank();
                string Spe = RandomSpecialization();

                AddRank(Race, Classe, Rank, Spe);
            }
        }
    }

    public string RandomRank()
    {
        int rdm = Random.Range(1, 6);

        switch (rdm)
        {
            case 1:
                return "RankS";
            case 2:
                return "RankA";
            case 3:
                return "RankB";
            case 4:
                return "RankC";
            case 5:
                return "RankF";
        }

        return "RankA";
    }

    public string RandomSpecialization()
    {
        string[] specializations = { "dps", "tank", "healer" };
        return specializations[Random.Range(0, specializations.Length)];
    }

    public void AddRank(string race, string playerClass, string rank, string spe)
    {
        if (!rankTable.ContainsKey(race))
        {
            rankTable[race] = new Dictionary<string, (string Rank, string Spe)>();
        }

        rankTable[race][playerClass] = (rank, spe);
    }

    public (string Rank, string Spe) GetPlayerInfo(string race, string playerClass)
    {
        if (rankTable.ContainsKey(race) && rankTable[race].ContainsKey(playerClass))
        {
            return rankTable[race][playerClass];
        }

        return ("Unknown Rank", "Unknown Spe");
    }

    public void ChangeRank(string race, string playerClass, string newRank, string newSpe)
    {
        if (rankTable.ContainsKey(race) && rankTable[race].ContainsKey(playerClass))
        {
            rankTable[race][playerClass] = (newRank, newSpe);
        }
        else
        {
            Debug.LogError("Race or class not found in the rank table.");
        }
    }
}
