using System;
using System.Collections.Generic;
using System.IO;
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

    public make_req(RawCoordinates coordinates , GameObject[] a)
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
           // List<string> searchobjects = new List<string> { "line", "house", "car", "triangle" };
            string resp = streamReader.ReadToEnd();



            /*

            JArray a = JArray.Parse(resp);
            foreach (JObject o in a.Children<JObject>())
            {
                foreach (JProperty p in o.Properties())
                {
                    string name = p.Name;
                    string value = (string)p.Value;
                    Console.WriteLine(name + " -- " + value);
                }
            }
            */


            /*
            bool found = false;
            string element="";
            foreach (GameObject s in drawables)
            {
                if (resp.IndexOf(s) != -1)
                {
                    found = true;
                    element = s.;
                    break;
                }

            }
           
            if (found)
            {
                //Debug.Log(element + " found");
                Debug.Log(resp);
            
        }
            else
            {
                Debug.Log(resp);
            }
 */
        }
    }
}
