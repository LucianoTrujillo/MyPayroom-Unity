using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogueSystem : MonoBehaviour {

    public static DialogueSystem Instance { get; set; }
    public List<string> dialogueLines = new List<string>();
    public GameObject dialoguePanel;
    public GameObject player;
    Button siButton;
    Button noButton;
    Text dialogueText;
    int dialogueIndex;
    public static bool inDialogue;
    public static int gameNumber;
    // Use this for initialization
    void Awake () {
        

        siButton = dialoguePanel.transform.Find("Si").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        noButton = dialoguePanel.transform.Find("No").GetComponent<Button>();

        siButton.onClick.AddListener(delegate { ContinueDialogue(); } );
        noButton.onClick.AddListener(delegate { DeclineDialogue(); });
        dialoguePanel.SetActive(false);

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

	}

    private void Start()
    {
        inDialogue = false; 
    }

    public void AddNewDialogue(string [] lines)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        dialoguePanel.SetActive(true);
        inDialogue = true;
        
        
    }

    public void ContinueDialogue()
    {

        if (dialogueIndex < dialogueLines.Count-1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex]; 
        }

        else
        {

            dialoguePanel.SetActive(false);
            inDialogue = true;

            SceneTransition.makeTransition = true;
            
        }
    }

    public static void LoadGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void DeclineDialogue()
    {
        dialoguePanel.SetActive(false);
        inDialogue = false;
    }
}
