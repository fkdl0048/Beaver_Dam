using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{
    StringList stringList = new StringList();

    List<stQuest> questList = new List<stQuest>(); //������� ��û�� �����

    int currentStage;       //���� ���° ���������ΰ�
    int failCnt;            //��� �������� ��Ʋ� ���� Ƚ�� ī��Ʈ

    int currentQuestIdx;    //���� ������������ �۾����� ����Ʈ �ε���
    bool isUserPlaying;     //���� ���������� ����Ǿ����� üũ��
    float stageTimer;       //���� ���������� Ÿ�̸�(0�Ǹ� ���� ���������� �Ѿ)

    int userWorkingFloor;   //���� ����Ʈ���� �۾����� ��(0����)
    bool isQuestSuccess;    //���� ����Ʈ�� �������� üũ��

    public List<DamMaterial> chosenMaterials;  //������ ���� ����
    
    //���� ����!
    public void StartGame()
    {
        failCnt = 0;
        currentStage = 0;
        StartStage();
    }

    //�������� ����  - **UI**
    //����Ʈ���� ����� ù��° ��� ����
    void StartStage()
    {
        currentStage++;

        currentQuestIdx = -1;
        isUserPlaying = true;
        stageTimer = 210.0f - currentStage * 30.0f;
        for (int i = 0; i < 5; i++) questList.Add(new stQuest());
        FadeInOut();
        BeaverEnter();
    }

    void Update()
    {
        CheckTimer();
    }

    //�մ� ��� ����(�ΰ��� 1)
    void BeaverEnter()
    {
        currentQuestIdx++;
        ResetMaterials();

        Camera.main.transform.position = Vector2.zero;
        /*
        2. ��� ���� �����ϴ� �ִϸ��̼�
        3. UI���� �ؽ�Ʈ ��
        */
    }

    //���� ��ҷ� �̵�(�ΰ��� 2) - **UI**
    void MoveToIngame2()
    {
        isQuestSuccess = true;
        Camera.main.transform.position = new Vector2(20, 0);
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
        isUserPlaying = false;
        //���� �������� �Ѿ�� UI ����
    }

    void CheckTimer()
    {
        if (isUserPlaying)
        {
            stageTimer -= Time.deltaTime;
            if (stageTimer <= 0.0f)
            {
                failCnt += 5 - currentQuestIdx;
                EndStage();
            }
        }
    }

    void FadeInOut()
    {

    }
}