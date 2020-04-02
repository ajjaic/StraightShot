﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] private float xSpeed = 15;
    [Tooltip("In ms^-1")] [SerializeField] private float ySpeed = 15;
    [SerializeField] private float xPosRange = 11f;
    [SerializeField] private float yPosRange = 8f;

    [SerializeField] private float positionPitchFactor = -4f;
    [SerializeField] private float positionYawFactor = 1.875f;
    [SerializeField] private float rotationPitchFactor = -15;
    [SerializeField] private float rotationRollFactor = -30f;
    private float _xThrow, _yThrow;
    
    private void Update()
    {
        Translate();
        Rotate();
    }

    private void Rotate()
    {
        float xRot = 0, yRot = 0, zRot = 0;
        xRot = transform.localPosition.y * positionPitchFactor + _yThrow * rotationPitchFactor;
        yRot = transform.localPosition.x * positionYawFactor;
        zRot = _xThrow * rotationRollFactor;
        // zRot = _xThrow * rotationPitchFactor;
        
        transform.localRotation = Quaternion.Euler(xRot, yRot, zRot);
    }

    private void Translate()
    {
        _xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        _yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        var xOffsetThisFrame = _xThrow * xSpeed * Time.deltaTime;
        var yOffsetThisFrame = _yThrow * ySpeed * Time.deltaTime;
        var newXPos = Mathf.Clamp(transform.localPosition.x + xOffsetThisFrame, -xPosRange, xPosRange);
        var newYPos = Mathf.Clamp(transform.localPosition.y + yOffsetThisFrame, -yPosRange, yPosRange);

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }
}
