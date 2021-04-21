using System;

namespace TreinaCorp.Domain 
{ 

    public class Feedback
{
    public int Id { get; set; }
    public Usuario Usuario { get; set; }
    public int UsuarioId { get; set; }
    public Aula Aula { get; set; }
    public int AulaId { get; set; }
    public int MensagemFeedback { get; set; }
    }
}
