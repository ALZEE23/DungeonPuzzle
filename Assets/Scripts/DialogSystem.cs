using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public static event Action<Story> OnStoryCreated;
    public DoorManager doorManager;
    public TextAsset inkJson = null;
    public Story story;
    public GameObject canvas;
    public GameObject box;

    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject choiceBox;
    [SerializeField] private Text textPrefab = null;
    [SerializeField] private Button buttonPrefab = null;

    void Awake()
    {
        RemoveChildren();
        StartStory();
    }

    void StartStory()
    {
        if (inkJson != null)
        {
            story = new Story(inkJson.text);
            OnStoryCreated?.Invoke(story);
        }
        else
        {
            Debug.LogError("Ink JSON file is not assigned.");
        }
    }

    void RemoveChildren()
    {
        foreach (Transform child in textBox.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in choiceBox.transform)
        {
            Destroy(child.gameObject);
        }
    }

    void OnClickChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);

    }

    void RefreshView()
    {
        RemoveChildren();

        if (story.canContinue)
        {
            string text = story.Continue();
            Text newText = Instantiate(textPrefab, textBox.transform);
            newText.text = text;
        }

        if (story.currentChoices.Count > 0)
        {
            foreach (Choice choice in story.currentChoices)
            {
                Button newButton = Instantiate(buttonPrefab, choiceBox.transform);
                newButton.GetComponentInChildren<Text>().text = choice.text;
                newButton.onClick.AddListener(() => OnClickChoice(choice));
            }
        }
        else
        {
            canvas.SetActive(false);
            box.SetActive(false);
        }
    }

    void CreateContentView(string text){
        Text newText = Instantiate(textPrefab) as Text;
        newText.text = text;
        newText.transform.SetParent(textBox.transform, false);
    }

    Button CreateButtonView(string text){
        Button newButton = Instantiate(buttonPrefab) as Button;
        newButton.GetComponentInChildren<Text>().text = text;
        newButton.transform.SetParent(choiceBox.transform, false);
        return newButton;
    }


}
