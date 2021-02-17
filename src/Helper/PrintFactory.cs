using Siemens.Service;

namespace Siemens.Helper
{
    public class PrintFactory : IPrintFactory
    {
        public IPrintService Create(string printType) 
        {
            PrintType type = DeterminePrintType(printType); // or any place stored

            switch (type) {
            case PrintType.pdf:
                return new PrintPDFService(); // resolve using di container
            case PrintType.file:
                return new PrintToFileService(); // resolve using di container
            case PrintType.paper:
                return new PrintToPaperService(); // resolve using di container
            default:
                return new PrintPDFService();
            }
        }

        private PrintType DeterminePrintType(string printType)
        {
            switch (printType)
            {
                case "pdf":
                    return PrintType.pdf;
                case "file":
                    return PrintType.file;
                case "paper":
                    return PrintType.paper;
                default:
                    return PrintType.pdf;
            }
        }
    }   
}