using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField]
    List<Transform> transforms;

    [SerializeField]
    List<GameObject> objects;

    public bool active;
    public float speed;
    public float difficulty;

    float timer;
    float timeToNext;

    public void SetActive()
    {
        active = true;
    }

    void Update()
    {
        if(active)
        {
            timer += Time.deltaTime;
            if (timer >= timeToNext)
            {
                Spawn();
                timeToNext = speed / Random.Range(1, difficulty);
                timer = 0;
            }
        }
    }
    void Spawn()
    {
        Instantiate(objects[Random.Range(0, objects.Count)], transforms[Random.Range(0, transforms.Count)]);
    }

    public void ChangeDifficulty(int newDifficulty)
    {
        difficulty += newDifficulty;
    }
    public void ChangeBaseSpeed(int newDifficulty)
    {
        speed = newDifficulty;
    }

}
