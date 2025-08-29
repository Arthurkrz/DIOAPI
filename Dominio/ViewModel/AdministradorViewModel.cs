using DIOAPI.Dominio.Enum;

namespace DIOAPI.Dominio.ViewModel
{
    public class AdministradorViewModel
    {
        public int Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Perfil { get; set; } = default!;
    }
}
