using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class CheckoutModel
    {
        public CarrinhoModel Carrinho { get; set; }

        public int IdCliente { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Selecione a forma de pagamento.")]
        [DisplayName("Forma de Pagamento")]
        public int IdFormaPagamento { get; set; }


        public List<SelectListItem> ObterFormasPagamento()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Selecione...",
                Value = ""
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Boleto Bancário",
                Value = "1"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Cartão de Crédito",
                Value = "2"
            });            

            return list;
        }


    }
}