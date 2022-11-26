using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//비버가 주문하는 내용
public struct stQuest
{
    public List<stMaterial> questMaterials; //비버가 요청(주문)중인 리스트(인덱스 0번이 1층, 1번이 2층...임)
    public string questText;    //비버가 요청할때 쓰는 멘트

    public stQuest(int numMaterials)    //그냥 생성하세요
    {
        if (numMaterials > StringList.floorStrings.Count) Debug.LogError("wrong numMaterials");
        questMaterials = new List<stMaterial>();
        questText = "";
        for (int i = 0; i < numMaterials; i++)
        {
            stMaterial curMat = new stMaterial(0, 0);
            questMaterials.Add(curMat);
            questText += StringList.floorStrings[i][Random.Range(0, StringList.floorStrings[i].Count)] + " ";
            questText += StringList.colorStrings[curMat.matColor][Random.Range(0, StringList.colorStrings[curMat.matColor].Count)] + " ";
            questText += StringList.typeStrings[curMat.matType][Random.Range(0, StringList.typeStrings[curMat.matType].Count)] + "\n";
        }
    }
}

//재료(재료 타입 & 색깔 통틀어서)
public struct stMaterial
{
    public int matType;
    public int matColor;

    public stMaterial(int _type, int _color)
    {
        matType = Random.Range(0, StringList.typeColorTable.Count);
        matColor = StringList.typeColorTable[matType][Random.Range(0, StringList.typeColorTable[matType].Count)];
    }
}