using DIOAPI.Dominio.Entidades;
using DIOAPI.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIOAPI.Tests.Mocks
{
    public class AdministradorServicoMock : IAdministradorServico
    {
        private static List<Administrador> administradores = new List<Administrador>()
        {
            new Administrador
            {
                Id = 1,
                Email = "adm@teste.com",
                Senha = "123456",
                Perfil = "Adm"
            },

            new Administrador
            {
                Id = 2,
                Email = "editor@teste.com",
                Senha = "123456",
                Perfil = "Editor"
            }
        };

        public List<Administrador> Todos(int? pagina) => administradores;

        public Administrador? BuscarPorId(int id) =>
            administradores.FirstOrDefault(a => a.Id == id);

        public Administrador? Login(Dominio.DTOs.LoginDTO loginDTO) =>
            administradores.FirstOrDefault(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);

        public Administrador Incluir(Administrador administrador)
        {
            administrador.Id = administradores.Count() + 1;
            administradores.Add(administrador);

            return administrador;
        }
    }
}
