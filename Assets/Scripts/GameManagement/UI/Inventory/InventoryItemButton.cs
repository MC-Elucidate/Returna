﻿using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemButton : MonoBehaviour, ISelectHandler, ISubmitHandler, ICancelHandler
{

	[SerializeField]
	private TextMeshProUGUI nameText;
	[SerializeField]
	private TextMeshProUGUI equipText;

	private Weapon inventoryItem;

	public void Initialise(Weapon inventoryItem)
	{
		this.inventoryItem = inventoryItem;
		SetTextValues();
	}

	public void SetTextValues()
	{
		nameText.text = inventoryItem.Name;
		equipText.text = InventoryManager.instance.EquippedWeapon == inventoryItem ? "EQUIPPED" : "";
	}

	public void OnSelect(BaseEventData eventData)
	{
		InventoryMenuManager.instance.UpdateItemDetailPanel(inventoryItem);
		MenuSoundSource.instance.PlayNextItemSound();
	}

	public void OnSubmit(BaseEventData eventData)
	{
		try
		{
			InventoryManager.instance.TryEquipWeapon(inventoryItem);
			MenuSoundSource.instance.PlayActionSuccessSound();
			InventoryMenuManager.instance.UpdateButtons();
		}
		catch (NotifyException exception)
		{
			NotificationHandler.instance.DisplayErrorNotification(exception.Message);
		}
	}

	public void OnCancel(BaseEventData eventData)
	{
		InventoryMenuManager.instance.CloseInventoryMenu();
	}
}
