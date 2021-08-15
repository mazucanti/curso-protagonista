using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerShop : MonoBehaviour
{
	public Text nameText;
	public Text sentenceText;
	public GameObject okButton;
	public Animator animator;
	public GameObject sceneManager;
	public GameObject dialogueBox;
	private float curTime;

	private SentenceItem[] sentences;
	public bool endOfDialogue;

	private int i;

	// Use this for initialization
	void Start()
	{
		endOfDialogue = true;
		i = 0;
	}

    private void Update()
    {
		// Hides dialogue box after 2 seconds.
		curTime += Time.deltaTime;
        if (curTime > 2f)
        {
			animator.SetBool("isOpen", false);
        }
	}

    public void StartConversation(Dialogue dialogue)
	{
		if (!animator.GetBool("isOpen"))
		{
			curTime = 0;
			endOfDialogue = false;
			animator.SetBool("isOpen", true);
			nameText.text = dialogue.name;

			i = 0;

			sentences = new SentenceItem[dialogue.sentences.Length];
			sentences = dialogue.sentences;

			DisplaySentence();
		}

	}

	public void DisplaySentence()
	{
		if (i == sentences.Length)
		{
			animator.SetBool("isOpen", false);
			endOfDialogue = true;
			i = 0;
			return;
		}

		string sentence = sentences[i].text;
		sentenceText.text = sentence;

	}

	public void Next()
	{
		i++;
		DisplaySentence();
	}
}
