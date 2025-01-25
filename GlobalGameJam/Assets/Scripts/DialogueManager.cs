using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject textBox;
    [SerializeField] GameObject nameText;
    [SerializeField] GameObject bodyText;

    public bool textboxIsActive;

    // Start is called before the first frame update
    void Start()
    {
        DeactivateTextBox();
    }

    // Update is called once per frame
    void Update()
    {
        if (textboxIsActive && Input.GetMouseButtonDown(0))
        {
            DeactivateTextBox();
        }
    }

    public void ActivateTextBox(string objName, string objText)
    {
        textBox.SetActive(true);
        bodyText.SetActive(true);
        bodyText.GetComponent<TextMeshProUGUI>().text = objText;
        nameText.SetActive(true);
        nameText.GetComponent<TextMeshProUGUI>().text = objName;
        textboxIsActive = true;
    }
    public void DeactivateTextBox()
    {
        textBox.SetActive(false);
        bodyText.SetActive(false);
        nameText.SetActive(false);
    }
}
