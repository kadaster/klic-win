using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;

namespace KlicOauthExample
{
    internal class TokenRepository
    {
        #region Private Fields

        private readonly string _configFileName;

        #endregion Private Fields

        #region Public Constructors

        public TokenRepository()
        {
            _configFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Tokens.xml");
        }

        #endregion Public Constructors

        #region Public Properties

        public string ConfigFileName { get { return _configFileName; } }

        #endregion Public Properties

        #region Public Methods

        public TokenCollection LoadTokens()
        {
            if (!File.Exists(_configFileName))
            {
                return null;
            }
            TokenCollection resultCollection = null;
            using (var stream = new FileStream(_configFileName, FileMode.Open))
            //using (var reader = XmlReader.Create(stream))
            {
                var ser = new DataContractSerializer(typeof(TokenCollection));
                resultCollection = ser.ReadObject(stream) as TokenCollection;
            }
            return resultCollection;
        }

        public void SaveTokens(TokenCollection tokens)
        {
            using (var stream = new FileStream(_configFileName, FileMode.Create))
            using (var writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true }))
            {
                var ser = new DataContractSerializer(typeof(TokenCollection));
                ser.WriteObject(writer, tokens);
            }
        }

        #endregion Public Methods
    }
}