using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using ScriptableObjectArchitecture;

/// <summary>
/// A Script to handle the Level Selection Menu, most notably the scroll mechanic and it's elements
/// </summary>

// [ExecuteInEditMode]
// TODO remake this to be triggered from editor instead of each time on start, including deletion of old content first
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
    [SerializeField]
    private FloatVariable moneyTimeDisplayed;

    private void Start()
    {
        GenerateList();
        moneyTimeLabel.text = Globals.floatToMoneytime(Globals.gdata.moneyTime);
        moneyTimeDisplayed.Value = Globals.gdata.moneyTime;
    }

    void Awake()
    {
        Debug.Log("Editor causes this Awake");
    }

    void GenerateList()
    {
        if (options.Length == 0) return;

        for (int i = 0; i < options.Length; i++)
        {
            GameObject newElement = Instantiate(SelectLevelElement);
            newElement.transform.SetParent(contentPanel.transform);
            newElement.transform.SetAsLastSibling();


            //EditorUtility.ClearDirty(newElement);

            newElement.GetComponent<SelectLevelElement>().Prime(options[i]);
        }
    }

    public void OnChangeMoneyTimeDisplayed()
    {
        moneyTimeLabel.text = moneyTimeDisplayed.Value.ToString();
    }
}
