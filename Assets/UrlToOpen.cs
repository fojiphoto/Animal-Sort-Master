using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlToOpen : MonoBehaviour
{
    public string urlToopen = "https://cbgprivacypolicy.blogspot.com/2023/02/privacy-policy.html";
    public void OpenPrivacyURL()
    {
        // Open the URL in a web browser
        Application.OpenURL(urlToopen);
    }
   
}
