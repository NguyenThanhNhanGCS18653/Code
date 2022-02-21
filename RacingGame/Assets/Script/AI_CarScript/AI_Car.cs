using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_Car : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform nameUI;
    [SerializeField]
    private Transform hpBG;
    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private GameObject winLv;

    [SerializeField]
    private float hp;
    [SerializeField]
    private Image hpBar;
    private float maxHp = 10f;
    private float timeLerp = .5f;

    [SerializeField]
    private GameObject destroyEffectPrefab;


    private float timeStart = 3f;
    [SerializeField]
    private Text timeStartTxt;

    private void Start()
    {
        target = WayPoint.points[1];

        hp = maxHp;
        hpBar.fillAmount = maxHp;

        hpBG.gameObject.SetActive(false);

    }
    private void Update()
    {
        //timeStart -= 1 * Time.deltaTime;
        //timeStartTxt.text = timeStart.ToString("0");
        StartCoroutine(CountDown());
        if (timeStart <= 0)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            timeStartTxt.gameObject.SetActive(false);
        }
        
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNexWayPoint();
        }
        nameUI.position = transform.position + offset;
        hpBG.position = transform.position + new Vector3(0, 2.75f, 0);

        float currentFill = hp / maxHp;
        if (currentFill != hpBar.fillAmount)
        {
            hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, currentFill, Time.deltaTime * timeLerp);            
        }
    }

    void GetNexWayPoint()
    {
        if (wavepointIndex >= WayPoint.points.Length - 1)
        {
            gameOver.SetActive(true);

            winLv.SetActive(false);
            Time.timeScale = 0f;
            speed = 0f;
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = WayPoint.points[wavepointIndex];
    }
    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        hpBG.gameObject.SetActive(true);
        if (hp <= 0)
        {
            hp = 0f;
            Instantiate(destroyEffectPrefab, transform.position, transform.rotation);
            nameUI.gameObject.SetActive(false);
            hpBG.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(.5f);
        timeStart -= 1 * Time.deltaTime;
        timeStartTxt.text = timeStart.ToString("0");
    }
}
