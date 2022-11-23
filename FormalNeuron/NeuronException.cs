using System;
using System.Collections.Generic;
using System.Text;

namespace FormalNeuron
{
    class NeuronException : ArgumentException
    {
        private double valueOfException { get; }
        public NeuronException(string message, double val)
            : base(message)
        {
            valueOfException = val;
        }
    }
}
