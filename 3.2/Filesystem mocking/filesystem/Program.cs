using System.IO;
using System.IO.Abstractions;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace filesystem
{
    public class FileProcessorTestable
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IFileSystem _fileSystem;

        public FileProcessorTestable() : this(new FileSystem()) { }

        public FileProcessorTestable(IFileSystem fileSystem)
        {
            // cyclomatic complexity = 1
            _fileSystem = fileSystem;
        }
        static void Main(string[] args)
        {
            log.Info("Starting");
            FileProcessorTestable yes = new FileProcessorTestable();
            var input = "mmm.txt";
            yes.ConvertFirstLineToUpper(input);
            log.Info("Ending");
        }


        public void ConvertFirstLineToUpper(string inputFilePath)
        {
            // cyclomatic complexity = 4
            try
            {
                string outputFilePath = Path.ChangeExtension(inputFilePath, ".out.txt");
                using (StreamReader inputReader = _fileSystem.File.OpenText(inputFilePath))
                using (StreamWriter outputWriter = _fileSystem.File.CreateText(outputFilePath))
                {
                    bool isFirstLine = true;

                    while (!inputReader.EndOfStream)
                    {
                        string line = inputReader.ReadLine();

                        if (isFirstLine)
                        {
                            line = line.ToUpperInvariant();
                            isFirstLine = false;
                        }

                        outputWriter.WriteLine(line);
                    }
                }
                log.Info("Succesfully read and wrote file");
            }
            catch (Exception e)
            {
                log.Error("Error", e);
                throw;
            }
        }
    } 
}