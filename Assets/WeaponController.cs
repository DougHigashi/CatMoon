﻿
using UnityEngine;

public class WeaponController : MonoBehaviour
{
	public int selectedWeapon = 0;

	void Start()
	{
		SelectedWeapon();
	}

	void Update()
	{
		int previousSelectedWeapon = selectedWeapon;

		if(Input.GetAxis("Mouse ScrollWheel")> 0f)
		{	
			if(selectedWeapon >= transform.childCount - 1)
			{
				selectedWeapon = 0;
			}
			else
			{
				selectedWeapon++;
			}
		}
		if (Input.GetAxis("Mouse ScrollWheel")<0f)
		{	
			if (selectedWeapon <= 0) 
			{
				selectedWeapon = transform.childCount - 1;
			}
			else
			{
				selectedWeapon--;
			}
		}
		if(previousSelectedWeapon != selectedWeapon)
		{
			SelectedWeapon();
		}
	}


	void SelectedWeapon()
	{
		int i = 0;
		foreach(Transform weapon in transform)
		{
			if(i == selectedWeapon)
			{
				weapon.gameObject.SetActive(true);
			}
			else
			{
				weapon.gameObject.SetActive(false);
			}	
			i++;
		}
	}
}
