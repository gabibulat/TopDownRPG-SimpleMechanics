using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private Animator _cameraAnimator;
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _player.SetCutscene(true);
            _cameraAnimator.SetBool("cutscene1", true);
            Invoke(nameof(StopCutscene), 2f);
        }
    }
    void StopCutscene()
    {
        _cameraAnimator.SetBool("cutscene1", false);
        _player.SetCutscene(false);
        Destroy(gameObject);
    }
}
