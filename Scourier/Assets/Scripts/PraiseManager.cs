using UnityEngine;
using TMPro;

public class PraiseManager : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    [SerializeField] private GameObject Money;

    [SerializeField] PlayerColliderManager coll;

    private Animator praiseAnimator;
    private bool isAnimated = false;

    void Start()
    {
        praiseAnimator = gameObject.GetComponent<Animator>();
    }

    
    void Update()
    {

        if (coll.dropOut && !isAnimated)
        { 
            GetRandomPraiseText();
            praiseAnimator.SetTrigger("triggerPraise");
            isAnimated = true;
        }

        if (!coll.dropOut)
        {
            isAnimated = false;
        }


    }


    void GetRandomPraiseText()
    {
        int rand = Random.Range(0, 4);

        switch (rand)
        {
            case 0:
                Text.GetComponent<TextMeshPro>().text = "PERFECT!!";
                break;
            case 1:
                Text.GetComponent<TextMeshPro>().text = "NICE!!";
                break;
            case 2:
                Text.GetComponent<TextMeshPro>().text = "AMAZING!!";
                break;
            case 3:
                Text.GetComponent<TextMeshPro>().text = "AWESOME!!";
                break;

        }
    }




}
