using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public Text nameText;
	public Text sentenceText;
	public GameObject continueButton;
	public GameObject yesButton;
	public GameObject noButton;
	public Animator animator;

	private SentenceItem[] sentences;
	public bool endOfDialogue;

	private int i;

	// Use this for initialization
	void Start()
	{
		yesButton.SetActive(false);
		noButton.SetActive(false);
		continueButton.SetActive(true);
		i = 0;
	}

	public void StartConversation (Dialogue dialogue)
    {
		endOfDialogue = false;
		animator.SetBool("isOpen", true);
		nameText.text = dialogue.name;

		i = 0;

		sentences = new SentenceItem[dialogue.sentences.Length];
		sentences = dialogue.sentences;

		DisplaySentence();
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

		if (sentences[i].yesNo)
        {
			yesButton.SetActive(true);
			noButton.SetActive(true);
			continueButton.SetActive(false);
		}
        else
        {
			yesButton.SetActive(false);
			noButton.SetActive(false);
			continueButton.SetActive(true);
		}
	}

	public void Next ()
    {
		i++;
		DisplaySentence();
	}

}
