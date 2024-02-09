using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SettingsUIController : MonoBehaviour
{

    UIDocument dom;
    Button saveButton;
    Slider masterVolume;

    void Start()
    {
        dom = GetComponent<UIDocument>();
        Assert.IsNotNull(dom);

        saveButton = dom.rootVisualElement.Q<Button>("save-button");
        Assert.IsNotNull(saveButton);
        saveButton.RegisterCallback<ClickEvent>(OnSaveButtonClick);

        masterVolume = dom.rootVisualElement.Q<Slider>("master-volume");
        Assert.IsNotNull(masterVolume);
        masterVolume.value = AudioListener.volume;
        masterVolume.RegisterCallback<ChangeEvent<float>>(OnMasterVolumeChanged);
    }

    public void OnMasterVolumeChanged(ChangeEvent<float> e)
    {
        GameMaster.Instance.ChangeVolume(e.newValue);
    }

    public void OnSaveButtonClick(ClickEvent e)
    {
        SceneManager.LoadScene(Constants.MainMenu);
    }
}
