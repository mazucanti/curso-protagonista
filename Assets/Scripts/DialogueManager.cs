using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public Text nameText;
	public Text sentenceText;
	public Animator animator;

	private string[] sentences;

	private int i;

	// Use this for initialization
	void Start()
	{
		i = 0;
	}

	public void StartConversation (Dialogue dialogue)
    {
		animator.SetBool("isOpen", true);
		nameText.text = dialogue.name;

		i = 0;

		sentences = new string[dialogue.sentences.Length];
		sentences = dialogue.sentences;

		DisplaySentence();
    }

	public void DisplaySentence()
    {
		if (i == sentences.Length)
		{
			animator.SetBool("isOpen", false);
			return;
		}

		string sentence = sentences[i];
		sentenceText.text = sentence;
	}

	public void Next ()
    {
		i++;
		DisplaySentence();
	}

}
