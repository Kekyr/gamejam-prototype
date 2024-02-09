using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseUIController : MonoBehaviour
{
    UIDocument dom;
    Button continueButton;
    Button toMainMenuButton;
    Button winButton;

    // Start is called before the first frame update
    void Start()
    {
        dom = GetComponent<UIDocument>();
        Assert.IsNotNull(dom);

        continueButton = dom.rootVisualElement.Q<Button>("continue-button");
        Assert.IsNotNull(continueButton);
        continueButton.RegisterCallback<ClickEvent>(OnContinueButtonClick);

        toMainMenuButton = dom.rootVisualElement.Q<Button>("to-main-menu-button");
        Assert.IsNotNull(toMainMenuButton);
        toMainMenuButton.RegisterCallback<ClickEvent>(OnToMainMenuButtonClick);

        winButton = dom.rootVisualElement.Q<Button>("win-button");
        Assert.IsNotNull(winButton);
        winButton.RegisterCallback<ClickEvent>(OnWinButtonClick);

        Hide();
    }

    public void Show()
    {
        dom.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    public void Hide()
    {
        dom.rootVisualElement.style.display = DisplayStyle.None;
    }

    public void OnContinueButtonClick(ClickEvent e)
    {
        GameMaster.Instance.Pause();
        Hide();
    }

    public void OnToMainMenuButtonClick(ClickEvent e)
    {
        SceneManager.LoadScene(Constants.MainMenu);
        GameMaster.Instance.Pause();
    }

    public void OnWinButtonClick(ClickEvent e)
    {
        SceneManager.LoadScene(Constants.WinScreen);
        GameMaster.Instance.Pause();
    }
}
