using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShip : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 10f;


    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;

    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRowFactor = -20;

    [SerializeField] GameObject deathFX;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
        
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControllThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControllThrow;


        transform.localRotation = Quaternion.Euler(
            pitch,
            transform.localPosition.x * positionYawFactor,
            xThrow * controlRowFactor
            );
    }

    private void ProcessTranslation()
    {
         xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
         yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;
        //print(xOffset);
        float rawNewX = transform.localPosition.x + xOffset;
        float rawNewY = transform.localPosition.y + yOffset;
        transform.localPosition = new Vector3(Mathf.Clamp(rawNewX, -6f, 6f), Mathf.Clamp(rawNewY, -3.5f, 3.5f), transform.localPosition.z);
    }

    void OnPlayerDeath()
    {
        deathFX.SetActive(true);
        isControlEnabled = false;
        print(66666);
    }


}
