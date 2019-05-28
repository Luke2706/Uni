using System;

namespace Aufgabe4
{
    public abstract class InvalidKennzeichenException : Exception
    {
        private String kennzeichenNachricht = "Kennzeichen ungültig: ";

        public virtual string KennzeichenNachricht {get;}
    }

    public class InvalidKennzeichenStringException : InvalidKennzeichenException
    {
        private readonly string _content;
        private readonly string _typ;
        private readonly int _maxAmount;

        public override string KennzeichenNachricht =>
            base.KennzeichenNachricht + $"Bestandteil {_typ} darf nur {_maxAmount:d} Buchstaben enthalten. War aber: {_content}";
        public InvalidKennzeichenStringException(string typ, string content, int maxAmount)
        {
            _typ = typ;
            _content = content;
            _maxAmount = maxAmount;
        }
    }

    public class InvalidKennzeichenIntergerExecption : InvalidKennzeichenException
    {
        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly int _data;
        public override string KennzeichenNachricht =>
            base.KennzeichenNachricht + $"Bestandteil Zahl darf nur eine Zahl zwischen [{_minValue:d}, " +
            $"{_maxValue:d}] enthalten. War aber: {_data:d}";
        
        public InvalidKennzeichenIntergerExecption(int minValue, int maxValue, int data)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _data = data;
        }
    }
}