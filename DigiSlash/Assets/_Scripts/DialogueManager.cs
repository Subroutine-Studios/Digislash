using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private DialogueContent _dialogue;

    //Current Displays
    [SerializeField]
    private TextMeshProUGUI _textObj;
    private string _textDisplay;
    private string _currentSentence;

    [SerializeField]
    private GameObject _continueText;

    [SerializeField]
    private GameObject _dialogueBox;


    private int _sceneIndex = 0;
    private int _sentenceIndex = -1;
    private int _numSentences;

    [SerializeField]
    private float _typingSpeed;

    private bool done = false;


    [SerializeField]
    private AudioSource soundEffect;

    void Start()
    {
        _textDisplay = "";
        _currentSentence = " ";
        _numSentences = _dialogue.dialogueScenes[_sceneIndex].sentences.Length;

        _continueText.SetActive(false);
        done = false;



        NextSentence();
    }

    void Update()
    {
        if (_textDisplay == _currentSentence)
        {
            _continueText.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Return) && _continueText.activeSelf)
        {
            NextSentence();
        }


        _textObj.text = _textDisplay;


    }

    public IEnumerator Type()
    {
        soundEffect.Play();
        foreach (char letter in _currentSentence.ToCharArray())
        {
            _textDisplay += letter;
            yield return new WaitForSeconds(_typingSpeed);
        }
        soundEffect.Stop();
    }

    public void NextSentence()
    {
        _continueText.SetActive(false);
        done = false;
        _textDisplay = "";

        if (_sentenceIndex < _numSentences - 1)
        {
            _sentenceIndex++;
            _currentSentence = _dialogue.dialogueScenes[_sceneIndex].sentences[_sentenceIndex];
            //soundEffect.time = timef;
            //soundEffect.Play();
            StartCoroutine(Type());
        }

        else
        {
            _sentenceIndex = -1;
            _sceneIndex++;
            done = true;
            _dialogueBox.SetActive(false);


        }

    }


}
