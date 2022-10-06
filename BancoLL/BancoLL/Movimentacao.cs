public class Movimentacao
{
    public string Tipo { get; private set; }
    public decimal Valor { get; private set; }

    public Movimentacao(string tipo, decimal valor) 
    {
        this.Tipo = tipo;
        this.Valor = valor;
    }
}