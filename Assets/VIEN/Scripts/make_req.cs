using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

class make_req
{

    int[] _x;
    int[] _y;
    int width;
    int height;
    GameObject[] drawables;

    private string _response;

    public make_req(RawCoordinates coordinates, GameObject[] a)
    {
        _x = coordinates.X;
        _y = coordinates.Y;
        width = coordinates.Width;
        height = coordinates.Height;
        drawables = a;
    }

    public bool MyRemoteCertificateValidationCallback(System.Object sender,
    X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        bool isOk = true;
        // If there are errors in the certificate chain,
        // look at each error to determine the cause.
        if (sslPolicyErrors != SslPolicyErrors.None)
        {
            for (int i = 0; i < chain.ChainStatus.Length; i++)
            {
                if (chain.ChainStatus[i].Status == X509ChainStatusFlags.RevocationStatusUnknown)
                {
                    continue;
                }
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                bool chainIsValid = chain.Build((X509Certificate2)certificate);
                if (!chainIsValid)
                {
                    isOk = false;
                    break;
                }
            }
        }
        return isOk;
    }


    public void Req()
    {
        ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;

        var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://inputtools.google.com/request?ime=handwriting&app=quickdraw&dbg=1&cs=1&oe=UTF-8");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = @"{

    ""input_type"": 0,
	""requests"": [{
		""language"": ""quickdraw"",
		""writing_guide"": {
			""width"": "; json += width;
            json += @",
			""height"":"; json += height;
            json += @"
        },
		""ink"": [

            [[";
            foreach (float x in _x)
            {
                json += x;
                json += ",";
            }
            json = json.Remove(json.LastIndexOf(","), 1);
            json += "],[";

            foreach (float y in _y)
            {
                json += y;
                json += ",";
            }
            json = json.Remove(json.LastIndexOf(","), 1);
            json += "],[";

            foreach (float y in _y)
            {
                int i = 0;
                json += i;
                json += ",";
                i++;
            }
            json = json.Remove(json.LastIndexOf(","), 1);
            json += "]";

            json += @"
 
			]
		]
	}]
}";

            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            string resp = streamReader.ReadToEnd();

            //check if searchtag in response and add the highest possabillity
            Dictionary<int, GameObject> dict = new Dictionary<int, GameObject>();
            string element = "";
            int index;
            int currentBest = int.MaxValue;
            DrawableBehavior currentBestDrawable = null;
            foreach (GameObject s in drawables)
            {
                var tmpDrawable = s.GetComponent<DrawableBehavior>();
                index = resp.IndexOf(tmpDrawable.SearchTag);

                //if element found, add it
                if (index == -1)
                    continue;
                if (index > currentBest)
                    continue;

                currentBest = index;
                currentBestDrawable = tmpDrawable;
            }
            
            if(currentBestDrawable != null)
            {
                Debug.Log(currentBestDrawable.SearchTag + " found");
                currentBestDrawable.SendMessage("Teleport");
            }
            Debug.Log(resp);
            /*
            if (dict.Count > 0)
            {
                var myList = dict.ToList();
                myList.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key));


                var objfound = myList.FirstOrDefault().Value.GetComponent<DrawableBehavior>();

                Debug.Log(objfound.SearchTag + " found");
                objfound.SendMessage("Teleport");
            }


            Debug.Log(resp);

           */
        }
    }
}
