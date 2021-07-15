using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private float _multiplyValue;
    [SerializeField] private float _duration;

    private PlayerMover _player;
    private bool _isBoosted = false;
    private float _passTime;

    private void Update()
    {
        if (_isBoosted)
        {
            _passTime += Time.deltaTime;

            if (_duration <= _passTime)
            {
                _player.ShareSpeed(_multiplyValue);
                
                _passTime = 0;

                _isBoosted = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover player))
        {
            _player = player;

            _player.MultiplySpeed(_multiplyValue);
            _isBoosted = true;
        }
    }
}
