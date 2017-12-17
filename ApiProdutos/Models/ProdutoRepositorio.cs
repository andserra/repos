using System;
using System.Collections.Generic;

namespace ApiProdutos.Models
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produto> produtos = new List<Produto>();
        private int _nextId = 1;

        public ProdutoRepositorio()
        {
            Add(new Produto { Nome = "Televisão", Categoria = "Eletroeletrônico", Preco = 1000.59M });
            Add(new Produto { Nome = "Geladeira", Categoria = "Eletrodoméstico", Preco = 3335.75M });
            Add(new Produto { Nome = "Fogão", Categoria = "Eletrodoméstico", Preco = 800.90M });
            Add(new Produto { Nome = "Notebook", Categoria = "Eletroeletrônico", Preco = 2000.99M });
            Add(new Produto { Nome = "Monitor", Categoria = "Eletrodoméstico", Preco = 500.50M });
            Add(new Produto { Nome = "Microondas", Categoria = "Eletrodoméstico", Preco = 400.25M });
        }

        public Produto Add(Produto item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            produtos.Add(item);
            return item;
        }

        public Produto Get(int id)
        {
            return produtos.Find(p => p.Id == id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return produtos;
        }

        public void Remove(int id)
        {
            produtos.RemoveAll(p => p.Id == id);
        }

        public bool Update(Produto item)
        {
            if( item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = produtos.FindIndex(p => p.Id == item.Id);

            if(index == -1)
            {
                return false;
            }
            produtos.RemoveAt(index);
            produtos.Add(item);
            return true;
        }
    }
}