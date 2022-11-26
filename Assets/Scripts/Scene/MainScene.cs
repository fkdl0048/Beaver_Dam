using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MainScene : BaseScene
{
    StringList stringList = new StringList();

    List<stQuest> questList = new List<stQuest>(); //������� ��û�� �����

    int currentStage;       //���� ���° ���������ΰ�
    public int failCnt;     //��� �������� ��Ʋ� ���� Ƚ�� ī��Ʈ

    public int currentQuestIdx;    //���� ������������ �۾����� ����Ʈ �ε���
    bool isUserPlaying;     //���� ���������� ����Ǿ����� üũ��
    float stageTimer;       //���� ���������� Ÿ�̸�(0�Ǹ� ���� ���������� �Ѿ)

    int userWorkingFloor;   //���� ����Ʈ���� �۾����� ��(0����)
    bool isQuestSuccess;    //���� ����Ʈ�� �������� üũ��

    public List<DamMaterial> chosenMaterials;  //������ ���� ����
    public Animation beaverAnim;   //���
    public SpriteRenderer beaverSprite; //���
    public AnimationClip beaverUpClip, beaverDownClip;  //��� �ִϸ��̼�

    [SerializeField] private SpriteAtlas beaverSpriteAtlas;

    //���� ����!
    public void StartGame()
    {
        failCnt = 0;
        currentStage = 0;
        StartStage();
    }

    public string GetAskText()
    {
        return questList[currentQuestIdx].questText;
    }

    public string GetResponseText()
    {
        if (isQuestSuccess) return StringList.successStrings[Random.Range(0, StringList.successStrings.Count)];
        else return StringList.failStrings[Random.Range(0, StringList.failStrings.Count)];
    }

    void Start()
    {
        StartGame();
    }

    //�������� ����  - **UI**
    //����Ʈ���� ����� ù��° ��� ����
    void StartStage()
    {
        currentStage++;

        currentQuestIdx = -1;
        isUserPlaying = true;
        stageTimer = 210.0f - currentStage * 30.0f;
        for (int i = 0; i < 5; i++)
        {
            questList.Add(new stQuest(3));
            Debug.Log(questList[i].questText);
        }
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

        Camera.main.transform.position = new Vector3(0, 0, -10);
        beaverSprite.sprite = beaverSpriteAtlas.GetSprite("beaver_" + Random.Range(0, 10).ToString());
        beaverAnim.clip = beaverUpClip;
        beaverAnim.Play();
        /*
        3. UI���� �ؽ�Ʈ ��
        */
        Debug.Log(GetAskText());
    }

    //���� ��ҷ� �̵�(�ΰ��� 2) - **UI**
    void MoveToIngame2()
    {
        isQuestSuccess = true;
        Camera.main.transform.position = new Vector3(50, 0, -10);
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

        beaverAnim.clip = beaverDownClip;
        beaverAnim.Play();
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