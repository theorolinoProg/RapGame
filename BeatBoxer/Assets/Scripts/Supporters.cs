using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supporters : MonoBehaviour
{
    private float time = 0.0f;
    public GameObject[] specs;
    public double delayTime = 0.3;
    private float counter = 0;
    //float timeBetweenLaunches = 0.5f;

    private void Update()
    {
        delayTime = Random.Range(1f, 3f);
        if (counter > delayTime)
        {
            StartCoroutine(SpecJumps());
            StartCoroutine(SpecJumps());
            StartCoroutine(SpecJumps());

            counter = 0;
        }
        counter += Time.deltaTime;

    }

    IEnumerator SpecJumps()
    {
        float timeBetweenLaunches = Random.Range(0.1f, 0.3f);
        for (int i = 0; i < 9; i++)
        {
            int x = Random.Range(0, 157);
            int x2 = Random.Range(0, 157);
            if (specs[x].GetComponent<Rigidbody>().velocity.magnitude == 0 && specs[x2].GetComponent<Rigidbody>().velocity.magnitude == 0)
            {
                specs[x].GetComponent<Rigidbody>().velocity = transform.up * Time.deltaTime * 100;
                specs[x2].GetComponent<Rigidbody>().velocity = transform.up * Time.deltaTime * 100;
            }
            yield return new WaitForSeconds(timeBetweenLaunches);
        }
    }
    IEnumerable SpecMessages()
    {
        float timeBetweenLaunches = Random.Range(0.5f, 1.5f);
        int x = Random.Range(0, 157);
        int x2 = Random.Range(0, 157);

        // verifier si a la position + y il y a deja un message si oui pas afficher si non afficher un message aléatoire.
        if (specs[x].GetComponent<Rigidbody>().velocity.magnitude == 0 && specs[x2].GetComponent<Rigidbody>().velocity.magnitude == 0)
        {
            specs[x].GetComponent<Rigidbody>().velocity = transform.up * Time.deltaTime * 100;
            specs[x2].GetComponent<Rigidbody>().velocity = transform.up * Time.deltaTime * 100;
        }
        yield return new WaitForSeconds(timeBetweenLaunches);
    }
}
