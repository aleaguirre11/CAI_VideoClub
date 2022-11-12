using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
    public class TransactionResult
    {
        public bool IsOk { get; set; }
        public int Id { get; set; }
        public string Error { get; set; }
    }
}
