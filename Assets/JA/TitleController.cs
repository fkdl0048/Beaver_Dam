using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TitleController : MonoBehaviour
{
    private UIDocument _uiDocument;

    private Button _startButton;
    private Button _optionButton;
    private Button _creditButton;
    private Button _exitButton;
    private Button _containerOptionExitButton;
    private Button _containerCreditExitButton;

    private VisualElement _optionContainer;
    private VisualElement _creditContainer;
    
    void Start()
    {
        // UI Document load;
        _uiDocument = GetComponent<UIDocument>();

        var root = _uiDocument.rootVisualElement;
        
        // Button Init
        _startButton = root.Q<Button>("StartButton");
        _optionButton = root.Q<Button>("OptionButton");
        _creditButton = root.Q<Button>("CreditButton");
        _exitButton = root.Q<Button>("ExitButton");
        _containerOptionExitButton = root.Q<Button>("Container_Option_ExitButton");
        _containerCreditExitButton = root.Q<Button>("Container_Credit_ExitButton");
        
        // Button Event
        _startButton.clicked += PlayButtonClick;
        //_optionButton.clicked += OptionButtonClick; // RegisterCallback Modify
        _creditButton.clicked += CreditButtonClick;
        _exitButton.clicked += ExitButtonClick;
        _optionButton.RegisterCallback<ClickEvent>(OptionButtonClick);
        _containerOptionExitButton.RegisterCallback<ClickEvent>(ContainerOptionExitButtonClick);
        _containerCreditExitButton.RegisterCallback<ClickEvent>(ContainerCreditExitButtonClick);
        
        // Container Init
        _optionContainer = root.Q<VisualElement>("Container_Option");
        _creditContainer = root.Q<VisualElement>("Container_Credit");
    }

    private void PlayButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void OptionButtonClick(ClickEvent evt)
    {
        _optionContainer.style.display = DisplayStyle.Flex;
    }

    private void ContainerOptionExitButtonClick(ClickEvent evt)
    {
        _optionContainer.style.display = DisplayStyle.None;
    }

    private void ContainerCreditExitButtonClick(ClickEvent evt)
    {
        _creditContainer.style.display = DisplayStyle.None;
    }

    private void CreditButtonClick()
    {
        _creditContainer.style.display = DisplayStyle.Flex;
    }

    private void ExitButtonClick()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
