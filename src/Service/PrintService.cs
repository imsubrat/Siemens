using System;
using Siemens.Model;

namespace Siemens.Service
{
    public interface IPrintService
    {
        void Print(PrintModel input);
    }

    public class PrintPDFService : IPrintService
    {
        public void Print(PrintModel input)
        {
             
        }
    }

    public class PrintToFileService : IPrintService
    {
        public void Print(PrintModel input)
        {
             
        }
    }

    public class PrintToPaperService : IPrintService
    {
        public void Print(PrintModel input)
        {
             throw new NotImplementedException();
        }
    }
}