using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContent : MonoBehaviour
{
    [System.Serializable]
    public class DialogueScenes
    {
        [SerializeField]
        private string _sceneName;
        public string[] sentences;
        public GameObject highlight;
    }

    public DialogueScenes[] dialogueScenes;
}
