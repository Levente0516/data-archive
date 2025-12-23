using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownloader_.Model
{
    public class WebImage
    {
        public Uri Url { get; private set; }
        public byte[] Data { get; private set; }

        public WebImage(Uri url, byte[] data)
        {
            Url = url;
            Data = data;
        }

        public static async Task<WebImage> DownloadAsync(Uri url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(Url));
            }

            if (!url.IsAbsoluteUri)
            {
                throw new ArgumentException("Not absoulute");
            }

            HttpClient client = new HttpClient();
            byte[] data = await client.GetByteArrayAsync(url);

            return new WebImage(url, data);
        }
    }
}
