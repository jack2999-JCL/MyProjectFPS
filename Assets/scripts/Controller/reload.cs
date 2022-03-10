using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class reload : MonoBehaviour
{
    public int maxAmmo = 20;
    public int defaultAmmo = 20;
    public int currentAmmo;
    public float reloadSpeed = 10f;

    public Text ammoText;
    public bool needReload;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = defaultAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo <= 0)
            needReload = true;
            // StartCoroutine(Reload());

        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(Reload());
        
        ammoText.text = currentAmmo + "/" + maxAmmo;
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reload");
        yield return new WaitForSeconds(reloadSpeed);
        currentAmmo = defaultAmmo;
        needReload = false;
    }

}
