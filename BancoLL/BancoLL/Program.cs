using BancoLL;

List<Cliente> clientes = new List<Cliente>();
ConsultarCliente();

void ConsultarCliente()
{
    Console.WriteLine("Olá! Bem vindo ao Banco LL.");
    Console.WriteLine("Digite seu código: ");
    string codigo = Console.ReadLine();
    Cliente cliente = null;

    foreach (Cliente cli in clientes)
    {
        if (cli.Codigo == codigo)
            cliente = cli;
    }

    if (cliente == null)
    {
        Console.WriteLine("Este cliente não existe. Deseja cadastrar? Digite S ou N");
        string cadastrarCliente = Console.ReadLine();

        if (cadastrarCliente.ToUpper() == "S")
        {
            Console.WriteLine("Digite seu código:");
            string codigoNovoCliente = Console.ReadLine();

            Console.WriteLine("Digite seu nome:");
            string nomeNovoCliente = Console.ReadLine();

            Console.WriteLine("Digite seu tipo de conta: (PF ou PJ)");
            string tipoNovoCliente = Console.ReadLine();

            if (tipoNovoCliente.ToUpper() == "PF")
            {
                Console.WriteLine("Digite seu CPF:");
                string cpfNovoCliente = Console.ReadLine();

                cliente = new PessoaFisica(codigoNovoCliente, nomeNovoCliente, cpfNovoCliente);

            }
            else if (tipoNovoCliente.ToUpper() == "PJ")
            {
                Console.WriteLine("Digite seu CNPJ:");
                string cnpjNovoCliente = Console.ReadLine();

                cliente = new PessoaJuridica(codigoNovoCliente, nomeNovoCliente, cnpjNovoCliente);
            }
            else
            {
                Console.WriteLine("Tipo de conta invalido!");
                ConsultarCliente();
            }
            clientes.Add(cliente);

            ExibirMenu(cliente);
        }
        else
            ConsultarCliente();
    }
}

void ExibirMenu(Cliente cliente)
{
    Console.WriteLine($"Olá {cliente.Nome}");
    Console.WriteLine("Digite a opção desejada:");
    Console.WriteLine("1 - Extrato");
    Console.WriteLine("2 - Saque");
    Console.WriteLine("3 - Depósito");

    string menu = Console.ReadLine();

    switch (menu)
    {
        case "1":
            ExibirExtrato(cliente);
            break;
        case "2":
            RealizarSaque(cliente);
            break;
        case "3":
            RealizarDeposito(cliente);
            break;
        default:
            Console.WriteLine("Opção inválida!");
            ExibirMenu(cliente);
            break;
    }
}

void ExibirExtrato(Cliente cliente)
{
    Console.WriteLine("------ EXTRATO ------");

    foreach (Movimentacao mov in cliente.Movimentacoes)
        Console.WriteLine($"{mov.Tipo} - {mov.Valor}");

    Console.WriteLine("Deseja voltar para o Menu? (S/N)");
    string exibirMenu = Console.ReadLine();


    if (exibirMenu.ToUpper() == "S")
    {
        ExibirMenu(cliente);
    }
    else if (exibirMenu.ToUpper() == "N")
    {
        Console.WriteLine("Deseja consultar outro cliente? (S/N)");
        string consultarOutroCliente = Console.ReadLine();

        if (consultarOutroCliente.ToUpper() == "S")
            ConsultarCliente();
    }
    else
    {
        Console.WriteLine("Opção inválida!");
        ExibirExtrato(cliente);
    }
}

void RealizarSaque(Cliente cliente)
{
    Console.WriteLine("Digite o valor que deseja sacar:");
    string valor = Console.ReadLine();

    cliente.RealizarSaque(Convert.ToDecimal(valor));

    Console.WriteLine("Deseja realizar outra transação? (S/N)");
    string realizarOutraTransacao = Console.ReadLine();

    if (realizarOutraTransacao.ToUpper() == "S")
        ExibirMenu(cliente);
    else
        Console.WriteLine("Foi um prazer lhe atender! Até Mais!");
}

void RealizarDeposito(Cliente cliente)
{
    Console.WriteLine("Digite o valor que deseja depositar: ");
    string valor = Console.ReadLine();

    cliente.RealizarDeposito(Convert.ToDecimal(valor));

    Console.WriteLine("Deseja realizar outra transação? (S/N)");
    string realizarOutraTransacao = Console.ReadLine();

    if (realizarOutraTransacao.ToUpper() == "S")
        ExibirMenu(cliente);
    else
        Console.WriteLine("Foi um prazer lhe atender! Até Mais!");
}
