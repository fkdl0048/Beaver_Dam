using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//����� �ֹ��ϴ� ����
public struct stQuest
{
    public List<stMaterial> questMaterials; //����� ��û(�ֹ�)���� ����Ʈ(�ε��� 0���� 1��, 1���� 2��...��)
    public string questText;    //����� ��û�Ҷ� ���� ��Ʈ

    public stQuest(int numMaterials)    //�׳� �����ϼ���
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

//���(��� Ÿ�� & ���� ��Ʋ�)
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