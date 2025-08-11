using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilitiesLogic : MonoBehaviour {
    [SerializeField] Material _visible;
    [SerializeField] Material _invisible;
    Renderer _playerRenderer;

    float _playerSpeedFactor = 0.5f;

    PlayerMovement _playerMovement;

    float _originalSpeed;

    public void Init(PlayerMovement playerMovement) {
        _playerMovement = playerMovement;
    }

    private void Awake() {
        _playerRenderer = GetComponent<Renderer>();
    }
    private void Start() {
        _playerRenderer.material = _visible;
        _originalSpeed = _playerMovement.GetPlayerSpeed();
    }
    public void DisapearingHandler() {
        if (_playerRenderer != null) _playerRenderer.material = _invisible;
        _playerMovement.SetPlayerSpeed(_originalSpeed * _playerSpeedFactor);
    }
    public void AppearingHandler() {
        if (_playerRenderer != null) _playerRenderer.material = _visible;
        _playerMovement.SetPlayerSpeed(_originalSpeed);
    }

    public Material GetVisibleMaterial() {
        return _visible;
    }
    public Material GetInvisibleMaterial() {
        return _invisible;
    }
    public Material GetPlayerMaterial() {
        return _playerRenderer.sharedMaterial;
    }
}
