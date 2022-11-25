using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator
{
    private static List<List<int>> typeColorTable;  //��� - ����
    private static List<List<string>> floorStrings; //�� - ��û �ؽ�Ʈ
    private static List<List<string>> typeStrings;  //��� ���� - ��û �ؽ�Ʈ
    private static List<List<string>> colorStrings; //���� - ��û �ؽ�Ʈ

    public QuestGenerator()
    {
        //��� - ���� ��Ī
        typeColorTable = new List<List<int>>();
        typeColorTable.Add(new List<int>() { 0, 3, 4 });
        typeColorTable.Add(new List<int>() { 3, 4, 5 });
        typeColorTable.Add(new List<int>() { 0, 1, 2 });

        //�� - ��û �ؽ�Ʈ ��Ī
        floorStrings = new List<List<string>>();
        floorStrings.Add(new List<string>() { "1����", "ù ��°��", "�ٴڿ�", "�ϴð� ���� �� ����", "8�� 0���� ĭ��", "���� �� ����", "�� ó����" });
        floorStrings.Add(new List<string>() { "2����", "�� ��°��", "ù° ��� ����", "1+3+5-7��°��", "�ٴڰ� ���� �������� ���� ����", "ù ��°�� ���� ������", "�ٴ��� �ƴ� ����" });
        floorStrings.Add(new List<string>() { "3����", "�� ��°��", "�� ��������", "�� ����", "9����ĭ��", "�ϴð� ���� ����� ����", "�ٴڰ� ���� �� ����" });

        //���� - ��û �ؽ�Ʈ ��Ī
        colorStrings = new List<List<string>>();
        colorStrings.Add(new List<string>() { "�ʷϻ�", "green", "���̴� ��", "���� ���� ��", "������ ��", "���� Ŭ�ι��� ��������", "���� ��Ⱑ ����" });
        colorStrings.Add(new List<string>() { "������", "red", "���� ���� �� �� ����", "���� ����", "ü�� ��Ⱑ �� �� ����", "������ ���ð� �;�����", "�ǰ� ��������", "������ ����" });
        colorStrings.Add(new List<string>() { "�����", "yellow", "���Ƹ� ����", "�ӽ�Ÿ�� ����", "3���� �� ���� ��ǥ�ϴ� ����", "��ġ������ ��������", "�̹����� �����ϴ�", "��ġ�� ġ���ϸ� �� �� �ִ� ����", "����" });
        colorStrings.Add(new List<string>() { "ȸ��", "gray", "�Ա��� ����", "������ ����� ����", "�ݹ��̶� �� �� �� ����", "���� ������ ���� ��ä��" });
        colorStrings.Add(new List<string>() { "����", "brown", "�ó����� ����", "Ŀ�� ���� �� ����", "�������� �����", "�볪���� �������� " });
        colorStrings.Add(new List<string>() { "���", "white", "��� ���� ��ģ", "�ϱذ��� ����", "�ܿ￡ ���� ���̴� ���� �ִ� ����", "���� ��� �ĵ�Ƽ�� ����" });

        //��� Ÿ�� - ��û �ؽ�Ʈ ��Ī
        typeStrings = new List<List<string>>();
        typeStrings.Add(new List<string>() { "���������� ����.", "���������� �׾���.", "ȶ������ �� �� �ִ� ��Ḧ ����.", "���ĸ��� �޷� �ִ� ���� ���� �;�.", "���� �޷����� ���� �ִ� ���� �׾���." });
        typeStrings.Add(new List<string>() { "���� ����.", "���� �е��� ū ���� ����.", "�ҿ� Ÿ�� �ʴ� ���� �װ� �;�.", "������ �״� ��Ḧ �÷���.", "ȭ�� ������ �� ����� ���� ����." });
        typeStrings.Add(new List<string>() { "���ĸ��� ����.", "���� ���� ���� ����.", "��� ������ ���� ���ϴ� ���� �׾���.", "���� �������� ���� ���� �;�." });
    }

    //����� �ֹ��ϴ� ����(�Լ� GenerateQuest()�� ��ȯ Ÿ����)
    public struct stQuest
    {
        public List<stMaterial> questMaterials; //��û���� ����Ʈ
        public string questText;    //��û�Ҷ� ���̴� �ؽ�Ʈ

        public stQuest(int numMaterials)
        {
            questMaterials = new List<stMaterial>();
            questText = "";
            for (int i = 0; i < numMaterials; i++)
            {
                stMaterial curMat = new stMaterial(0, 0);
                questMaterials.Add(curMat);
                questText += floorStrings[i][Random.Range(0, floorStrings[i].Count)] + " ";
                questText += colorStrings[curMat.matColor][Random.Range(0, colorStrings[curMat.matColor].Count)] + " ";
                questText += typeStrings[curMat.matType][Random.Range(0, typeStrings[curMat.matType].Count)] + "\n";
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
            matType = Random.Range(0, typeColorTable.Count);
            matColor = typeColorTable[matType][Random.Range(0, typeColorTable[matType].Count)];
        }
    }

    //����� �ֹ��� ������. numMaterials�� �ֹ��� �� ��� ����.
    public stQuest GenerateQuest(int numMaterials)
    {
        if (numMaterials > floorStrings.Count) Debug.LogError("Wrong numMaterials");
        return new stQuest(numMaterials);
    }
}