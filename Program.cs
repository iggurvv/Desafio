using System;
using System.Collections.Generic;


// DESAFIO 1
class Desafio1VendasComissao
{
    static void Main()
    {
        var vendas = new List<(string vendedor, double valor)>
        {
            ("João Silva", 1200.50), ("João Silva", 950.75), ("João Silva", 1800.00),
            ("João Silva", 1400.30), ("João Silva", 1100.90), ("João Silva", 1550.00),
            ("João Silva", 1700.80), ("João Silva", 250.30), ("João Silva", 480.75),
            ("João Silva", 320.40),

            ("Maria Souza", 2100.40), ("Maria Souza", 1350.60), ("Maria Souza", 950.20),
            ("Maria Souza", 1600.75), ("Maria Souza", 1750.00), ("Maria Souza", 1450.90),
            ("Maria Souza", 400.50), ("Maria Souza", 180.20), ("Maria Souza", 90.75),

            ("Carlos Oliveira", 800.50), ("Carlos Oliveira", 1200.00), ("Carlos Oliveira", 1950.30),
            ("Carlos Oliveira", 1750.80), ("Carlos Oliveira", 1300.60), ("Carlos Oliveira", 300.40),
            ("Carlos Oliveira", 500.00), ("Carlos Oliveira", 125.75),

            ("Ana Lima", 1000.00), ("Ana Lima", 1100.50), ("Ana Lima", 1250.75),
            ("Ana Lima", 1400.20), ("Ana Lima", 1550.90), ("Ana Lima", 1650.00),
            ("Ana Lima", 75.30), ("Ana Lima", 420.90), ("Ana Lima", 315.40)
        };

        var comissoes = new Dictionary<string, double>();

        foreach (var venda in vendas)
        {
            double comissao = CalcularComissao(venda.valor);

            if (!comissoes.ContainsKey(venda.vendedor))
                comissoes[venda.vendedor] = 0;

            comissoes[venda.vendedor] += comissao;
        }

        foreach (var c in comissoes)
        {
            Console.WriteLine($"{c.Key} - Comissão Total: R$ {c.Value:F2}");
        }
    }

    static double CalcularComissao(double valor)
    {
        if (valor < 100) return 0;
        if (valor < 500) return valor * 0.01;
        return valor * 0.05;
    }
}



 
// DESAFIO 2 
class Desafio2MovimentacaoEstoque
{
    class Produto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Estoque { get; set; }
    }

    static List<Produto> estoque = new List<Produto>
    {
        new Produto { Codigo = 101, Descricao = "Caneta Azul", Estoque = 150 },
        new Produto { Codigo = 102, Descricao = "Caderno Universitário", Estoque = 75 },
        new Produto { Codigo = 103, Descricao = "Borracha Branca", Estoque = 200 },
        new Produto { Codigo = 104, Descricao = "Lápis Preto HB", Estoque = 320 },
        new Produto { Codigo = 105, Descricao = "Marcador de Texto Amarelo", Estoque = 90 }
    };

    static void Main()
    {
        Movimentar(101, 20, "Entrada de mercadoria");
        Movimentar(103, -50, "Saída por venda");
    }

    static void Movimentar(int codigo, int quantidade, string descricao)
    {
        var produto = estoque.Find(p => p.Codigo == codigo);

        if (produto == null)
        {
            Console.WriteLine("Produto não encontrado.");
            return;
        }

        produto.Estoque += quantidade;
        int id = new Random().Next(1000, 9999);

        Console.WriteLine($"ID Movimentação: {id}");
        Console.WriteLine($"Descrição: {descricao}");
        Console.WriteLine($"Estoque Final ({produto.Descricao}): {produto.Estoque}");
    }
}

// DESAFIO 3

class Desafio3CalculoJuros
{
    static void Main()
    {
        double valor = 1000;
        string dataVencimento = "10/11/2025";

        double juros = CalcularJuros(valor, dataVencimento);

        Console.WriteLine($"Juros calculados: R$ {juros:F2}");
    }

    static double CalcularJuros(double valor, string dataVencimento)
    {
        DateTime hoje = DateTime.Now.Date;
        DateTime vencimento = DateTime.Parse(dataVencimento);

        int diasAtraso = (hoje - vencimento).Days;

        if (diasAtraso <= 0) return 0;

        return valor * 0.025 * diasAtraso;
    }
}
