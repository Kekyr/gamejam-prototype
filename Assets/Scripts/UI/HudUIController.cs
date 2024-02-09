using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

public class HudUIController : MonoBehaviour
{
    UIDocument dom;
    Label collector;

    void Start()
    {
        dom = GetComponent<UIDocument>();
        Assert.IsNotNull(dom);

        collector = dom.rootVisualElement.Q<Label>("collector-label");
        Assert.IsNotNull(collector);
        collector.text = "�������: ������������ :(";
    }

    public void changeCollectorLabel(int count)
    {
        collector.text = "�������: " + count.ToString();
    }
}
