using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifradoSimetrico
{
    class MyEncryptor : ICryptoTransform
    {
        byte[] key;

        public MyEncryptor(byte[] _key)
        {
            key = _key;
        }

        public bool CanTransformMultipleBlocks { get { return false; } }

        public bool CanReuseTransform { get { return false; } }

        public int InputBlockSize { get { return 16; } }

        public int OutputBlockSize { get { return 16; } }

        public void Dispose() { }

        public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        {
            // No hace absolutamente nada con el bloque, ya que se limita a copiar los datos del buffer de entrada al de salida

            for (int i = 0; i < inputCount; i++)
            {
                outputBuffer[outputOffset + i] = inputBuffer[inputOffset + i];
            }

            return inputCount;
        }

        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            // No hace absolutamente nada con el bloque, ya que se limita a copiar los datos del buffer de entrada al de salida

            byte[] outputBuffer = new byte[inputCount];

            for (int i = 0; i < inputCount; i++)
            {
                outputBuffer[i] = inputBuffer[inputOffset + i];
            }

            return outputBuffer;
        }
    }
}
