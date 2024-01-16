using System;
using System.Collections.Generic;
using System.Text;

namespace Encryption.Interfaz
{
    public interface IEncryptText
    {
        string GenerarKey();
        string Encriptar(string texto, string key);
        string Desencriptar(string texto, string key);
    }
}
