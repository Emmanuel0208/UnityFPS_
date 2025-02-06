using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeaponChangeAdvance : MonoBehaviour
{
    public TwoBoneIKConstraint leftHand;
    public TwoBoneIKConstraint rightHand;
    public RigBuilder rig;
    public Transform[] leftTargets;
    public Transform[] rightTargets;
    public GameObject[] weapons;
    private int weaponNumber = 0;

    void Start()
    {
        UpdateWeapon();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            weaponNumber++;
            if (weaponNumber > weapons.Length - 1)
            {
                weaponNumber = 0; 
            }
            UpdateWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            weaponNumber--;
            if (weaponNumber < 0)
            {
                weaponNumber = weapons.Length - 1; 
            }
            UpdateWeapon();
        }
    }

    private void UpdateWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        weapons[weaponNumber].SetActive(true);

        leftHand.data.target = leftTargets[weaponNumber];
        rightHand.data.target = rightTargets[weaponNumber];

        rig.Build();
    }
}
