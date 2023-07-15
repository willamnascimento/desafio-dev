﻿namespace Desafio.Service;

public class TipoSinal
	{
    public static string returnSignType(string type)
    {
        Dictionary<string, string> signType = new Dictionary<string, string>()
        {
            { "1", "+" }, // Débito - Entrada
            { "2", "-" }, // Boleto - Saída
            { "3", "-" }, // Financiamento - Saída
            { "4", "+" }, // Crédito - Entrada
            { "5", "+" }, // Recebimento Empréstimo - Entrada
            { "6", "+" }, // Vendas - Entrada
            { "7", "+" }, // Recebimento TED - Entrada
            { "8", "+" }, // Recebimento DOC - Entrada
            { "9", "-" }  // Aluguel - Saída
        };

        return signType[type];
    }
}

