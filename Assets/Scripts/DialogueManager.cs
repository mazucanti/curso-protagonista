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
	public GameObject sceneManager;

	private SentenceItem[] sentences;
	public bool endOfDialogue;
	private string tagNPC;

	private int i;

	// Use this for initialization
	void Start()
	{
		endOfDialogue = true;
		yesButton.SetActive(false);
		noButton.SetActive(false);
		continueButton.SetActive(true);
		i = 0;
	}

	public void StartConversation (Dialogue dialogue)
    {
        if (!animator.GetBool("isOpen") && !(FindObjectOfType<PauseManager>().animator.GetBool("isOpen")))
        {
			endOfDialogue = false;
			animator.SetBool("isOpen", true);
			nameText.text = dialogue.name;
			tagNPC = dialogue.tag;

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

	public void Yes ()
    {
		if (tagNPC.Equals("Vendedor"))
        {
			sceneManager.GetComponent<LoadScenes>().LoadStore();
        }
				else if (tagNPC.Equals("Colega"))
        {
			// formar equipe.
        }
		else if (tagNPC.Equals("Monster"))
        {
			// Baby Dragon 
			if (nameText.text.Equals("Baby Dragon"))
			{
				if (sentenceText.text.Equals("Voce quer entlar pla minha equipe?"))
				{
					// formar equipe com baby dragon.
				}
				else
				{
					// batalha com baby dragon
				}
			}

			// Other monsters
            else
            {
				// começar batalha com monstro.
			}
		}
    }

}
