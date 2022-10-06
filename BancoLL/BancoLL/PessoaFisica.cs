namespace BancoLL
{
    internal class PessoaFisica : Cliente
    {
        public string CPF { get; set; }

        public PessoaFisica(string codigoNovoCliente, string nomeNovoCliente, string cpfNovoCliente) : base(codigoNovoCliente, nomeNovoCliente)
        {
            this.CPF = cpfNovoCliente;
        }

        public override decimal DescontarTaxa(decimal value)
        {
            return (value - 1);
        }

    }
}
