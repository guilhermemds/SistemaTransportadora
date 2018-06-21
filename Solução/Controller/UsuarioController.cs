﻿using Controller.Base;
using Controller.DAL;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class UsuarioController : IBaseController<Motorista>
    {
        private Contexto contexto = new Contexto();

        public void Adicionar(Motorista entity)
        {
            contexto.Motorista.Add(entity);
            contexto.SaveChanges();
            
        }

        public Motorista BuscarPorID(int id)
        {
            return contexto.Motorista.Find(id);
        }

        public void Editar(Motorista entity)
        {
            contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            Motorista usu = BuscarPorID(id);

            if(usu != null)
            {
                contexto.Motorista.Remove(usu);

                contexto.SaveChanges();
            }
        }

        public List<Motorista> ListarPorNome(string nome)
        {
            return contexto.Motorista.Where(usu => usu.Nome == nome).ToList();
        }

        public List<Motorista> ListarTodos()
        {
            return contexto.Motorista.ToList();
        }
    }
}
