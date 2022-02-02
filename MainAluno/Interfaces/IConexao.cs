using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAluno.Interfaces
{
    internal interface IConexao
    {
        void Close();
        void Open();
        IDbCommand Comandos();
    }
}
