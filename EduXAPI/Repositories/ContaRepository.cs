using EduXAPI.Contexts;
using EduXAPI.Domains;
using EduXAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduXAPI.Repositories
{
    public class ContaRepository : iConta
    {
        private readonly EduXAPIContext _context;

        public ContaRepository(EduXAPIContext context)
        {
            _context = context;
        }

        public Usuarios Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public Usuarios Register(string nome, string email, string senha, string tipo)
        {
            Usuarios usuario = new Usuarios() { Nome = nome, Email = email, Senha = senha, Tipo = tipo};
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }
    }
}
