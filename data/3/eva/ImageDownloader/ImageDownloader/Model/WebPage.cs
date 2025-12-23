using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownloader_.Model
{
    public class WebPage
    {
        public Uri BaseUrl { get; private set; }
        private ICollection<WebImage> _images;

        public event EventHandler<WebImage> ImageLoaded;
        public event EventHandler<int> LoadProgress;

        public WebPage(Uri baseUrl)
        {
            if (baseUrl == null)
            {
                throw new ArgumentNullException(nameof(Url));
            }

            if (!baseUrl.IsAbsoluteUri)
            {
                throw new ArgumentException("Not absoulute");
            }

            BaseUrl = baseUrl;
        }

        public async Task LoadImagesAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(BaseUrl); // HttpResponseMessage
            var content = await response.Content.ReadAsStringAsync(); // string

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);

            var nodes = doc.DocumentNode.SelectNodes("//img");

            _images.Clear();
            
            if(nodes == null)
            {
                return;
            }
            int counter = 0;
            foreach (var node in nodes)
            {

                counter++;

                if (!node.Attributes.Contains("src"))
                {
                    continue;
                }

                Uri imageUrl = new Uri(node.Attributes["src"].Value, UriKind.RelativeOrAbsolute);
                if (!imageUrl.IsAbsoluteUri)
                {
                    imageUrl = new Uri(BaseUrl, imageUrl);
                }

                try
                {
                    var image = await WebImage.DownloadAsync(imageUrl);
                    _images.Add(image);

                    ImageLoaded?.Invoke(this, image);
                }
                catch (Exception)
                {
                    // ignored
                }

                LoadProgress?.Invoke(this, 100 * (counter / nodes.Count));
            }

        }
    }
}
