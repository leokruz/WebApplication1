using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Util
{
    public class Utils
    {
        public enum StatusPedido
        {
            PedidoRecebido = 1,
            PagamentoConfirmado = 2,
            NotaFiscalEmitida = 3,
            EmTransporte = 4,
            ProdutoEntregue = 5
        }

        public enum FormaDePagamento
        {
            BoletoBancario = 1,
            CartaodeCredito = 2
        }

        public static string ObterFormaDePagamento(int id)
        {
            var retorno = string.Empty;
            switch (id)
            {
                case 1:
                    retorno = "Boleto Bancário";
                    break;
                case 2:
                    retorno = "Cartão de Crédito";
                    break;
                case 3:
                    retorno = "";
                    break;
            }

            return retorno;
        }

        public static string ObterStatusPedido(string id)
        {
            var retorno = string.Empty;
            switch (id)
            {
                case "1":
                    retorno = "Pedido Efetuado";
                    break;
                case "2":
                    retorno = "Pagamento Autorizado";
                    break;
                case "3":
                    retorno = "Nota Fiscal Emitida";
                    break;
                case "4":
                    retorno = "Em Transporte";
                    break;
                case "5":
                    retorno = "Produto Entregue";
                    break;
            }

            return retorno;
        }
    }
}