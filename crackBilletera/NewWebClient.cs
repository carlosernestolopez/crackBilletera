using System;
using System.Net;

namespace crackBilletera
{
public class NewWebClient : WebClient
{
    private WebRequest _request = null;

    public NewWebClient(CookieContainer cookies = null, bool autoRedirect = true)
    {
        CookieContainer = cookies ?? new CookieContainer();
        AutoRedirect = autoRedirect;
    }

    public bool AutoRedirect { get; set; }

    public CookieContainer CookieContainer { get; set; }

    public string Cookies
    {
        get { return GetHeaderValue("Set-Cookie"); }
    }

    public string Location
    {
        get { return GetHeaderValue("Location"); }
    }

    public HttpStatusCode StatusCode
    {
        get
        {
            var result = HttpStatusCode.Gone;

            if (_request != null)
            {
                var response = base.GetWebResponse(_request) as HttpWebResponse;

                if (response != null)
                {
                    result = response.StatusCode;
                }
            }

            return result;
        }
    }

    public Action<HttpWebRequest> Setup { get; set; }

    public string GetHeaderValue(string headerName)
    {
        if (_request != null)
        {
            return base.GetWebResponse(_request)?.Headers?[headerName];
        }

        return null;
    }

    protected override WebRequest GetWebRequest(Uri address)
    {
        _request = base.GetWebRequest(address);

        var httpRequest = _request as HttpWebRequest;
        httpRequest.Timeout = 1000 * 10;

        if (_request != null)
        {
            httpRequest.AllowAutoRedirect = AutoRedirect;
            httpRequest.CookieContainer = CookieContainer;
            httpRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            Setup?.Invoke(httpRequest);
        }

        return _request;
    }
}

}