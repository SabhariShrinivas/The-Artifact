using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushVisuals : MonoBehaviour
{
    [SerializeField] private Sprite[] bushSprites, fruitSprites, drySprites;
    [SerializeField] private SpriteRenderer[] fruitRenderer;
    public enum BushVarient { bush1, bush2, bush3 }
    public BushVarient bushVarient;
    public float hideTimePerFruit = 0.3f;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        bushVarient = (BushVarient)Random.Range(0, bushSprites.Length);
        Debug.Log(bushVarient);
        sr.sprite = bushSprites[(int)bushVarient];

        for (int i = 0; i < fruitSprites.Length; i++)
        {
            fruitRenderer[i].sprite = fruitSprites[(int)bushVarient];
            fruitRenderer[i].enabled = false;
        }
    }
    public BushVarient GetBushVarient()
    {
        return bushVarient;
    }
    public void SetToDry()
    {
        sr.sprite = drySprites[(int)bushVarient];
    }
    IEnumerator _HideFruits(float time, int index)
    {
        yield return new WaitForSeconds(time);
        fruitRenderer[index].enabled = false;
    }
    public void HideFruits()
    {
        float waitTimeForFruit = hideTimePerFruit;
        for(int i =0; i < fruitRenderer.Length; i++)
        {
            StartCoroutine(_HideFruits(waitTimeForFruit, i));
            waitTimeForFruit += hideTimePerFruit;
        }
    }
    public void ShowFruits()
    {
        for(int i =0; i < fruitRenderer.Length; i++)
        {
            fruitRenderer[i].enabled = true;
        }
    }
}
