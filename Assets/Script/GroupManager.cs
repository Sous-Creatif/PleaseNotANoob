using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    private PlayersList PL;
    public GroupVar Gv;

    private Color originalColor;
    private bool isGreen = false;

    public void CreateAGroup()
    {
        Gv = GameObject.FindGameObjectWithTag("Event").GetComponent<GroupVar>();
        Gv.ResetEvery();
        Gv.ResetGroup();
        PL = GameObject.FindGameObjectWithTag("Event").GetComponent<PlayersList>();
        PL.Display_Scroll_Players();
    }

    private void OnMouseDown()
    {
        Gv = GameObject.FindGameObjectWithTag("Event").GetComponent<GroupVar>();

        if (isGreen)
        {
            ChangeColor(Color.white);
            isGreen = false;
            Gv.LessGroup();
            PlayerModel Pm = TransformModel(gameObject.GetComponent<Player>());
            Gv.TmpGroup.Remove(Pm);
        }
        else if(Gv.GetGroupIn() < 3)
        {
            ChangeColor(Color.green);
            isGreen = true;
            Gv.PlusGroup();
            PlayerModel Pm = TransformModel(gameObject.GetComponent<Player>());
            Gv.TmpGroup.Add(Pm);
            Debug.Log("ADD");
        }

        //Create group
        if (Gv.GetGroupIn() == 3)
        {
            Gv.NewGroup(Gv.TmpGroup);
            GameObject DetailGroup = Instantiate(Gv.PrefabGroup, new Vector3(-1,0,0), Quaternion.identity);
            GroupDetail GD = DetailGroup.AddComponent<GroupDetail>();
            GD.ConfigGroup(Gv.TmpGroup);
        }
    }

    //Utilisé quand un donjon commence + ajouter un petit temps d'attente
    public bool GroupWinDonjon(List<PlayerModel> ActualGroup, int DonjonScore)
    {
        int GroupScore = GetScoreGroup(ActualGroup);
        Debug.Log("Group Score");
        Debug.Log(GroupScore);
        int MobsScore = DonjonScore;

        if (GroupScore > MobsScore)
        {
            PopResult PoR = GameObject.FindGameObjectWithTag("Event").GetComponent<PopResult>();
            PoR.ShowResult(true);
            return true;
        }
        else
        {
            PopResult PoR = GameObject.FindGameObjectWithTag("Event").GetComponent<PopResult>();
            PoR.ShowResult(false);
            return false;
        }
    }

    public int GetScoreGroup(List<PlayerModel> ActualGroup)
    {
        int indiceRank = 0;
        int indiceSpe = 0;
        int indiceLvl = 0;
        int indiceStuff = 0;

        foreach(PlayerModel teammate in ActualGroup )
        {
            PlayerRankTab PRT = GameObject.FindGameObjectWithTag("Event").GetComponent<PlayerRankTab>();
            IndiceAnalyse IA = GameObject.FindGameObjectWithTag("Event").GetComponent<IndiceAnalyse>();
            var teammateInfo = PRT.GetPlayerInfo(teammate.Race,teammate.Classe);

            indiceRank += IA.AnalyseRank(teammateInfo.Rank);
            indiceSpe += IA.AnalyseSpe(teammateInfo.Spe);
            indiceLvl += IA.AnalyseLvl(teammate.Lvl);
            indiceStuff += IA.AnalyseStuffs(teammate.Stuffs);
        }

        return indiceLvl + indiceSpe + indiceRank + indiceStuff;
    }

    //Show group
    public void DisplayGroupPlayers()
    {
        Gv = GameObject.FindGameObjectWithTag("Event").GetComponent<GroupVar>();
        PL = GameObject.FindGameObjectWithTag("Event").GetComponent<PlayersList>();
        List<PlayerModel> group = Gv.GetThisGroup(0);
        int i = 2;
        foreach (PlayerModel player in group)
        {
            PL.Show_Player_Detail(-13, i, 0, player);
            i -= 4;
        }
    }


    public PlayerModel TransformModel(Player infoPlayer)
    {
        PlayerModel playerModel = ScriptableObject.CreateInstance<PlayerModel>();

        playerModel.Id = infoPlayer.Id;
        playerModel.Icon = infoPlayer.Icon;
        playerModel.Race = infoPlayer.Race;
        playerModel.Classe = infoPlayer.Classe;
        playerModel.Stuffs = infoPlayer.Stuffs;
        playerModel.Name = infoPlayer.Name;
        playerModel.Lvl = infoPlayer.Lvl;

        return playerModel;
    }

    private void ChangeColor(Color newColor)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.color = newColor;
        }
    }

}
