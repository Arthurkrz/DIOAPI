using DIOAPI.Dominio.DTOs;
using DIOAPI.Dominio.Entidades;
using DIOAPI.Dominio.Interfaces;
using DIOAPI.Infraestrutura.Db;

namespace DIOAPI.Dominio.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;
        public AdministradorServico(DbContexto contexto) 
        {
            _contexto = contexto;        
        }

        public Administrador Incluir(Administrador administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();

            return administrador;
        }

        public Administrador? Login(LoginDTO loginDTO) =>
            _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();

        public List<Administrador> Todos(int? pagina)
        {
            var query = _contexto.Administradores.AsQueryable();

            int itensPorPagina = 10;

            if (pagina != null)
                query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);

            return query.ToList();
        }

        public Administrador? BuscarPorId(int id) =>
            _contexto.Administradores.Where(v => v.Id == id).FirstOrDefault();
    }
}
