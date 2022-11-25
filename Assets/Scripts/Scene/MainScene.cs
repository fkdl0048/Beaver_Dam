using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{
    public enum eSTAGE
    {
        Spring,

    }

    private static int MISSION_COUNT = 10;
    private int m_nMissionCount = 0;
    private List<stMission> m_listMission = new List<stMission>();

    public void GameStart()
    {
        this.m_nMissionCount = MISSION_COUNT;
        this.createMission(MISSION_COUNT);
    }

    private void createMission(int nCount)
    {
        this.m_listMission.Clear();
        for(int i = 0; i < nCount; ++i)
        {
            this.m_listMission.Add(new stMission(0, 0));
        }
    }

    public void GenBeaver()
    {
        //
    }

    private enum eMETARIAL
    {
        Branch,
        Stone,
        Leaf,
        End
    }

    private enum eCOLOR
    {
        Green,
        Red,
        Yellow,
        End
    }

    private struct stMission
    {
        public int nMetarial;
        public int nColor;

        public stMission(int nMetarial, int nColor)
        {
            this.nMetarial = Random.Range(0, (int)eMETARIAL.End);
            this.nColor = Random.Range(0, (int)eCOLOR.End);
        }
    }


}