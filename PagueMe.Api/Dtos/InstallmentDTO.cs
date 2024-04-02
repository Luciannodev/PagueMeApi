using System;

namespace Pagame.Api.Dtos
{
    public class InstallmentDTO
    {
        public int OrdemParcela { get; set; }

        public required String DataVencimento { get; set; }
        public int Value { get; set; }
    }
}
