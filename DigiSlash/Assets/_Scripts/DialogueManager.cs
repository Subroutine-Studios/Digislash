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

    public bool done = false;


    [SerializeField]
    private AudioSource soundEffect;

    void Start()
    {
        _textDisplay = "";
        _currentSentence = " ";
        _numSentences = _dialogue.dialogueScenes[_sceneIndex].sentences.Length;

        _continueText.SetActive(false);
        done = false;

        //IMPORTANT
        //IMPORTANT
        //IMPORTANT: Remove this when game manager manages the dialogue scenes
        //NextSentence();
    }

    void Update()
    {
        //Show that you can press "ENTER" if display finished the sentence
        if (_textDisplay == _currentSentence)
        {
            _continueText.SetActive(true);
        }

        //If user presses ENTER when it shows "ENTER", go to the next sentence
        if (Input.GetKeyDown(KeyCode.Return) && _continueText.activeSelf)
        {
            NextSentence();
        }

        //The text object will display the sentence that is forming
        _textObj.text = _textDisplay;


    }

    public IEnumerator Type()
    {
        //Slowly form the sentence, store the in-progress sentence in _textDisplay
        soundEffect.Play();
        foreach (char letter in _currentSentence.ToCharArray())
        {
            _textDisplay += letter;
            yield return new WaitForSeconds(_typingSpeed);
        }
        soundEffect.Stop();
    }

    //IMPORTANT
    //IMPORTANT
    //IMPORTANT: Game manager should call this function when the next scene should play
    public void NextSentence()
    {
        //Show the dialogue box
        _dialogueBox.SetActive(true);

        //Show the spotlight if there is one
        if (_dialogue.dialogueScenes[_sceneIndex].highlight)
        {
            _dialogue.dialogueScenes[_sceneIndex].highlight.SetActive(true);
        }

        //The "ENTER" text at the bottom right should not be visible yet
        _continueText.SetActive(false);


        done = false;
        //Current display is empty while it readies up to form the sentence
        _textDisplay = "";

        //If there are still more sentences in the dialogue scene, go to the next sentence
        if (_sentenceIndex < _numSentences - 1)
        {
            _sentenceIndex++;
            _currentSentence = _dialogue.dialogueScenes[_sceneIndex].sentences[_sentenceIndex];
            StartCoroutine(Type());
        }

        //Else, prepare the next dialogue scene
        else
        {
            _dialogueBox.SetActive(false);
            if (_dialogue.dialogueScenes[_sceneIndex].highlight)
            {
                _dialogue.dialogueScenes[_sceneIndex].highlight.SetActive(false);
            }

            _sentenceIndex = -1;
            _sceneIndex++;

            if(_sceneIndex < _dialogue.dialogueScenes.Length)
                _numSentences = _dialogue.dialogueScenes[_sceneIndex].sentences.Length;

            done = true;



            //IMPORTANT
            //IMPORTANT
            //IMPORTANT: comment this out if you can because the game manager should call NextSentence()
            //StartCoroutine(WaitOneSecond());


        }

    }


    //Only use this for testing
    /*
    private IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1f);
        NextSentence();
    }
    */
    


}
