using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Context;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly AgendaContext _context;

        public ProdutoController(AgendaContext context)
        {
            _context = context;
        }

//Geração da Visualização Total Inicial
        public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }

//Criação
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Produto produto)
        {
            if(ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

//Edição do Produto
        public IActionResult Editar(int id)
        {
            var produto = _context.Produtos.Find(id);
            if(produto == null)
                return RedirectToAction(nameof(Index));

            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            var produtoBanco = _context.Produtos.Find(produto.Id);

            produtoBanco.Nome = produto.Nome;
            produtoBanco.Valor = produto.Valor;
            produtoBanco.Validade = produto.Validade;
            produtoBanco.Ativo = produto.Ativo;

            _context.Produtos.Update(produtoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

//Detalhes do Contato
        public IActionResult Detalhes(int Id)
        {
            var produto = _context.Produtos.Find(Id);

            if (produto == null)
                return RedirectToAction(nameof(Index));

            return View(produto);
        }

//Excluir Produto
        public IActionResult Deletar(int Id)
        {
            var produto = _context.Produtos.Find(Id);

            if (produto == null)
                return RedirectToAction(nameof(Index));

            return View(produto);
        }
        [HttpPost]
        public IActionResult Deletar(Produto produto)
        {
            var produtoBanco = _context.Produtos.Find(produto.Id);

            _context.Produtos.Remove(produtoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}