using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public static GameObject Player;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        DontDestroyOnLoad(this);
        DontDestroyOnLoad(Player);
    }

    void Start()
    {
    }
}
