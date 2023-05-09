using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// A Script to handle the Level Selection Menu, most notably the scroll mechanic and it's elements
/// </summary>

[ExecuteInEditMode]
public class LevelSelectionMenu : MonoBehaviour
{
    [SerializeField]
    private LevelOption[] options;
    [SerializeField]
    private GameObject SelectLevelElement;

    [SerializeField]
    private GameObject contentPanel;

    [SerializeField]
    private TMP_Text moneyTimeLabel;

    private void Start()
    {
        GenerateList();
        moneyTimeLabel.text = Globals.floatToTimestamp(Globals.gdata.moneyTime);
    }

    void GenerateList()
    {
        if (options.Length == 0) return;

        for (int i = 0; i < options.Length; i++)
        {
            GameObject newElement = Instantiate(SelectLevelElement);
            newElement.transform.SetParent(contentPanel.transform);
            newElement.transform.SetAsLastSibling();

            newElement.GetComponent<SelectLevelElement>().Prime(options[i]);
        }
    }
}
