using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainController : MonoBehaviour
{
    private UIDocument _uiDocument;
    [SerializeField] AudioMixer _audio;
    private Slider _slider;

    // stage 
    private Button _quesButton;
    private VisualElement _inGameOne;
    private VisualElement _inGameTwo;
    private Label _stageLabel;
    
    // Option
    private Button _optionButton;
    private Button _exitButton;
    private Button _titleButon;
    private VisualElement _optionContainer;

    // Quest Button
    private Button _branchButton;
    private Button _stoneButton;
    private Button _leafButton;
    private VisualElement _branchContainer;
    private VisualElement _stoneContainer;
    private VisualElement _leafContainer;
    private Button _branchGreen;
    private Button _branchGray;
    private Button _branchBrown;
    private Button _stoneGray;
    private Button _stoneBrown;
    private Button _stoneWhite;
    private Button _leafGreen;
    private Button _leafRed;
    private Button _leafYellow;

    // Quest Etc Button
    private Button _resultButton;
    private Button _resetButton;

    private VisualElement _stageContainer;

    private int currentIdx, prevIdx;
    private bool _check;
    private int _curstage;
    private bool _stop;

    void Start()
    {
        // UIDoucment Init
        _uiDocument = GetComponent<UIDocument>();
        prevIdx = -1;
        _curstage = -1;

        var root = _uiDocument.rootVisualElement;

        // Option Init
        _optionContainer = root.Q<VisualElement>("Container-Option");
        _optionButton = root.Q<Button>("OptionButton");
        _exitButton = root.Q<Button>("ExitButton");
        _titleButon = root.Q<Button>("TitleButton");
        
        // Option Event Add
        _optionButton.RegisterCallback<ClickEvent>(OptionButtonClick);
        _exitButton.RegisterCallback<ClickEvent>(ExitButtonClick);
        _titleButon.RegisterCallback<ClickEvent>(TitleButtonClick);
        
        // InGame
        _quesButton = root.Q<Button>("QuestText");
        _inGameOne = root.Q<VisualElement>("InGameOne");
        _inGameTwo = root.Q<VisualElement>("InGameTwo");
        _quesButton.RegisterCallback<ClickEvent>(OnChangeOne);

        // Quest Button Init
        _branchButton = root.Q<Button>("BranchButton");
        _stoneButton = root.Q<Button>("StoneButton");
        _leafButton = root.Q<Button>("LeafButton");
        _branchContainer = root.Q<VisualElement>("BranchList");
        _stoneContainer = root.Q<VisualElement>("StoneList");
        _leafContainer = root.Q<VisualElement>("LeafList");
        
        _branchGreen = root.Q<Button>("BranchGreen");
        _branchGray = root.Q<Button>("BranchGray");
        _branchBrown = root.Q<Button>("BranchBrown");
        _stoneGray = root.Q<Button>("StoneGray");
        _stoneBrown = root.Q<Button>("StoneBrown");
        _stoneWhite = root.Q<Button>("StoneWhite");
        _leafGreen = root.Q<Button>("LeafGreen");
        _leafRed = root.Q<Button>("LeafRed");
        _leafYellow = root.Q<Button>("LeafYellow");

        _resultButton = root.Q<Button>("ResultButton");
        _resultButton.RegisterCallback<ClickEvent>(OnChangeTwo);
        _resetButton = root.Q<Button>("ResetButton");
        _resetButton.RegisterCallback<ClickEvent>(OnResetButton);
        
        // Quest Button Event Add
        _branchButton.RegisterCallback<ClickEvent>(OpenQuestContainerBracnch);
        _stoneButton.RegisterCallback<ClickEvent>(OpenQuestContainerStone);
        _leafButton.RegisterCallback<ClickEvent>(OpenQuestContainerLeaf);
        
        _branchGreen.RegisterCallback<ClickEvent>(OnbranchGreen);
        _branchGray.RegisterCallback<ClickEvent>(OnbranchGray);
        _branchBrown.RegisterCallback<ClickEvent>(OnbranchBrown);
        _stoneGray.RegisterCallback<ClickEvent>(OnStoneGray);
        _stoneBrown.RegisterCallback<ClickEvent>(OnStoneBrown);
        _stoneWhite.RegisterCallback<ClickEvent>(OnStoneWhite);
        _leafGreen.RegisterCallback<ClickEvent>(OnLeafGreen);
        _leafRed.RegisterCallback<ClickEvent>(OnLeafRed);
        _leafYellow.RegisterCallback<ClickEvent>(OnLeafYellow);
        
        _inGameOne.AddToClassList("InGameOut");

        _stageContainer = root.Q<VisualElement>("InGameStage");
        _stageLabel = root.Q<Label>("StageText");

        _slider = root.Q<Slider>("SoundSliber");
    }

    #region Option

    private void OptionButtonClick(ClickEvent evt)
    {
        _optionContainer.style.display = DisplayStyle.Flex;
    }

    private void ExitButtonClick(ClickEvent evt)
    {
        _optionContainer.style.display = DisplayStyle.None;
    }

    #endregion

    #region QuestButton

    private void OpenQuestContainerBracnch(ClickEvent evt)
    {
        QuestContainerReset();
        
        _branchContainer.style.display = DisplayStyle.Flex;
        
    }

    private void OpenQuestContainerStone(ClickEvent evt)
    {
        QuestContainerReset();
        
        _stoneContainer.style.display = DisplayStyle.Flex;
    }
    
    private void OpenQuestContainerLeaf(ClickEvent evt)
    {
        QuestContainerReset();
        
        _leafContainer.style.display = DisplayStyle.Flex;
    }

    private void OnbranchGreen(ClickEvent evt)
    {
        _branchContainer.style.display = DisplayStyle.None;
        
        BeaverGameManager.Instance.GetCurrScene<MainScene>().AddUserChosenMaterial(new stMaterial((int)eMETARIAL.Branch, (int)eCOLOR.Green));
        
        SoundManager.Instance.PlaySound(eSOUND.Branch);
    }
    
    private void OnbranchGray(ClickEvent evt)
    {
        _branchContainer.style.display = DisplayStyle.None;
        
        BeaverGameManager.Instance.GetCurrScene<MainScene>().AddUserChosenMaterial(new stMaterial((int)eMETARIAL.Branch, (int)eCOLOR.Gray));
        
        
        SoundManager.Instance.PlaySound(eSOUND.Branch);
    }
    
    private void OnbranchBrown(ClickEvent evt)
    {
        SoundManager.Instance.PlaySound(eSOUND.Branch);
        
        _branchContainer.style.display = DisplayStyle.None;
        
        BeaverGameManager.Instance.GetCurrScene<MainScene>().AddUserChosenMaterial(new stMaterial((int)eMETARIAL.Branch, (int)eCOLOR.Brown));
    }
    
    private void OnStoneGray(ClickEvent evt)
    {
        
        SoundManager.Instance.PlaySound(eSOUND.Stone);
        _stoneContainer.style.display = DisplayStyle.None;
        
        BeaverGameManager.Instance.GetCurrScene<MainScene>().AddUserChosenMaterial(new stMaterial((int)eMETARIAL.Stone, (int)eCOLOR.Gray));
    }

    private void OnStoneBrown(ClickEvent evt)
    {
        SoundManager.Instance.PlaySound(eSOUND.Stone);
        _stoneContainer.style.display = DisplayStyle.None;
        
        BeaverGameManager.Instance.GetCurrScene<MainScene>().AddUserChosenMaterial(new stMaterial((int)eMETARIAL.Stone, (int)eCOLOR.Brown));
    }
    
    private void OnStoneWhite(ClickEvent evt)
    {
        SoundManager.Instance.PlaySound(eSOUND.Stone);
        _stoneContainer.style.display = DisplayStyle.None;
        
        BeaverGameManager.Instance.GetCurrScene<MainScene>().AddUserChosenMaterial(new stMaterial((int)eMETARIAL.Stone, (int)eCOLOR.White));
    }

    private void OnLeafGreen(ClickEvent evt)
    {
        SoundManager.Instance.PlaySound(eSOUND.Leaf);
        _leafContainer.style.display = DisplayStyle.None;
        
        BeaverGameManager.Instance.GetCurrScene<MainScene>().AddUserChosenMaterial(new stMaterial((int)eMETARIAL.Leaf, (int)eCOLOR.Green));
    }
    
    private void OnLeafRed(ClickEvent evt)
    {
        SoundManager.Instance.PlaySound(eSOUND.Leaf);
        _leafContainer.style.display = DisplayStyle.None;
        
        BeaverGameManager.Instance.GetCurrScene<MainScene>().AddUserChosenMaterial(new stMaterial((int)eMETARIAL.Leaf, (int)eCOLOR.Red));
    }
    
    private void OnLeafYellow(ClickEvent evt)
    {
        SoundManager.Instance.PlaySound(eSOUND.Leaf);
        
        _leafContainer.style.display = DisplayStyle.None;
        
        BeaverGameManager.Instance.GetCurrScene<MainScene>().AddUserChosenMaterial(new stMaterial((int)eMETARIAL.Leaf, (int)eCOLOR.Yellow));
    }

    private void QuestContainerReset()
    {
        _branchContainer.style.display = DisplayStyle.None;
        _stoneContainer.style.display = DisplayStyle.None;
        _leafContainer.style.display = DisplayStyle.None;
    }

    #endregion

    #region InGame

    private void OnChangeOne(ClickEvent evt)
    {
        if(!_stop)
            return;

        if (_check)
        {
            _check = false;
            BeaverGameManager.Instance.GetCurrScene<MainScene>().BeaverEnter();
            SoundManager.Instance.PlaySound(eSOUND.CustomerIn);
            return;
        }

        QuestContainerReset();
        
        _inGameOne.style.display = DisplayStyle.None;
        _inGameTwo.style.display = DisplayStyle.Flex;
        BeaverGameManager.Instance.GetCurrScene<MainScene>().MoveToIngame2();

        _inGameTwo.AddToClassList("InGameOut");
        _inGameOne.RemoveFromClassList("InGameOut");
        
        _quesButton.text = "";
    }

    private void OnChangeTwo(ClickEvent evt)
    {
        _check = true;
        _inGameOne.style.display = DisplayStyle.Flex;
        _inGameTwo.style.display = DisplayStyle.None;
        
        
        
        BeaverGameManager.Instance.GetCurrScene<MainScene>().SubmitDam();
        
        SoundManager.Instance.PlaySound(eSOUND.CustomerOut);

        _quesButton.text = "";
        _quesButton.text = BeaverGameManager.Instance.GetCurrScene<MainScene>().GetResponseText();
        
        // class 
        _inGameOne.AddToClassList("InGameOut");
        _inGameTwo.RemoveFromClassList("InGameOut");
    }

    private void OnResetButton(ClickEvent evt)
    {
        BeaverGameManager.Instance.GetCurrScene<MainScene>().ResetMaterials();
        
        SoundManager.Instance.PlaySound(eSOUND.Reset);
    }

    #endregion


    private void Update()
    {
        currentIdx = BeaverGameManager.Instance.GetCurrScene<MainScene>().currentQuestIdx;
        if ((currentIdx != prevIdx && BeaverGameManager.Instance.GetCurrScene<MainScene>().isUserPlaying) || (currentIdx == prevIdx && BeaverGameManager.Instance.GetCurrScene<MainScene>().currentStage != _curstage ))
        {
            _stop = false;
            
            prevIdx = currentIdx;
            _quesButton.text = "";
            string m = BeaverGameManager.Instance.GetCurrScene<MainScene>().GetAskText();
            DOTween.To(() => _quesButton.text, x => _quesButton.text = x, m, 3f).SetEase(Ease.Linear);
            Invoke("StopTrue", 3f);
        }

        if (BeaverGameManager.Instance.GetCurrScene<MainScene>().userWorkingFloor == 3)
        {
            DisableAllButton();
        }
        else
        {
            AllButtonOn();
        }

        if (BeaverGameManager.Instance.GetCurrScene<MainScene>().isEnd)
        {
            _inGameOne.style.display = DisplayStyle.None;
            _inGameTwo.style.display = DisplayStyle.None;
            _optionContainer.style.display = DisplayStyle.None;
        }

        if (BeaverGameManager.Instance.GetCurrScene<MainScene>().stageTimer <= 0)
        {
            _check = true;
            _inGameOne.style.display = DisplayStyle.Flex;
            _inGameTwo.style.display = DisplayStyle.None;

            _quesButton.text = "";
            _quesButton.text = BeaverGameManager.Instance.GetCurrScene<MainScene>().GetResponseText();

            // class 
            _inGameOne.AddToClassList("InGameOut");
            _inGameTwo.RemoveFromClassList("InGameOut");
            
            BeaverGameManager.Instance.GetCurrScene<MainScene>().stageTimer = 3300;
            

            //StageChange();
        }

        if (BeaverGameManager.Instance.GetCurrScene<MainScene>().currentStage != _curstage)
        {
            _curstage = BeaverGameManager.Instance.GetCurrScene<MainScene>().currentStage;
            if (_curstage == 5)
                return;
            StageChange();
        }

        _audio.SetFloat("Master", _slider.value);
    }

    private void DisableAllButton()
    {
        _branchButton.visible = false;
        _stoneButton.visible = false;
        _leafButton.visible = false;
    }

    private void AllButtonOn()
    {
        _branchButton.visible = true;
        _stoneButton.visible = true;
        _leafButton.visible = true;
    }

    private void StageChange()
    {
        StartCoroutine(StageChangeLogic());
    }

    private void StopTrue()
    {
        _stop = true;
    }

    private void TitleButtonClick(ClickEvent evt)
    {
        SceneManager.LoadScene("Tilte");
    }

    private IEnumerator StageChangeLogic()
    {
        _stageContainer.style.display = DisplayStyle.Flex;
        _stageContainer.AddToClassList("StageFadeOut");
        string temp = "Stage " + BeaverGameManager.Instance.GetCurrScene<MainScene>().currentStage;
        _stageLabel.text = temp;
        yield return new WaitForSeconds(2f);
        _stageContainer.RemoveFromClassList("StageFadeOut");
        _stageContainer.style.display = DisplayStyle.None;
    }
}
