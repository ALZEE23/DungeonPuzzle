using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DialogSystem : MonoBehaviour
{
    public static event Action<Story> OnStoryCreated;
    public DoorManager doorManager;
    public TextAsset inkJson = null;
    public Story story;
    public GameObject canvas;
    public GameObject box;

    public int count;
    public static int nilai;
    public static int nilai1;
    public static int nilai2;

    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject choiceBox;
    [SerializeField] private TMP_Text textPrefab;
    [SerializeField] private Button buttonPrefab;

    void Awake()
    {
        RemoveChildren();
        StartStory();
    }

    public void StartStory()
    {
        if (inkJson != null)
        {
            story = new Story(inkJson.text);
            OnStoryCreated?.Invoke(story);
            RefreshView();
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
        RefreshView();
    }

    void RefreshView()
    {
        RemoveChildren();


        while (story.canContinue)
        {
            string text = story.Continue();
            text = text.Trim();
            CreateContentView(text);
        }


        if (story.currentChoices.Count > 0)
        {
            count = story.currentChoices.Count;
            Debug.Log("Choices available: " + count);
            foreach (Choice choice in story.currentChoices)
            {
                Button newButton = CreateButtonView(choice.text);
                newButton.onClick.AddListener(delegate
                {
                    OnClickChoice(choice);
                });
            }
        }
        else if (story.canContinue)
        {

            RefreshView();

        }
        else
        {
            Button closeButton = CreateButtonView("Close");
            closeButton.onClick.AddListener(delegate
            {
                canvas.SetActive(false);
                // box.SetActive(false);
                this.gameObject.SetActive(false);
                story = new Story(inkJson.text);
                OnStoryCreated?.Invoke(story);
            });
        }

        if (story.variablesState.Contains("nilai"))
        {
            nilai = story.variablesState.Contains("nilai") ? Convert.ToInt32(story.variablesState["nilai"]) : 0;
            Debug.Log("nilai: " + nilai);
        }

        if (story.variablesState.Contains("nilai1"))
        {
            nilai1 = story.variablesState.Contains("nilai1") ? Convert.ToInt32(story.variablesState["nilai1"]) : 0;
            Debug.Log("nilai1: " + nilai1);
        }

        if (story.variablesState.Contains("nilai2"))
        {
            nilai2 = story.variablesState.Contains("nilai2") ? Convert.ToInt32(story.variablesState["nilai2"]) : 0;
            Debug.Log("nilai2: " + nilai2);
        }

    }

    void CreateContentView(string text)
    {
        TMP_Text newText = Instantiate(textPrefab) as TMP_Text;
        newText.text = text;
        newText.transform.SetParent(textBox.transform, false);
    }

    Button CreateButtonView(string text)
    {
        Button newButton = Instantiate(buttonPrefab) as Button;
        newButton.GetComponentInChildren<TMP_Text>().text = text;
        newButton.transform.SetParent(choiceBox.transform, false);
        return newButton;
    }


}
