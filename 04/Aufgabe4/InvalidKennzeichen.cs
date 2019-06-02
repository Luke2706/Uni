using System;

namespace Aufgabe4
{
    
    /// <summary>
    /// Implementation of the exceptions
    /// The important one is the readonly property for 'KennzeichenNachricht' which creates the error message.
    /// 'KennzeichenNachricht' is created via a string manipulation
    /// </summary>
    
    public abstract class InvalidKennzeichenException : Exception
    {
        private String kennzeichenNachricht = "Kennzeichen ungültig: ";

        public virtual string KennzeichenNachricht {get;}
    }

    public class InvalidKennzeichenStringException : InvalidKennzeichenException //Exception for errors with Ort and Buchstabe
    {
        private readonly string _content;
        private readonly string _typ;
        private readonly int _maxAmount;

        public override string KennzeichenNachricht =>
            base.KennzeichenNachricht + $"Bestandteil {_typ} darf nur {_maxAmount:d} Buchstaben enthalten. War aber: {_content}"; // '=>' is just a another version to create a get/set property 
        public InvalidKennzeichenStringException(string typ, string content, int maxAmount) //typ is needed to set the 'error' message properly up 
        {
            _typ = typ;
            _content = content;
            _maxAmount = maxAmount;
        }
    }

    public class InvalidKennzeichenIntergerExecption : InvalidKennzeichenException //Exception for errors with Zahl
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