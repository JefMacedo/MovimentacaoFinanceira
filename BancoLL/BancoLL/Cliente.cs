internal class Cliente
{
    public string Codigo { get; private set; }
    public string Nome { get; private set; }
    public decimal Saldo { get; private set; }
    public List<Movimentacao> Movimentacoes { get; set; }

    public Cliente()
    {
        Movimentacoes = new List<Movimentacao>();
    }

    public Cliente(string codigo, string nome) :this()
    {
        Codigo = codigo;
        Nome = nome;
    }

    public void RealizarDeposito(decimal value)
    {
        if (value >= 10)
        {
            decimal valorMenosTaxa = DescontarTaxa(value);
            Saldo = Saldo + valorMenosTaxa;
            AdicionarMovimentacao("DEPÓSITO", valorMenosTaxa);
            Console.WriteLine($"Depósito realizado com sucesso. Saldo: R$ {Saldo}");
        }
        else
            Console.WriteLine("O valor a ser depositado deve ser maior que R$ 10,00");
    }

    public void RealizarSaque(decimal value)
    {
        if (Saldo > value)
        {
            decimal valorMenosTaxa = DescontarTaxa(value);
            Saldo = Saldo - valorMenosTaxa;
            AdicionarMovimentacao("SAQUE", valorMenosTaxa);
            Console.WriteLine($"Saque realizado com sucesso. Saldo: R$ {Saldo}");
        }
        else
            Console.WriteLine("Saldo insuficiente");
    }

    private void AdicionarMovimentacao(string tipo, decimal value)
    {
        Movimentacoes.Add(new Movimentacao(tipo, DescontarTaxa(value)));
    }

    public virtual decimal DescontarTaxa(decimal value)
    {
        return value;
    }
}