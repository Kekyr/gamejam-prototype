using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WinUIController : MonoBehaviour
{
    UIDocument dom;
    Button toMainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        dom = GetComponent<UIDocument>();
        Assert.IsNotNull(dom);

        toMainMenuButton = dom.rootVisualElement.Q<Button>("to-main-menu-button");
        Assert.IsNotNull(toMainMenuButton);
        toMainMenuButton.RegisterCallback<ClickEvent>(OnToMainMenuButtonClick);
    }

    public void OnToMainMenuButtonClick(ClickEvent e)
    {
        SceneManager.LoadScene(Constants.MainMenu);
    }

}
