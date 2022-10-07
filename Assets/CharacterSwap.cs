using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class CharacterSwap : MonoBehaviour
{
    public Transform myOrientation;
    public Transform character;
    public List<Transform> possibleCharacters;
    public int whichCharacter;
    public CinemachineFreeLook cam;

    private bool canShoot = true;

    [SerializeField] private TextMeshProUGUI timeDisplay;

    // Start is called before the first frame update
    void Start()
    {
        if(character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
        }
        Swap();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))

        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(DelaySwap(7f));
        }
    }


    public IEnumerator DelaySwap(float time)
    {
        canShoot = false;
        float timerStart = 0f;
        int showTimer = 0;

        while (timerStart <= time)
        {
            yield return new WaitForFixedUpdate();
            timerStart += Time.fixedDeltaTime;
            showTimer = (int)(time - timerStart);

            timeDisplay.SetText((showTimer).ToString());
        }

        if (whichCharacter == 0)
        {
            whichCharacter = possibleCharacters.Count - 1;
        }
        else
        {
            whichCharacter -= 1;
        }
        Swap();
        canShoot = true;
    }    

    public void Swap()
    {
        character = possibleCharacters[whichCharacter];
        character.GetComponent<CharacterMovement>().blaster.GetComponent<Blast>().Reload();
        character.GetComponent<CharacterMovement>().enabled = true;
        character.GetComponent<CharacterMovement>().blaster.SetActive(true);
        cam.GetComponent<TPCam>().orientation = character.GetComponent<CharacterMovement>().orientation;
        cam.GetComponent<TPCam>().playerBody = character.GetComponent<CharacterMovement>().myPlayerBody;
        cam.GetComponent<TPCam>().player = character.transform;
        cam.GetComponent<TPCam>().rb = character.GetComponent<CharacterMovement>().myRb;


        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if(possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<CharacterMovement>().enabled = false;
                possibleCharacters[i].GetComponent<CharacterMovement>().blaster.SetActive(false);
            }
        }
        cam.LookAt = character;
        cam.Follow = character;
    }
}
