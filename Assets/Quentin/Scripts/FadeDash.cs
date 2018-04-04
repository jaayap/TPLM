using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class FadeDash : MonoBehaviour {

    public float dashTime = 0.1f;
    public PostProcessingProfile ppProfile;

    private bool isFadingDashIn = false;

    public void DoDashWithTranslation(Vector3 position)
    {
        StartCoroutine(DoDashWithFadeTranslation(position));
    }

    IEnumerator  DoDashWithFadeTranslation(Vector3 endPoint)
    {
        isFadingDashIn = true;

        float elapsed = 0f;

        Vector3 startPoint = transform.position;

        while (elapsed < dashTime)
        {

            elapsed += Time.deltaTime;
            float elapsedPct = elapsed / dashTime;

            RiseFadeDash(elapsedPct);

            transform.position = Vector3.Lerp(startPoint, endPoint, elapsedPct);
            yield return null;
        }

        isFadingDashIn = false;

        StartCoroutine(DownFadeDash());
    }

    void RiseFadeDash(float value)
    {
        VignetteModel.Settings vignetteSettings = ppProfile.vignette.settings;

        //change the intensity in the temporary settings variable
        vignetteSettings.opacity += value;
        if (vignetteSettings.opacity > 1)
        {
            vignetteSettings.opacity = 1;
        }

        //set the vignette settings in the actual profile to the temp settings with the changed value
        ppProfile.vignette.settings = vignetteSettings;
    }

    IEnumerator DownFadeDash()
    {
        VignetteModel.Settings vignetteSettings = ppProfile.vignette.settings;

        while (!isFadingDashIn && vignetteSettings.opacity > 0)
        {
            vignetteSettings.opacity -= Time.deltaTime;
            //set the vignette settings in the actual profile to the temp settings with the changed value
            ppProfile.vignette.settings = vignetteSettings;
            yield return new WaitForSeconds(0.01f);
        }
    }

}
