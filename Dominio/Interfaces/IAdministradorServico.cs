using DIOAPI.Dominio.DTOs;
using DIOAPI.Dominio.Entidades;

namespace DIOAPI.Dominio.Interfaces
{
    public interface IAdministradorServico
    {
        Administrador? Login(LoginDTO loginDTO);

        Administrador Incluir(Administrador administrador);

        List<Administrador> Todos(int? pagina);

        Administrador? BuscarPorId(int id);
    }
}
