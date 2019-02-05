using System.Net;

namespace TestNinja.Mocking
{
    public interface IFileDownLoader
    {
        void DownLoadFile(string url, string path);
    }

    public class FileDownLoader : IFileDownLoader
    {
        public void DownLoadFile(string url, string path)
        {
            var client = new WebClient();

            client.DownloadFile(url, path);
        }
    }
}
