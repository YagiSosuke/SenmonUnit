using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    AudioSource audio;
    [SerializeField] AudioClip clip;
    public HPScript HPscript;
    [SerializeField] GameObject DeadBack;
    [SerializeField] GameObject DeadWord;
    Image BackImage;
    Image WordImage;

    float count = 0;
    public bool DeadF = false;

    void Start()
    {
        audio = this.gameObject.GetComponent<AudioSource>();

        BackImage = DeadBack.GetComponent<Image>();
        WordImage = DeadWord.GetComponent<Image>();

        BackImage.color = new Color(1, 1, 1, 0);
        WordImage.color = new Color(1, 1, 1, 0);
    }


    void Update()
    {
        if (DeadF)
        {
            if(count == 0)
            {
                audio.Stop();
            }
            count += Time.deltaTime;
            if (count < 1f)
            {

            }
            else if(count < 3f)
            {
                audio.PlayOneShot(clip);
                BackImage.color = WordImage.color = Color.Lerp(new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), (count-1)/2);
                DeadWord.transform.localScale = new Vector3(1 + (0.3f * (count-1)/2), 1 + (0.3f * (count-1)/2), 1);
            }
            else if(count < 5f)
            {

            }
            else {
                feadSC.fade("Losing");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy") 
        {
            HPscript.ReceiveDamage();
            if (HPScript.HP == 0)
            {
                DeadBack.SetActive(true);
                DeadWord.SetActive(true);
                DeadF = true;
            }
        }
    
    }
}
