using System;
using System.Collections.Generic;
using Projeto1.Interfaces;

namespace Projeto1{

    public class RepositorioRestaurante : Repositorio<Cadastro>
    {
        private List<Cadastro> listaCadastro = new List<Cadastro>();

        public void Atualiza(int id, Cadastro objeto)
        {
            listaCadastro[id] = objeto;
        }
        public void Exclui(int id)
        {
            listaCadastro[id].Excluir();

        }
        public void Insere(Cadastro objeto)
        {
            listaCadastro.Add(objeto);
        }
        public List<Cadastro> Lista()
        {
            return listaCadastro;
        }
        public int ProximoId()
        {
            return listaCadastro.Count;
        }
        public Cadastro RetornaPorId(int id)
        {
            return listaCadastro[id];
        }
    }
}
