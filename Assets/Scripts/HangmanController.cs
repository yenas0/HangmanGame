using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HangmanController : MonoBehaviour
{
    [SerializeField] GameObject wordContainer;
    [SerializeField] GameObject keyboardContainer;
    [SerializeField] GameObject letterContainer;
    [SerializeField] GameObject[] hangmanStages;
    [SerializeField] GameObject letterButton;
    [SerializeField] TextAsset possibleWord;

    private string word;
    private int incorrectGuesses, correctGuesses;

    // Start is called before the first frame update
    void Start()
    {
        InitialiseButtons();
        InitialiseGame();
    }

    private void InitialiseButtons()
    {
        for (int i = 65; i <= 90; i++)
        {
            CreateButton(i);
        }
    }

    private void InitialiseGame()
    {
        //reset data back to original state
        incorrectGuesses = 0;
        correctGuesses = 0;
        foreach (Button child in keyboardContainer.GetComponentsInChildren<Button>())
        {
            child.interactable = true;
        }
        foreach (Transform child in wordContainer.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }
        foreach (GameObject stage in hangmanStages)
        {
            stage.SetActive(false);
        }

        //generate new word
        word = generateWord().ToUpper();
        foreach (char letter in word)
        {
            var temp = Instantiate(letterContainer, wordContainer.transform);
        }
    }

    private void CreateButton(int i)
    {
        GameObject temp = Instantiate(letterButton, keyboardContainer.transform);
        temp.GetComponentInChildren<TextMeshProUGUI>().text = ((char)i).ToString();
        temp.GetComponent<Button>().onClick.AddListener(delegate { CheckLetter(((char)i).ToString()); });
    }

    private string generateWord()
    {
        string[] wordList = possibleWord.text.Split('\n');
        string line = wordList[Random.Range(0, wordList.Length - 1)];
        return line.Trim();
    }

    private void CheckLetter(string inputLetter)
    {
        bool letterInWord = false;
        for (int i = 0; i < word.Length; i++)
        {
            if (inputLetter == word[i].ToString())
            {
                letterInWord = true;
                correctGuesses++;
                wordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].text = inputLetter;
            }
        }
        if (!letterInWord)
        {
            incorrectGuesses++;
            hangmanStages[incorrectGuesses - 1].SetActive(true);
        }
        CheckOutcome();
    }

    private void CheckOutcome()
    {
        if (correctGuesses == word.Length)
        {
            foreach (TextMeshProUGUI textMeshProUGUI in wordContainer.GetComponentsInChildren<TextMeshProUGUI>())
            {
                textMeshProUGUI.color = Color.green;
            }
            Invoke("InitialiseGame", 3f);
        }

        if (incorrectGuesses == hangmanStages.Length)
        {
            for (int i = 0; i < word.Length; i++)
            {
                wordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].color = Color.red;
                wordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].text = word[i].ToString();
            }
            Invoke("InitialiseGame", 3f);
        }
    }
}

