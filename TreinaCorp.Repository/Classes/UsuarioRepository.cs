using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TreinaCorp.Domain;

namespace TreinaCorp.Repository.Classes
{
    public class UsuarioRepository : Repository<Usuario>
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Register(Usuario model)
        {
            var source = model.Senha;
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, source);
                model.Senha = hash;
                _context.Usuarios.Add(model);
                _context.SaveChanges();
            }  
        }
        //Gera Hash MD5 para senha do usuario
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public Usuario Login(Usuario model)
        {

            Usuario user = new Usuario();
            user.Nome = model.Nome;
            var source = model.Senha;
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, source);
                model.Senha = hash;

                Usuario usuarioLogado = _context.Usuarios.FirstOrDefault(u => u.Nome == user.Nome && u.Senha == model.Senha);

                return usuarioLogado;   
            }
        }
    }
}
