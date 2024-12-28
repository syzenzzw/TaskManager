using System.Data;

namespace TaskManager.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Tittle { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
