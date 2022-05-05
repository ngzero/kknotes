using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kknotes.Data.Entities;

namespace kknotes.Data.Repositories.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Note>> GetNotesAsync();
        Task<Note> GetNoteAsync(int id);
        Task<bool> CreateNoteAsync(Note note);
        Task<bool> UpdateNoteAsync(Note note);
        Task<bool> DeleteNoteAsync(int id);
    }
}
