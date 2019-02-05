using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private readonly IFileDownLoader _fileDownLoader;

        public InstallerHelper( IFileDownLoader fileDownLoader)
        {
            _fileDownLoader = fileDownLoader;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _fileDownLoader.DownLoadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}