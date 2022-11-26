using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringList
{
    public static List<List<int>> typeColorTable;  //��� - ����
    public static List<List<string>> floorStrings; //�� - ��û �ؽ�Ʈ
    public static List<List<string>> typeStrings;  //��� ���� - ��û �ؽ�Ʈ
    public static List<List<string>> colorStrings; //���� - ��û �ؽ�Ʈ

    public StringList()
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
}
