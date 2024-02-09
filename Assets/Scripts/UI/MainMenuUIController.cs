using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUIController : MonoBehaviour
{
    UIDocument dom;
    Button startGameButton;
    Button settingButton;

    // Start is called before the first frame update
    void Start()
    {
        dom = GetComponent<UIDocument>();
        Assert.IsNotNull(dom);

        startGameButton = dom.rootVisualElement.Q<Button>("start-game-button");
        Assert.IsNotNull(startGameButton);
        startGameButton.RegisterCallback<ClickEvent>(OnStartGameButtonClick);

        settingButton = dom.rootVisualElement.Q<Button>("settings-button");
        Assert.IsNotNull(settingButton);
        settingButton.RegisterCallback<ClickEvent>(OnSettingButtonClick);
    }

    public void OnStartGameButtonClick(ClickEvent e)
    {
        SceneManager.LoadScene(Constants.FirstLevel);
    }

    public void OnSettingButtonClick(ClickEvent e)
    {
        SceneManager.LoadScene(Constants.SettingsMenu);
    }
}
