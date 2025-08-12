using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInputsHandler))]
[RequireComponent(typeof(PlayerStateMachine))]
[RequireComponent(typeof(PlayerAbilities))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    private PlayerMovement _playerMovement;

    private PlayerInputsHandler _playerInput;
    private PlayerStateMachine _playerStateMachine;
    private PlayerAbilities _playerAbilities;
    private PlayerVisuals _playerVisuals;

    [Header("Settings")]
    [SerializeField] private bool _initializeOnStart = true;

    // Public properties for external access
    public PlayerMovement Movement => _playerMovement;

    public PlayerInputsHandler Input => _playerInput;
    public PlayerStateMachine StateMachine => _playerStateMachine;
    public PlayerAbilities Abilities => _playerAbilities;
    public PlayerVisuals Visuals => _playerVisuals;

    private bool _allComponentsValid = true;

    // Initialization state
    private bool _isInitialized = false;

    public bool IsInitialized => _isInitialized;

    private void Awake()
    {
        CacheComponents();
    }

    private void Start()
    {
        if (_initializeOnStart && !_isInitialized)
        {
            Initialize();
        }
    }

    private void CacheComponents()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInputsHandler>();
        _playerStateMachine = GetComponent<PlayerStateMachine>();
        _playerAbilities = GetComponent<PlayerAbilities>();
        _playerVisuals = GetComponent<PlayerVisuals>();

        ValidateComponents();
    }

    private void ValidateComponents()
    {
        _allComponentsValid = true;

        if (_playerMovement == null)
        {
            Debug.LogError($"PlayerMovement component missing on {gameObject.name}", this);
            _allComponentsValid = false;
        }
        if (_playerInput == null)
        {
            Debug.LogError($"PlayerInputsHandler component missing on {gameObject.name}", this);
            _allComponentsValid = false;
        }
        if (_playerStateMachine == null)
        {
            Debug.LogError($"PlayerStateMachine component missing on {gameObject.name}", this);
            _allComponentsValid = false;
        }

        if (!_allComponentsValid)
        {
            Debug.LogError($"Player initialization will fail due to missing components on {gameObject.name}", this);
        }
    }

    public void Initialize()
    {
        if (_isInitialized)
        {
            Debug.LogWarning($"Player {gameObject.name} is already initialized", this);
            return;
        }

        if (!_allComponentsValid)
        {
            Debug.LogError($"Cannot initialize player {gameObject.name} - missing required components", this);
            return;
        }

        // Initialize in dependency order
        InitializeInput();
        InitializeMovement();
        InitializeStateMachine();
        InitializeAbilities();
        InitializeVisuals();

        _isInitialized = true;
        Debug.Log($"Player {gameObject.name} successfully initialized", this);
    }

    private void InitializeInput()
    {
        // PlayerInputsHandler doesn't need initialization currently
        // But we could add settings injection here if needed
    }

    private void InitializeMovement()
    {
        _playerMovement.Init();
    }

    private void InitializeStateMachine()
    {
        _playerStateMachine.Init();
    }

    private void InitializeAbilities()
    {
        _playerAbilities.Init();
    }
    private void InitializeVisuals()
    {
        _playerVisuals.Init();
    }
}