using UnityEditor;
using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;

public class ParticleSelectionMenu : MonoBehaviour
{
    [SerializeField]
    private ParticleOption[] options;
    [SerializeField]
    private GameObject SelectParticleElement;

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
        if (options.Length == 0)
            return;

        for (int i = 0; i < options.Length; i++)
        {
            GameObject newElement = Instantiate(SelectParticleElement);
            newElement.transform.SetParent(contentPanel.transform);
            newElement.transform.SetAsLastSibling();

            EditorUtility.ClearDirty(newElement);

            newElement.GetComponent<SelectParticleElement>().Prime(options[i]);
        }
    }

    public void OnChangeMoneyTimeDisplayed()
    {
        moneyTimeLabel.text = moneyTimeDisplayed.Value.ToString();
    }
}
