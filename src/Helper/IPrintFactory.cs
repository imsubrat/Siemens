using Siemens.Service;

namespace Siemens.Helper
{
    public interface IPrintFactory
    {
        IPrintService Create(string printType);
    }

    public enum PrintType
    {
        file,
        pdf,
        paper
    }
}