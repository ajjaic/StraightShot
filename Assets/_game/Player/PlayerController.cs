using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Effects;

public class PlayerController : MonoBehaviour
{
    private bool _isPlayerDead;
    private float _xThrow, _yThrow;

    [Header("Position factors")] 
    [SerializeField] private float positionPitchFactor = -4f;
    [SerializeField] private float positionYawFactor = 1.875f;

    [Header("Control throw factors")] 
    [SerializeField] private float rotationPitchFactor = -15;
    [SerializeField] private float rotationRollFactor = -30f;

    [Header("Bounds")] 
    [SerializeField] private float xPosRange = 11f;
    [SerializeField] private float yPosRange = 8f;

    [Header("Movement speed")] 
    [Tooltip("In ms^-1")] [SerializeField] private float xSpeed = 15;
    [Tooltip("In ms^-1")] [SerializeField] private float ySpeed = 15;

    [Header("Particle Weapons")] 
    [SerializeField] private ParticleSystem[] particleWeapons;

    // messages

    private void Start()
    {
        foreach (ParticleSystem weapon in particleWeapons)
        {
            weapon.Play();
            var e = weapon.emission;
            e.enabled = false;
        } 
    }

    private void Update()
    {
        if (!_isPlayerDead)
        {
            Translate();
            Rotate();
            Fire();
        }
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire"))
        {
            foreach (ParticleSystem weapon in particleWeapons)
            {
                var e = weapon.emission;
                e.enabled = true;
            }
        }

        if (Input.GetButtonUp("Fire"))
        {
            foreach (ParticleSystem weapon in particleWeapons)
            {
                var e = weapon.emission;
                e.enabled = false;
            }
        }
    }

    // methods
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

    // API
    public void OnPlayerDeath()
    {
        _isPlayerDead = true;
    }
}