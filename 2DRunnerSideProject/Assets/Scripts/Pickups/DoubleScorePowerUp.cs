using UnityEngine;
using System.Collections;
public class DoubleScorePowerUp : MonoBehaviour, IPowerUp
{
    public PowerUp doubleScorePU = new PowerUp();

    SpriteRenderer spriteRenderer;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        if(scoreKeeper == null)
        {
            scoreKeeper = FindObjectOfType<ScoreKeeper>();
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
    }

    public void ApplyPowerUp()
    {
        StartCoroutine(IncrementScoreMultiplier());
    }
    
    private IEnumerator IncrementScoreMultiplier()
    {
        spriteRenderer.enabled = false;
        scoreKeeper.ScoreMultiplier += doubleScorePU.effectMagnitude;
        yield return new WaitForSeconds(doubleScorePU.powerUpDuration);
        scoreKeeper.ScoreMultiplier = scoreKeeper._scoreMultiplier;
        gameObject.SetActive(false);
    }
}