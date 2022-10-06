namespace BancoLL
{
    internal class PessoaJuridica : Cliente
    {
        public string CNPJ { get; set; }

        public PessoaJuridica(string codigoNovoCliente, string nomeNovoCliente, string cnpjNovoCliente) :base(codigoNovoCliente, nomeNovoCliente)
        {
            this.CNPJ = cnpjNovoCliente;
        }

        public override decimal DescontarTaxa(decimal value)
        {
            return (value - 2);
        }
    }
}
