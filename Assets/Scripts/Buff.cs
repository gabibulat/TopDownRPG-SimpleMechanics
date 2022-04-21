using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Buff : MonoBehaviour
{
    [SerializeField] private Player _player;
    private string _affectedStatname;
    private float _adds;

    public void AddBuff(Item item)
    {
        var list = item.GetListAffectedValues();
        _affectedStatname = item.GetStatAffected();

        if (list[0] < 1 && list[0] > 0) //if is persentage
        {
            if (_affectedStatname == "CurrentHealth" || _affectedStatname == "MaxHealth") list[0] = (_player.GetValue("MaxHealth") * list[0]);
            else if (_affectedStatname == "CurrentMana" || _affectedStatname == "MaxMana") list[0] = (_player.GetValue("MaxMana") * list[0]);
            else list[0] = (_player.GetValue(_affectedStatname) * list[0]);
        }

        switch (list.Count)
        {
            case 2:
                StartCoroutine(case2(list[0], list[1]));
                break;
            case 3:
                StartCoroutine(case3(list[0], list[2], list[1], () => _adds = list[0] * Time.deltaTime / list[2]));
                break;
            case 4:
                StartCoroutine(case4(list[2], () => _adds = list[0] * Time.deltaTime / list[3]));
                break;
        }

    }
    IEnumerator case2(float add, float seconds)
    {
        _player.AddBuff(_affectedStatname, add);
        yield return new WaitForSeconds(seconds);
        _player.AddBuff(_affectedStatname, add * -1);
        Destroy(gameObject);
    }
    IEnumerator case3(float add, float overTime, float holdSeconds, System.Action aCallback)
    {
        float t = 0f;
        while (t < overTime)
        {
            t += Time.deltaTime;
            aCallback();
            _player.AddBuff(_affectedStatname, _adds);
            yield return null;
        }
        yield return new WaitForSeconds(holdSeconds);
        _player.AddBuff(_affectedStatname, add * -1);
        Destroy(gameObject);
    }

    IEnumerator case4(float overTime, System.Action aCallback)
    {
        float t = 0f;
        while (t < overTime)
        {
            t += Time.deltaTime;
            aCallback();
            _player.AddBuff(_affectedStatname, _adds);
            yield return null;
        }
        Destroy(gameObject);
    }
}
