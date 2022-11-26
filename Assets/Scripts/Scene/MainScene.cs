using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{
    StringList stringList = new StringList();

    List<stQuest> questList = new List<stQuest>(); //������� ��û�� �����
    int currentQuestIdx;    //���� ������������ �۾����� ����Ʈ �ε���
    int userWorkingFloor;   //���� ����Ʈ���� �۾����� ��(0����)
    bool isQuestSuccess;
    int failCnt;

    public List<DamMaterial> chosenMaterials;  //������ ���� ����

    void StartGame()
    {
        failCnt = 0;
        StartStage();
    }

    //�������� ����
    //����Ʈ���� ����� ù��° ��� ����
    void StartStage()
    {
        currentQuestIdx = -1;
        for (int i = 0; i < 5; i++) questList.Add(new stQuest());
        FadeInOut();
        BeaverEnter();
    }

    //�մ� ��� ����(�ΰ��� 1)
    void BeaverEnter()
    {
        currentQuestIdx++;
        ResetMaterials();
        /*
        1. ī�޶� ��ġ�� �ΰ��� 1�� ������Ʈ �ִ� ������ �ٲ�.
        2. ��� ���� �����ϴ� �ִϸ��̼�
        3. UI���� �ؽ�Ʈ ��
        */

    }

    //���� ��ҷ� �̵�(�ΰ��� 2)
    void MoveToIngame2()
    {
        isQuestSuccess = true;
        /*
        1. ī�޶� ��ġ�� �ΰ��� 2�� ������Ʈ �ִ� ������ �ٲ�. 
        */
    }

    //������ ��� �ϼ����� ��(��� �߰��� ��) �Ҹ�
    void AddUserChosenMaterial(stMaterial material)
    {
        isQuestSuccess &= questList[currentQuestIdx].CheckRightMaterial(material, userWorkingFloor);
        chosenMaterials[userWorkingFloor].InitMaterial(material, userWorkingFloor);
        userWorkingFloor++;
    }

    //��� ��� �ʱ�ȭ(������ ���� ������ ��, ���� �ֹ� �������� �ڵ����� �Ѿ �� ����)
    void ResetMaterials()
    {
        for (int i = 0; i < chosenMaterials.Count; i++) chosenMaterials[i].RemoveFromScene();
        userWorkingFloor = 0;
    }

    //�ϼ�ǰ ����.
    void SubmitDam()
    {
        if (!isQuestSuccess) failCnt++;
        BeaverLeave();
    }

    //�մ� ��� ����(�ٽ� �ΰ��� 1�� ���ƿ� ��)
    void BeaverLeave()
    {
        if (isQuestSuccess)
        {

        }
        else
        {

        }
        /*
        1. ī�޶� ��ġ�� �ΰ��� 1�� ������Ʈ �ִ� ������ �ٲ�.
        2. ��� ���� ������ �ִϸ��̼�
        */
        currentQuestIdx++;

        if (currentQuestIdx == 5) EndStage();
    }

    //�������� ����
    void EndStage()
    {
        //���� �������� �Ѿ�� UI ����
    }

    void FadeInOut()
    {

    }
}