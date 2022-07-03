using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _health.MaxHealth;
    }

    private void Update()
    {
        _slider.value = _health.HealthProperty;
    }
}
