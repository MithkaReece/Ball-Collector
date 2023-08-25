using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firing : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform ballGroup;

    [SerializeField] float fireForce = 10f;
    [SerializeField] float spawnOffsetScale = 1.5f;

    [SerializeField] int startNumberOfBalls = 5;
    [SerializeField] int numberOfBallsLeft;
    public Text BallsLeftText;

    static Firing instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.FreeBall += AddFreeBall;
        BallsLeftText.text = "Balls Left: " + numberOfBallsLeft;
    }

    void OnEnable()
    {
        numberOfBallsLeft = startNumberOfBalls;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            FireBall();
        Debug.Log(LevelManager.GetNumberOfActiveBalls());
    }

    void FireBall()
    {
        if (LevelManager.GetNumberOfActiveBalls() > 0)
        {
            return; // Still active balls
        }



        // Calculate the spawn position with the offset
        Vector3 spawnPosition = transform.position + transform.forward * spawnOffsetScale + Vector3.up;
        spawnPosition.x = ballPrefab.transform.position.x;

        // Instantiate the ball prefab at the current object's position and rotation
        GameObject newBall = Instantiate(ballPrefab, spawnPosition, transform.rotation);
        newBall.transform.parent = ballGroup;
        newBall.transform.localScale = new Vector3(LevelManager.BallSize, LevelManager.BallSize, LevelManager.BallSize);

        numberOfBallsLeft--;
        BallsLeftText.text = "Balls Left: " + numberOfBallsLeft;


    
        // Fire ball
        newBall.GetComponent<Rigidbody>()?.AddForce(transform.forward * fireForce, ForceMode.Impulse);


    }

    void AddFreeBall()
    {
        numberOfBallsLeft++;
        BallsLeftText.text = "Balls Left: " + numberOfBallsLeft;
    }

    private void OnDestroy()
    {
        EventManager.FreeBall -= AddFreeBall;
    }

    public static bool HasBallsLeft()
    {
        return instance.numberOfBallsLeft > 0;
    }
}
