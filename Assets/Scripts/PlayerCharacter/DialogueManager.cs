﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	private Queue<DialogueItem> dialogueItems;

	[HideInInspector]
	public DialogueItem CurrentDialogueItem;

	public bool InDialogue;

	public event EventHandler OnDialogueStart;
	public event EventHandler OnDialogueNextSentence;
	public event EventHandler OnDialogueEnd;
	public event EventHandler OnBattleEvent;
	public event EventHandler OnMoneyGainEvent;

	public void StartDialogue(params DialogueItem[] dialogueItems)
	{
		InDialogue = true;
		this.dialogueItems = GetDialogueArray(dialogueItems);
		if (OnDialogueStart != null)
			OnDialogueStart(this, new EventArgs());
		NextSentence();
	}

	public void NextSentence()
	{
		CheckDialogueEvents();

		if (dialogueItems.Count == 0)
		{
			EndDialogue();
			return;
		}

		CurrentDialogueItem = dialogueItems.Dequeue();

		if (OnDialogueNextSentence != null)
			OnDialogueNextSentence(this, new EventArgs());
	}

	private void CheckDialogueEvents()
	{
		if (CurrentDialogueItem != null && CurrentDialogueItem.DialogueEvent != EDialogueEvent.None)
		{
			HandleDialogueEvent();
		}
	}

	public void EndDialogue()
	{
		dialogueItems = null;
		CurrentDialogueItem = null;
		InDialogue = false;
		if (OnDialogueEnd != null)
			OnDialogueEnd(this, new EventArgs());
	}

	private void HandleDialogueEvent()
	{
		switch (CurrentDialogueItem.DialogueEvent)
		{
			case EDialogueEvent.BattleStart:
				if (OnBattleEvent != null)
					OnBattleEvent(this, new EventArgs());
				break;
			case EDialogueEvent.MoneyGain:
				if (OnMoneyGainEvent != null)
					OnMoneyGainEvent(this, new EventArgs());
				break;
		}
	}


	private Queue<DialogueItem> GetDialogueArray(params DialogueItem[] Dialogue)
	{
		Queue<DialogueItem> dialogue = new Queue<DialogueItem>();
		foreach (DialogueItem sentence in Dialogue)
		{
			dialogue.Enqueue(sentence);
		}
		return dialogue;
	}
}

[System.Serializable]
public class DialogueItem
{
	public string Text;
	public string SpeakerName;
	public EDialogueEvent DialogueEvent = EDialogueEvent.None;
}