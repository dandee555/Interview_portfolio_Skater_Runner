using UnityEngine;
using UnityEngine.Assertions;

public class Fish : MonoBehaviour, ICollectable
{
    #region Private Fields

    [SerializeField] private Collider _collider;
    [SerializeField] private Animator _animator;
    [SerializeField] private Chunk    _chunk;

    private const string TRIGGER_PICKUP = "PickUp";
    private const string TRIGGER_IDLE   = "Idle";

    #endregion

    #region Unity Methods

    private void Awake()
    {
        Assert.IsNotNull(_collider, $"{nameof(_collider)} in {this} is null");
        Assert.IsNotNull(_animator, $"{nameof(_animator)} in {this} is null");
        Assert.IsNotNull(_chunk,    $"{nameof(_chunk)   } in {this} is null");
    }

    private void Start()
    {
        _chunk.OnShowChunk += OnReset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            OnPickUp();
        }
    }

    private void OnDestroy()
    {
        _chunk.OnShowChunk -= OnReset;
    }

    #endregion

    #region Interface Functions : ICollectable

    public void OnPickUp()
    {
        _animator.SetTrigger(TRIGGER_PICKUP);
        _collider.enabled = false;
        GameStatsManager.Instance.FishThisRound++;
    }

    #endregion

    #region Private Functions

    /// <summary>
    /// We need to reset the fish when the chunk is respawn.
    /// </summary>
    private void OnReset(object sender, System.EventArgs e)
    {
        _collider.enabled = true;
        _animator.SetTrigger(TRIGGER_IDLE);
    }

    #endregion
}
