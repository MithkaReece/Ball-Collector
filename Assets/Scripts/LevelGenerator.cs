using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform ballGroup;

    [SerializeField] float minYPosition = -5f;
    [SerializeField] float maxYPosition = 5f;
    [SerializeField] float minZPosition = -5f;
    [SerializeField] float maxZPosition = 5f;
    [SerializeField] float ballPadding = 3f;
    [SerializeField] float maxTries;

    [SerializeField] List<Material> pegMaterials = new List<Material>();

    public void CreateLevel(int difficulty)
    {
        LevelManager.Init();
        LevelManager.EnableDifficultyMenu(false);


        int numberOfBalls = 1;
        float blackChance = 0.0f;
        float purpleChance = 0.0f;

        switch (difficulty)
        {
            case 0: //Easy
                numberOfBalls = 150;
                blackChance = 0.0f;
                purpleChance = 0.1f;
                break;
            case 1: //Medium
                numberOfBalls = 100;
                blackChance = 0.05f;
                purpleChance = 0.2f;
                break;
            case 2: //Hard
                numberOfBalls = 100;
                blackChance = 0.15f;
                purpleChance = 0.35f;
                break;
        }

            for (int i = 0; i < numberOfBalls; i++)
        {
            bool isValidPosition = false;
            Vector3 spawnPosition = Vector3.zero;

            float tries = 0;

            // Try to find a valid spawn position
            while (!isValidPosition)
            {
                tries++;
                float randomYPosition = Random.Range(minYPosition, maxYPosition);
                float randomZPosition = Random.Range(minZPosition, maxZPosition);

                spawnPosition = new Vector3(0.0f, randomYPosition, randomZPosition);

                // Check for collisions with other spawned objects
                Collider[] colliders = Physics.OverlapSphere(spawnPosition, ballPadding);

                if (colliders.Length == 0)
                    isValidPosition = true;

                if(tries > maxTries)
                    return;
                
            }

            GameObject newBallObject = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            newBallObject.transform.parent = ballGroup;

            BallController ballController = newBallObject.GetComponent<BallController>();
            Renderer ballRenderer = newBallObject.GetComponent<Renderer>();

            float randomValue = Random.value;

            if (randomValue <= blackChance)
            {
                ballController.SetType("Black");
                ballRenderer.material = pegMaterials[2];
            }
            else if (randomValue <= purpleChance)
            {
                ballController.SetType("Purple");
                ballRenderer.material = pegMaterials[1];
            }
            else
            {
                ballController.SetType("Orange");
                ballRenderer.material = pegMaterials[0];
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
