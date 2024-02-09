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
        collector.text = "Собрано: ничегошеньки :(";
    }

    public void changeCollectorLabel(int count)
    {
        collector.text = "Собрано: " + count.ToString();
    }
}
